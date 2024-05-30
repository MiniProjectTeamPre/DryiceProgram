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
    public partial class FormWaitProcess : Form {
        public FormWaitProcess(FormStart main) {
            InitializeComponent();
            this.main = main;
        }

        private FormStart main;


        /// <summary>
        /// Clears the rich text box and displays the contents of the form queue.
        /// </summary>
        public void Display() {
            try
            {
                rtb_waitProcess?.Clear();
                if (main?.formQueue == null)
                    return;

                StringBuilder sb = new StringBuilder();
                foreach (FormUpload formSup in main.formQueue.ToArray())
                {
                    if (formSup == null)
                        continue;
                    sb.Append($"Programming {formSup.head}, ");
                    sb.Append($"ST-Link : {formSup.stLink}");
                    sb.AppendLine(); // Append a new line
                }
                Print(sb.ToString());
            } catch (Exception ex)
            {
                Console.WriteLine($"Error in Display(): {ex}");
                // Handle the exception as appropriate for your application
            }
        }


        /// <summary>
        /// Appends a message to the RichTextBox control in a thread-safe manner.
        /// </summary>
        /// <param name="message">The message to be appended to the RichTextBox control.</param>
        private void Print(string message) {
            try
            {
                if (rtb_waitProcess == null)
                    return;

                if (rtb_waitProcess.InvokeRequired)
                {
                    rtb_waitProcess.Invoke(new Action<string>(Print), message);
                }
                else
                {
                    rtb_waitProcess.SelectedText = string.Empty;
                    rtb_waitProcess.AppendText(message);
                    rtb_waitProcess.ScrollToCaret();
                }
            } catch (Exception ex)
            {
                MessageBox.Show($"Error in Print(): {ex}");
                // Handle the exception as appropriate for your application
            }
        }



        private void FormWaitProcess_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            this.Hide();
        }
    }
}
