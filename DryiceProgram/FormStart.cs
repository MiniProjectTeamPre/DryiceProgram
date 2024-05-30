using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DryiceProgram {
    public partial class FormStart : Form {
        public FormStart() {
            InitializeComponent();
            resizeAuto = new ResizeAuto(this);
            fileStart = new MiniClass.ForFile.FileStart(this);
            fileConfig = new MiniClass.ForFile.FileConfig(this);
            fileBat = new MiniClass.ForFile.FileBat(this);
            formConfig = new MiniForm.FormConfig(this);
            formUpload[0] = new FormUpload(this);
            formUpload[1] = new FormUpload(this);
            formUpload[2] = new FormUpload(this);
            formUpload[3] = new FormUpload(this);
            formUpload[4] = new FormUpload(this);
            formWaitProcess = new MiniForm.FormWaitProcess(this);
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
        }

        #region =============================================== Input ===============================================
        private ResizeAuto resizeAuto;
        public MiniClass.ForFile.FileStart fileStart;
        public MiniClass.ForVariable.VariableConfig varConfig = new MiniClass.ForVariable.VariableConfig();
        private MiniClass.Eval evalTimerMain = new MiniClass.Eval();
        public MiniClass.ForFile.FileTxt fileTxt = new MiniClass.ForFile.FileTxt();
        private bool closing = false;
        public MiniClass.ForFile.FileConfig fileConfig;
        public MiniClass.ForFile.FileControl fileControl = new MiniClass.ForFile.FileControl();
        private MiniClass.ForFile.FileBat fileBat;
        private MiniForm.FormSelectStLink formSelectStLink = new MiniForm.FormSelectStLink();
        public MiniForm.FormConfig formConfig;
        private MiniForm.FormWaitProcess formWaitProcess;

        private FormUpload[] formUpload = new FormUpload[5];
        #endregion

        #region =============================================== Display ===============================================

        #endregion

        #region =============================================== Cal ===============================================
        private void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e) {
            Exception ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                //Console.WriteLine("Unhandled exception occurred: " + ex.Message);
                MessageBox.Show("Unhandled exception occurred: " + ex.Message);
                // handle the exception here
            }
        }

        public string ExecuteBatchFile(string batchFilePath, string arguments = null) {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo {
                    FileName = batchFilePath,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    Arguments = arguments
                };

                using (Process process = new Process { StartInfo = processStartInfo })
                {
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    return output;
                }
            } catch (Exception ex)
            {
                // Handle the exception
                MessageBox.Show($"Can't run bat file: {ex.Message}");
                return null;
            }
        }
        public string ExecuteBatchFile(string batchFilePath, bool CreateNoWindow_, string arguments = null) {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo {
                    FileName = batchFilePath,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = CreateNoWindow_,
                    Arguments = arguments
                };

                using (Process process = new Process { StartInfo = processStartInfo })
                {
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    return output;
                }
            } catch (Exception ex)
            {
                // Handle the exception
                MessageBox.Show($"Can't run bat file: {ex.Message}");
                return null;
            }
        }


        #endregion

        #region =============================================== Main ===============================================
        private void FormStart_Load(object sender, EventArgs e) {
            Panel[] panels = { pn_upLoad1, pn_upLoad2, pn_upLoad3, pn_upLoad4, pn_upLoad5 };

            for (int i = 0; i < formUpload.Length; i++)
            {
                formUpload[i].TopLevel = false;
                formUpload[i].Dock = DockStyle.Fill;
                panels[i].Controls.Add(formUpload[i]);
                //formUploads[i].Show();
            }

            resizeAuto.Initial();

            fileConfig.CheckFileConfig();

            tm_main.Enabled = true;
        }
        private void FormStart_Resize(object sender, EventArgs e) {
            resizeAuto.Resize();
            resizeAuto.Resize();
        }
        // define the queue at the class level
        public Queue<FormUpload> formQueue = new Queue<FormUpload>();
        private void tm_main_Tick(object sender, EventArgs e) {
            tm_main.Enabled = false;
            if (fileStart.CheckStart())
            {
                fileStart.ReadConfig();

                // find the first available slot
                FormUpload availableForm = null;
                foreach (FormUpload formSup in formUpload)
                {
                    if (!formSup.flagRun)
                    {
                        availableForm = formSup;
                        break;
                    }
                }

                // if there is an available slot, start the next form
                if (availableForm != null)
                {
                    availableForm.head = varConfig.head;
                    availableForm.stLink = varConfig.stLink;
                    availableForm.hex = varConfig.hex;
                    availableForm.checkSum = varConfig.checkSum;
                    availableForm.timeOut = varConfig.timeOut;
                    bool success = bool.TryParse(varConfig.deBug, out bool debugValue);
                    availableForm.debug = success ? debugValue : false;
                    availableForm.Run();
                }
                else
                {
                    // if there are no available slots, add the form to the queue
                    FormUpload queuedForm = new FormUpload(this);
                    queuedForm.head = varConfig.head;
                    queuedForm.stLink = varConfig.stLink;
                    queuedForm.hex = varConfig.hex;
                    queuedForm.checkSum = varConfig.checkSum;
                    queuedForm.timeOut = varConfig.timeOut;
                    bool success = bool.TryParse(varConfig.deBug, out bool debugValue);
                    queuedForm.debug = success ? debugValue : false;
                    formQueue.Enqueue(queuedForm);
                    lb_processWait.Text = $"Process wait ({formQueue.Count})";
                    formWaitProcess.Display();
                }
            }

            // check if there are any forms in the queue and start the next one if a slot becomes available
            foreach (FormUpload formSup in formUpload)
            {
                if (!formSup.flagRun)
                {
                    if (formQueue.Count > 0)
                    {
                        FormUpload tempForm = formQueue.Dequeue();
                        formSup.head = tempForm.head;
                        formSup.stLink = tempForm.stLink;
                        formSup.hex = tempForm.hex;
                        formSup.checkSum = tempForm.checkSum;
                        formSup.timeOut = tempForm.timeOut;
                        bool success = bool.TryParse(varConfig.deBug, out bool debugValue);
                        formSup.debug = success ? debugValue : false;
                        tempForm.Close(); // Close the temporary form
                        formSup.Run();
                        lb_processWait.Text = $"Process wait ({formQueue.Count})";
                        formWaitProcess.Display();
                    }
                    break;
                }

            }

            tm_main.Enabled = true;
        }
        private void FormStart_FormClosing(object sender, FormClosingEventArgs e) {
            if (!closing)
            {
                e.Cancel = true;
                if (this.Visible)
                {
                    this.Hide();
                }
            }
        }
        private void ctms_closeProgram_Click(object sender, EventArgs e) {
            ntfi_Main.Visible = false;
            ntfi_Main.Icon = null;
            ntfi_Main.Dispose();

            closing = true;
            Application.Exit();
        }
        private void ntfi_Main_DoubleClick(object sender, EventArgs e) {
            this.Show();
            this.Activate();
            if (Form.ActiveForm != this)
            {
                this.WindowState = FormWindowState.Minimized;
                this.WindowState = FormWindowState.Normal;
            }
        }
        private void bt_hex_Click(object sender, EventArgs e) {
            try
            {
                string folderName = fileControl.FolderGetFullName();
                if (!string.IsNullOrEmpty(folderName))
                {
                    varConfig.hexMain = folderName;
                    lb_hexFile.Text = varConfig.hexMain.Replace("\\", "/");

                    // Edit one of the details in the file
                    fileTxt.EditDetailInFile(fileConfig.nameFile, fileConfig.headHexMain, varConfig.hexMain);

                    bt_stLink.Visible = true;
                    lb_stLink.Visible = true;
                }
                else
                {
                    MessageBox.Show("Please select a valid folder.");
                    lb_hexFile.Text = string.Empty;
                    varConfig.hexMain = String.Empty;
                }
            } catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"You do not have access to this folder: {ex.Message}");
                lb_hexFile.Text = string.Empty;
                varConfig.hexMain = String.Empty;
            } catch (Exception ex)
            {
                MessageBox.Show($"Error selecting folder: {ex.Message}");
                lb_hexFile.Text = string.Empty;
                varConfig.hexMain = String.Empty;
            }
        }
        private async void bt_stLink_Click(object sender, EventArgs e) {
            //หากฟังก์ชั่นนี้ไม่สามารถ จัดหา path ที่ถูกต้อง สำหรับ exe st-link ได้ ให้ทำการลบไฟล์ Config.txt แล้วรันใหม่

            string pathExeSt = string.Empty;

            if (!string.IsNullOrEmpty(varConfig.pathStLink))
            {
                pathExeSt = varConfig.pathStLink;
            }
            else
            {
                MessageBox.Show("\"ST-LINK_CLI.exe\" could not be found.\r\n" + "Please install STM32 ST-LINK Utility.");
                return;
            }

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ListStLink.bat");
            string detail = $"\"{pathExeSt}\" -List > List.log";

            try
            {
                await Task.Run(() => File.WriteAllText(filePath, detail));
                string sup = ExecuteBatchFile(filePath);
                //MessageBox.Show(sup);
            } catch (Exception ex)
            {
                MessageBox.Show($"Error writing file \"{filePath}\": {ex.Message}");
                return;
            }

            try
            {
                string stLinkListOutput = await Task.Run(() => File.ReadAllText("List.log"));
                string[] sn = MiniClass.ForFile.FileListStLink.GetProbeSerialNumbers(stLinkListOutput);

                if (sn.Length != 0)
                {
                    formSelectStLink.cbb_stLink.Items.Clear();
                    formSelectStLink.cbb_stLink.Items.AddRange(sn);
                    formSelectStLink.ShowDialog();
                    lb_stLink.Text = formSelectStLink.cbb_stLink.Text;
                    varConfig.stLinkMain = formSelectStLink.cbb_stLink.Text;

                    fileTxt.EditDetailInFile(fileConfig.nameFile, fileConfig.headStLink, lb_stLink.Text);
                    bt_upLoad.Visible = true;
                    pgb_upLoad.Visible = true;
                }
                else
                {
                    MessageBox.Show("ST-Link not found.");
                    lb_stLink.Text = string.Empty;
                    varConfig.stLinkMain = string.Empty;
                    fileTxt.EditDetailInFile(fileConfig.nameFile, fileConfig.headStLink, string.Empty);
                    return;
                }

            } catch (IOException ex)
            {
                MessageBox.Show($"Error reading file \"List.log\": {ex.Message}");
            } catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void bt_upLoad_Click_(object sender, EventArgs e) {
            string head = "H1";
            string stLink = "StLink";
            string hex = "Test.Hex";
            string checkSum = "VWEFZDFSDF";
            string folderPath = @"D:\svn\2020_SST_Ultra_Dry_Ice_Automation\1.Customer Documents\7.Firmware\";
            string stLinkCliPath = Path.Combine(@"C:\Program Files (x86)\STMicroelectronics\STM32 ST-LINK Utility\ST-LINK Utility", "ST-LINK_CLI.exe");

            string batFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"BatProgrammimg{head}.bat");
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"LogProgrammig{head}.log");

            if (File.Exists(batFilePath))
            {
                fileTxt.TryDeleteFile(batFilePath);
            }

            string command = $"\"{stLinkCliPath}\" -c \"SN\"=\"{stLink}\" SWD UR -P \"{Path.Combine(folderPath, hex)}\" " +
                             $"-V -Cksum \"{Path.Combine(folderPath, hex)}\" -Rst -HardRst > \"{logFilePath}\"";

            pgb_upLoad.Value = 0;
            tm_progressBar.Enabled = true;
            fileTxt.TryDeleteFile(logFilePath);
            File.WriteAllText(batFilePath, command);
            string sup = ExecuteBatchFile(batFilePath);

            StringBuilder logFileBuilder = new StringBuilder();
            while (!File.Exists(logFilePath))
            {
                Thread.Sleep(50);
            }
            using (StreamReader sr = new StreamReader(logFilePath))
            {
                logFileBuilder.Append(sr.ReadToEnd());
            }
            string logFile = logFileBuilder.ToString();

            fileTxt.TryDeleteFile(batFilePath);

            bool flagResult = true;
            string result = "SUCCESS";
            if (!logFile.Contains("Verification...OK"))
            {
                flagResult = false;
                result = "Verification Fail";
            }
            else if (!logFile.Contains("Programming Complete."))
            {
                flagResult = false;
                result = "Programming not Complete";
            }
            else if (!logFile.Contains(checkSum))
            {
                flagResult = false;
                result = "Check Sum Fail";
            }

            lb_resultUpload.Visible = true;
            lb_resultUpload.Text = result;
            if (flagResult)
            {
                lb_resultUpload.BackColor = Color.Lime;
                pgb_upLoad.Value = pgb_upLoad.Maximum - 1;
            }
            else
            {
                lb_resultUpload.BackColor = Color.Red;
                tm_progressBar.Enabled = false;
                MessageBox.Show(logFile);
            }
        }
        private async void bt_upLoad_Click(object sender, EventArgs e) {
            string head = "H1";
            string stLink = varConfig.stLinkMain;
            string hex = varConfig.hexMain;

            string batFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"BatProgrammimg{head}.bat");
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"LogProgrammig{head}.log");

            try
            {
                // Delete existing log and batch files
                if (File.Exists(logFilePath))
                {
                    fileTxt.TryDeleteFile(logFilePath);
                }
                if (File.Exists(batFilePath))
                {
                    fileTxt.TryDeleteFile(batFilePath);
                }

                // Build command string and create batch file
                string command = $"\"{varConfig.pathStLink}\" -c \"SN\"=\"{stLink}\" SWD UR -P \"{hex}\" " +
                                 $"-V -Cksum \"{hex}\" -Rst -HardRst > \"{logFilePath}\"";
                File.WriteAllText(batFilePath, command);

                // Start progress bar and execute batch file
                lb_resultUpload.Visible = false;
                pgb_upLoad.Value = 0;
                tm_progressBar.Enabled = true;
                await Task.Run(() => ExecuteBatchFile(batFilePath));

                // Read log file and check for errors
                string logFile = await fileControl.ReadFileAsync(logFilePath);
                bool flagResult = true;
                string detailError = string.Empty;
                if (!logFile.Contains("Verification...OK"))
                {
                    detailError = "Verification Fail";
                    flagResult = false;
                }
                else if (!logFile.Contains("Programming Complete."))
                {
                    detailError = "Not Complete";
                    flagResult = false;
                }
                string result = flagResult ? "SUCCESS" : "ERROR";

                // Update UI with result
                lb_resultUpload.Visible = true;
                lb_resultUpload.Text = $"{result}: {detailError}";
                if (flagResult)
                {
                    lb_resultUpload.BackColor = Color.AliceBlue;
                    pgb_upLoad.Value = pgb_upLoad.Maximum - 1;
                }
                else
                {
                    lb_resultUpload.BackColor = Color.AliceBlue;
                    tm_progressBar.Enabled = false;
                    MessageBox.Show(logFile);
                }
            } catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            } finally
            {
                // Delete batch file
                if (File.Exists(batFilePath))
                {
                    fileTxt.TryDeleteFile(batFilePath);
                }
                // Delete Log file
                if (File.Exists(logFilePath))
                {
                    fileTxt.TryDeleteFile(logFilePath);
                }
            }
        }
        private void tm_progressBar_Tick(object sender, EventArgs e) {
            try
            {
                if (pgb_upLoad.Value < pgb_upLoad.Maximum)
                {
                    pgb_upLoad.Value += 1;
                }
                else
                {
                    tm_progressBar.Enabled = false;
                }
            } catch (Exception ex)
            {
                // Handle any exceptions that occur while updating the progress bar value
                MessageBox.Show($"Error updating progress bar value: {ex.Message}");
            }
        }
        private void bt_config_Click(object sender, EventArgs e) {
            formConfig.ShowDialog();
        }
        private void cb_debug_Click(object sender, EventArgs e) {
            try
            {
                // Update the debug flag of the FormConfig with the state of the CheckBox control.
                formConfig.debug = cb_debug.Checked;

                // Save the debug flag to the configuration file.
                fileTxt.EditDetailInFile(fileConfig.nameFile, fileConfig.headDebug, formConfig.debug.ToString());
            } catch (Exception ex)
            {
                // Handle any exceptions that occur and display an error message to the user.
                MessageBox.Show("An error occurred while trying to update the debug flag: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lb_processWait_Click(object sender, EventArgs e) {
            if (!formWaitProcess.Visible)
            {
                formWaitProcess.Show();
                formWaitProcess.Focus();
            }
            else
            {
                if (formWaitProcess.WindowState == FormWindowState.Minimized)
                {
                    formWaitProcess.WindowState = FormWindowState.Normal;
                }
                formWaitProcess.Activate();
            }
        }






        #endregion


    }

}
