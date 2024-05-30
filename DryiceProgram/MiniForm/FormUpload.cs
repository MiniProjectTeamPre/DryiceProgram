using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DryiceProgram {
    public partial class FormUpload : Form {
        private readonly FormStart main;
        public FormUpload(FormStart main) {
            InitializeComponent();
            this.main = main;
        }

        public string head;
        public string stLink;
        public string hex;
        public string checkSum;
        public string timeOut;
        public bool debug;

        public bool flagRun = false;
        public string resultMain;
        private string ackResult;
        private bool flagCancelWaitAck = false;

        private const string checkTarget = "No target";
        private const string patternNoID = @"No ST-LINK \[ID=.*?\] Found!";
        private const string checkVerify = "Verification...OK";
        private const string checkProgComplete = "Programming Complete.";

        private CancellationTokenSource cts;

        public async void Run() {
            flagRun = true;
            lb_stLink.Text = $"ST-Link : {stLink}";
            lb_hex.Text = $"Hex : {hex}";
            lb_result.Text = "Uploading";
            lb_head.Text = $"Programming {head}";
            lb_headWaitAck.Text = $"Programming {head}";
            lb_result.BackColor = this.BackColor;
            resultMain = "Running...";
            Show();

            string batFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"BatProgrammimg{head}.bat");
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"LogProgrammig{head}.log");

            try
            {
                // Delete existing log and batch files
                if (File.Exists(logFilePath))
                {
                    main.fileTxt.TryDeleteFile(logFilePath);
                }
                if (File.Exists(batFilePath))
                {
                    main.fileTxt.TryDeleteFile(batFilePath);
                }

                // Build command string and create batch file
                string command = $"\"{main.varConfig.pathStLink}\" -c \"SN\"=\"{stLink}\" SWD UR -P \"" +
                    $"{main.formConfig.PathHex}/{hex}\" -V -Cksum \"{main.formConfig.PathHex}/{hex}\" -Rst -HardRst " +
                    $"> \"{logFilePath}\"";
                File.WriteAllText(batFilePath, command);

                // Start progress bar and execute batch file
                pgb_upLoad.Value = 0;
                tm_progressbar.Enabled = true;
                await Task.Run(() => main.ExecuteBatchFile(batFilePath, true));

                // Read log file and check for errors
                string logFile = await main.fileControl.ReadFileAsync(logFilePath, 3000);
                resultMain = logFile;
                Match checkNoID = Regex.Match(logFile, patternNoID);
                bool flagResult = true;
                string detailError = string.Empty;
                if (logFile.Contains(checkTarget))
                {
                    detailError = checkTarget;
                    flagResult = false;
                }
                else if (checkNoID.Success)
                {
                    detailError = checkNoID.Value;
                    flagResult = false;
                }
                else if (!logFile.Contains(hex))
                {
                    detailError = $"Firmware mismatch";
                    flagResult = false;
                }
                else if (!logFile.Contains(checkVerify))
                {
                    detailError = "Verification Fail";
                    flagResult = false;
                }
                else if (!logFile.Contains(checkProgComplete))
                {
                    detailError = "Not Complete";
                    flagResult = false;
                }
                else if (!logFile.Contains(checkSum))
                {
                    string checksumLog = GetChecksum(logFile);
                    detailError = $"Check Sum Fail{Environment.NewLine}{checksumLog}";
                    flagResult = false;
                }
                string result = flagResult ? "SUCCESS" : "ERROR";

                // Update UI with result
                StringBuilder sb = new StringBuilder();
                if (detailError.Contains(Environment.NewLine))
                {
                    sb.AppendLine($"***Check Sum Fail{Environment.NewLine}{checkSum}***");
                }
                else
                {
                    sb.AppendLine($"***{detailError}***");
                }
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine(logFile);
                resultMain = sb.ToString();
                lb_result.Text = result;
                if (flagResult)
                {
                    ackResult = "PASS";
                    ackResult += main.formConfig.firmware ? Environment.NewLine + hex : string.Empty;
                    ackResult += main.formConfig.verify ? Environment.NewLine + checkVerify : string.Empty;
                    ackResult += main.formConfig.progComplete ? Environment.NewLine + checkProgComplete : string.Empty;
                    ackResult += main.formConfig.checkSum ? Environment.NewLine + checkSum : string.Empty;
                    lb_result.BackColor = Color.Lime;
                    pgb_upLoad.Value = pgb_upLoad.Maximum - 1;
                }
                else
                {
                    ackResult = "FAIL" + Environment.NewLine + detailError;
                    lb_result.BackColor = Color.Red;
                    tm_progressbar.Enabled = false;
                    //MessageBox.Show(logFile);
                }
            } catch (Exception ex)
            {
                lb_result.Text = "Catch";
                ackResult = "Catch";
                lb_result.BackColor = Color.Red;
                tm_progressbar.Enabled = false;
                MessageBox.Show($"An error occurred: {ex.Message}");
            } finally
            {
                // Delete batch file
                if (File.Exists(batFilePath))
                {
                    main.fileTxt.TryDeleteFile(batFilePath);
                }
                // Delete Log file
                if (File.Exists(logFilePath))
                {
                    main.fileTxt.TryDeleteFile(logFilePath);
                }
            }

            if (main.formConfig.debug | debug)
            {
                return;
            }
            await Task.Delay(1000);
            ActResult();
        }



        private async void ActResult() {
            flagCancelWaitAck = false;
            cts = new CancellationTokenSource();
            tc_show.SelectedTab = tp_waitAck;
            try
            {
                File.WriteAllText(main.fileStart.GetPathResult() + $"Result{head}.txt", ackResult);
                string pathResultAck = main.fileStart.GetPathCommand() + $"ResultAck{head}.txt";
                string ack = await main.fileControl.ReadFileAsync(pathResultAck, 2000, cts.Token);
                while (ack == null)
                {
                    if (flagCancelWaitAck)
                    {
                        break;
                    }
                    ack = await main.fileControl.ReadFileAsync(pathResultAck, 2000, cts.Token);
                }
                File.Delete(pathResultAck);
            } catch (Exception ex)
            {
                // Handle any exceptions that occur during file writing or reading
                MessageBox.Show($"Error occurred: {ex.Message}");
            } finally
            {
                tc_show.SelectedTab = tp_upload;
                Hide();
                flagRun = false;
            }
        }




        private void tm_progressbar_Tick(object sender, EventArgs e) {
            try
            {
                if (pgb_upLoad.Value < pgb_upLoad.Maximum)
                {
                    pgb_upLoad.Value += 1;
                }
                else
                {
                    tm_progressbar.Enabled = false;
                }
            } catch (Exception ex)
            {
                // Handle any exceptions that occur while updating the progress bar value
                MessageBox.Show($"Error updating progress bar value: {ex.Message}");
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) {
            ActResult();
        }

        private void bt_viewStatus_Click(object sender, EventArgs e) {
            MessageBox.Show(resultMain);
        }


        private string GetChecksum(string input) {
            int startIndex = input.IndexOf("Programmed memory Checksum:");
            if (startIndex == -1)
            {
                return string.Empty;
            }

            startIndex += "Programmed memory Checksum:".Length;
            int endIndex = input.IndexOf('\n', startIndex);
            if (endIndex == -1)
            {
                return string.Empty;
            }

            string checksumHex = input.Substring(startIndex, endIndex - startIndex).Trim();
            return checksumHex;
        }


        private void ctms_close2__Click(object sender, EventArgs e) {
            flagCancelWaitAck = true;
            cts.Cancel();
        }
    }
}
