using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DryiceProgram.MiniForm {
    public partial class FormConfig : Form {
        private readonly FormStart main;
        public string HexAndPathHex { get; private set; } = "Hex";
        public string PathHex { get; private set; }
        public bool debug { get; set; } = false;
        public bool firmware { get; set; } = true;
        public bool verify { get; set; } = false;
        public bool progComplete { get; set; } = false;
        public bool checkSum { get; set; } = false;

        private readonly Color backgroundColor = Color.FromArgb(255, 192, 192, 255);

        public FormConfig(FormStart main) {
            InitializeComponent();
            this.main = main;

            bt_hex.BackColor = backgroundColor;
            bt_firmware.BackColor = backgroundColor;
            Dictionary<string, List<string>> topics = main.fileTxt.ReadTopicsFromFile(main.fileConfig.nameFile);
            if (topics.TryGetValue(main.fileConfig.head_Hex_PathHex, out List<string> hexAndPathHexValues))
            {
                if (!string.IsNullOrEmpty(hexAndPathHexValues.FirstOrDefault()))
                {
                    HexAndPathHex = hexAndPathHexValues.FirstOrDefault();
                    if (HexAndPathHex == "Path")
                    {
                        bt_hex.BackColor = Color.White;
                        bt_pathAndHex.BackColor = backgroundColor;
                        bt_selectPathHex.Visible = false;
                    }
                }
            }
            if (topics.TryGetValue(main.fileConfig.headPathHex, out List<string> pathHexValues))
            {
                if (!string.IsNullOrEmpty(pathHexValues.FirstOrDefault()))
                {
                    PathHex = pathHexValues.FirstOrDefault();
                    bt_selectPathHex.BackColor = backgroundColor;
                }
            }
            if (topics.TryGetValue(main.fileConfig.headDebug, out List<string> debugConfig) && debugConfig.Any())
            {
                if (bool.TryParse(debugConfig.First(), out bool debugValue))
                {
                    debug = debugValue;
                    main.cb_debug.Checked = debugValue;
                }
            }
            if (topics.TryGetValue(main.fileConfig.headResultFW, out List<string> fwConfig) && fwConfig.Any())
            {
                if (bool.TryParse(fwConfig.First(), out bool fwValue))
                {
                    firmware = fwValue;
                    bt_firmware.BackColor = fwValue ? backgroundColor : Color.White;
                }
            }
            if (topics.TryGetValue(main.fileConfig.headResultVerify, out List<string> veriConfig) && veriConfig.Any())
            {
                if (bool.TryParse(veriConfig.First(), out bool veriValue))
                {
                    verify = veriValue;
                    bt_verify.BackColor = veriValue ? backgroundColor : Color.White;
                }
            }
            if (topics.TryGetValue(main.fileConfig.headResultComplete, out List<string> progConfig) && progConfig.Any())
            {
                if (bool.TryParse(progConfig.First(), out bool progValue))
                {
                    progComplete = progValue;
                    bt_progComplete.BackColor = progValue ? backgroundColor : Color.White;
                }
            }
            if (topics.TryGetValue(main.fileConfig.headResultCSum, out List<string> cSumConfig) && cSumConfig.Any())
            {
                if (bool.TryParse(cSumConfig.First(), out bool cSumValue))
                {
                    checkSum = cSumValue;
                    bt_checkSum.BackColor = cSumValue ? backgroundColor : Color.White;
                }
            }

            // Create a new StringBuilder object to hold the text for the tooltip
            StringBuilder sb = new StringBuilder();

            // Append each line of text to the StringBuilder object
            sb.AppendLine(@"   The program upload process already checks these things.");
            sb.AppendLine(@"   Choose what you want to pack in the result.");
            sb.AppendLine(@"   -Firmware is The 'Firmware' pack is included with the data in the result.");
            sb.AppendLine(@"   -Verification is The 'Verification' pack is included with the data in the result.");
            sb.AppendLine(@"   -Programming Complete is The 'Programming Complete' pack is included with the data in the result.");
            sb.Append(@"   -Check Sum is The 'Check Sum' pack is included with the data in the result.");

            // Set the tooltip for the control (in this case, a button) using the text from the StringBuilder object
            if (tt_result != null && bt_result != null)
            {
                tt_result.SetToolTip(bt_result, sb.ToString());
            }
            bt_result.BackColor = backgroundColor;
        }




        private void bt_pathAndHex_Click(object sender, EventArgs e) {
            try
            {
                main.fileTxt.EditDetailInFile(main.fileConfig.nameFile, main.fileConfig.head_Hex_PathHex, "Path");
                HexAndPathHex = "Path";
                bt_pathAndHex.BackColor = backgroundColor;
                bt_hex.BackColor = Color.White;
                bt_selectPathHex.Visible = false;
            } catch (Exception ex)
            {
                // handle exception here, for example by showing an error message to the user
                MessageBox.Show("An error occurred while editing the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_hex_Click(object sender, EventArgs e) {
            try
            {
                main.fileTxt.EditDetailInFile(main.fileConfig.nameFile, main.fileConfig.head_Hex_PathHex, "Hex");
                HexAndPathHex = "Hex";
                bt_hex.BackColor = backgroundColor;
                bt_pathAndHex.BackColor = Color.White;
                bt_selectPathHex.Visible = true;
            } catch (Exception ex)
            {
                // handle exception here, for example by showing an error message to the user
                MessageBox.Show("An error occurred while editing the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_selectPathHex_Click(object sender, EventArgs e) {
            try
            {
                string pathHex = main.fileControl.FolderGetFullFolder();
                if (!string.IsNullOrEmpty(pathHex))
                {
                    PathHex = pathHex;
                    main.fileTxt.EditDetailInFile(main.fileConfig.nameFile, main.fileConfig.headPathHex, pathHex);
                    bt_selectPathHex.BackColor = backgroundColor;
                }
            } catch (Exception ex)
            {
                // Display an error message if the folder selection fails
                MessageBox.Show("An error occurred while trying to select a folder: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_firmware_Click(object sender, EventArgs e) {
            try
            {
                firmware = !firmware;
                if (!CheckFlagResult())
                {
                    firmware = !firmware;
                    MessageBox.Show("จำเป็นต้องมี Result อย่างน้อย 1 อย่าง ไว้ส่งคืนให้ fMain");
                    return;
                }
                bt_firmware.BackColor = firmware ? backgroundColor : Color.White;

                // Save the firmware flag to the configuration file.
                main.fileTxt.EditDetailInFile(main.fileConfig.nameFile, main.fileConfig.headResultFW, firmware.ToString());
            } catch (Exception ex)
            {
                // Log the exception and display an error message to the user.
                MessageBox.Show("An error occurred while trying to update the firmware flag. Please see the log for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_verify_Click(object sender, EventArgs e) {
            try
            {
                verify = !verify;
                if (!CheckFlagResult())
                {
                    verify = !verify;
                    MessageBox.Show("จำเป็นต้องมี Result อย่างน้อย 1 อย่าง ไว้ส่งคืนให้ fMain");
                    return;
                }
                bt_verify.BackColor = verify ? backgroundColor : Color.White;

                // Save the verify flag to the configuration file.
                main.fileTxt.EditDetailInFile(main.fileConfig.nameFile, main.fileConfig.headResultVerify, verify.ToString());
            } catch (Exception ex)
            {
                // Log the exception and display an error message to the user.
                MessageBox.Show("An error occurred while trying to update the verify flag. Please see the log for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_progComplete_Click(object sender, EventArgs e) {
            try
            {
                progComplete = !progComplete;
                if (!CheckFlagResult())
                {
                    progComplete = !progComplete;
                    MessageBox.Show("จำเป็นต้องมี Result อย่างน้อย 1 อย่าง ไว้ส่งคืนให้ fMain");
                    return;
                }
                bt_progComplete.BackColor = progComplete ? backgroundColor : Color.White;

                // Save the progComplete flag to the configuration file.
                main.fileTxt.EditDetailInFile(main.fileConfig.nameFile, main.fileConfig.headResultComplete, progComplete.ToString());
            } catch (Exception ex)
            {
                // Log the exception and display an error message to the user.
                MessageBox.Show("An error occurred while trying to update the progComplete flag. Please see the log for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_checkSum_Click(object sender, EventArgs e) {
            try
            {
                checkSum = !checkSum;
                if (!CheckFlagResult())
                {
                    checkSum = !checkSum;
                    MessageBox.Show("จำเป็นต้องมี Result อย่างน้อย 1 อย่าง ไว้ส่งคืนให้ fMain");
                    return;
                }
                bt_checkSum.BackColor = checkSum ? backgroundColor : Color.White;

                // Save the checkSum flag to the configuration file.
                main.fileTxt.EditDetailInFile(main.fileConfig.nameFile, main.fileConfig.headResultCSum, checkSum.ToString());
            } catch (Exception ex)
            {
                // Log the exception and display an error message to the user.
                MessageBox.Show("An error occurred while trying to update the checkSum flag. Please see the log for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //บังคับ ต้องมีอย่างน้อย 1 flag ที่เป็น true
        private bool CheckFlagResult() {
            if (!firmware & !verify & !progComplete & !checkSum)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }


}
