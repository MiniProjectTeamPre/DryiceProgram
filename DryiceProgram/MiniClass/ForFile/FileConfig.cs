using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DryiceProgram.MiniClass.ForFile {
    public class FileConfig {

        public FileConfig(FormStart main_) {
            main = main_;
        }

        private FormStart main;

        public string nameFile = "Config.txt";
        public string headHexMain = "Path Hex Main";
        public string headStLink = "Name ST-Link";
        public string head_Hex_PathHex = "Hex & PathHex";
        public string headPathHex = "Path Hex";
        public string headDebug = "Debug";

        public string headResultFW = "Result Firmware";
        public string headResultVerify = "Result Verify";
        public string headResultComplete = "Result Program Complete";
        public string headResultCSum = "Result Check Sum";

        public async void CheckFileConfig() {
            main.bt_stLink.Visible = false;
            main.lb_stLink.Visible = false;
            main.bt_upLoad.Visible = false;
            main.pgb_upLoad.Visible = false;
            main.lb_resultUpload.Visible = false;

            const string nameExeStLink = "ST-LINK_CLI.exe";
            string pathExeSt = string.Empty;
            try
            {
                // create a CancellationTokenSource with a timeout of 30 seconds
                using (CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30)))
                {
                    pathExeSt = await Task.Run(() => main.fileControl.GetExePath(nameExeStLink, cancellationTokenSource.Token));
                }

                if (pathExeSt.Contains(nameExeStLink))
                {
                    main.varConfig.pathStLink = pathExeSt;
                }
                else
                {
                    MessageBox.Show("\"ST-LINK_CLI.exe\" could not be found.\r\n" + "Please install STM32 ST-LINK Utility.");
                    return;
                }
            } catch (OperationCanceledException ex)
            {
                MessageBox.Show($"Error getting path to file \"{nameExeStLink}\": {ex.Message}");
                return;
            } catch (Exception ex)
            {
                MessageBox.Show($"Error getting path to file \"{nameExeStLink}\": {ex.Message}");
                return;
            }

            try
            {
                if (!File.Exists(nameFile))
                {
                    // Create the file with some topics and details
                    Dictionary<string, List<string>> topics = new Dictionary<string, List<string>>();
                    topics[headHexMain] = new List<string>() { string.Empty };
                    topics[headStLink] = new List<string>() { string.Empty };
                    topics[head_Hex_PathHex] = new List<string>() { string.Empty };
                    topics[headPathHex] = new List<string>() { string.Empty };
                    topics[headDebug] = new List<string>() { string.Empty };
                    topics[headResultFW] = new List<string>() { string.Empty };
                    topics[headResultVerify] = new List<string>() { string.Empty };
                    topics[headResultComplete] = new List<string>() { string.Empty };
                    topics[headResultCSum] = new List<string>() { string.Empty };
                    main.fileTxt.WriteTopicsToFile(nameFile, topics);
                }
                else
                {
                    // Read the file and display its contents again
                    Dictionary<string, List<string>> topics = main.fileTxt.ReadTopicsFromFile(nameFile);
                    if (topics.ContainsKey(headHexMain))
                    {
                        if (File.Exists(topics[headHexMain][0]))
                        {
                            main.lb_hexFile.Text = topics[headHexMain][0].Replace("\\", "/");
                            main.varConfig.hexMain = topics[headHexMain][0];
                            main.bt_stLink.Visible = true;
                            main.lb_stLink.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show($"File {topics[headHexMain][0]} could not be found.");
                            return;
                        }
                    }

                    if (topics.ContainsKey(headStLink))
                    {
                        if (!string.IsNullOrEmpty(topics[headStLink][0]))
                        {
                            main.lb_stLink.Text = topics[headStLink][0];
                            main.varConfig.stLinkMain = topics[headStLink][0];
                            main.bt_upLoad.Visible = true;
                            main.pgb_upLoad.Visible = true;
                        }
                    }
                }
            } catch (Exception ex)
            {
                // Handle the exception
                MessageBox.Show($"Error checking file: {ex.Message}");
            }
        }




    }
}
