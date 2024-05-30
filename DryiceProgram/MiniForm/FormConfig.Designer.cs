namespace DryiceProgram.MiniForm {
    partial class FormConfig {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_selectPathHex = new System.Windows.Forms.Button();
            this.bt_hex = new System.Windows.Forms.Button();
            this.bt_pathAndHex = new System.Windows.Forms.Button();
            this.bt_result = new System.Windows.Forms.Button();
            this.bt_verify = new System.Windows.Forms.Button();
            this.bt_progComplete = new System.Windows.Forms.Button();
            this.bt_checkSum = new System.Windows.Forms.Button();
            this.bt_firmware = new System.Windows.Forms.Button();
            this.tt_result = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.bt_firmware);
            this.groupBox1.Controls.Add(this.bt_checkSum);
            this.groupBox1.Controls.Add(this.bt_progComplete);
            this.groupBox1.Controls.Add(this.bt_verify);
            this.groupBox1.Controls.Add(this.bt_result);
            this.groupBox1.Controls.Add(this.bt_selectPathHex);
            this.groupBox1.Controls.Add(this.bt_hex);
            this.groupBox1.Controls.Add(this.bt_pathAndHex);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 560);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // bt_selectPathHex
            // 
            this.bt_selectPathHex.BackColor = System.Drawing.Color.White;
            this.bt_selectPathHex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_selectPathHex.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_selectPathHex.Location = new System.Drawing.Point(203, 150);
            this.bt_selectPathHex.Name = "bt_selectPathHex";
            this.bt_selectPathHex.Size = new System.Drawing.Size(144, 48);
            this.bt_selectPathHex.TabIndex = 2;
            this.bt_selectPathHex.Text = "Select Path";
            this.bt_selectPathHex.UseVisualStyleBackColor = false;
            this.bt_selectPathHex.Click += new System.EventHandler(this.bt_selectPathHex_Click);
            // 
            // bt_hex
            // 
            this.bt_hex.BackColor = System.Drawing.Color.White;
            this.bt_hex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_hex.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_hex.Location = new System.Drawing.Point(233, 65);
            this.bt_hex.Name = "bt_hex";
            this.bt_hex.Size = new System.Drawing.Size(86, 48);
            this.bt_hex.TabIndex = 1;
            this.bt_hex.Text = "Hex";
            this.bt_hex.UseVisualStyleBackColor = false;
            this.bt_hex.Click += new System.EventHandler(this.bt_hex_Click);
            // 
            // bt_pathAndHex
            // 
            this.bt_pathAndHex.BackColor = System.Drawing.Color.White;
            this.bt_pathAndHex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_pathAndHex.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_pathAndHex.Location = new System.Drawing.Point(38, 65);
            this.bt_pathAndHex.Name = "bt_pathAndHex";
            this.bt_pathAndHex.Size = new System.Drawing.Size(158, 48);
            this.bt_pathAndHex.TabIndex = 0;
            this.bt_pathAndHex.Text = "Path + Hex";
            this.bt_pathAndHex.UseVisualStyleBackColor = false;
            this.bt_pathAndHex.Click += new System.EventHandler(this.bt_pathAndHex_Click);
            // 
            // bt_result
            // 
            this.bt_result.BackColor = System.Drawing.Color.White;
            this.bt_result.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_result.Location = new System.Drawing.Point(434, 386);
            this.bt_result.Name = "bt_result";
            this.bt_result.Size = new System.Drawing.Size(90, 48);
            this.bt_result.TabIndex = 3;
            this.bt_result.Text = "Result";
            this.bt_result.UseVisualStyleBackColor = false;
            // 
            // bt_verify
            // 
            this.bt_verify.BackColor = System.Drawing.Color.White;
            this.bt_verify.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_verify.Location = new System.Drawing.Point(238, 489);
            this.bt_verify.Name = "bt_verify";
            this.bt_verify.Size = new System.Drawing.Size(158, 48);
            this.bt_verify.TabIndex = 4;
            this.bt_verify.Text = "Verification";
            this.bt_verify.UseVisualStyleBackColor = false;
            this.bt_verify.Click += new System.EventHandler(this.bt_verify_Click);
            // 
            // bt_progComplete
            // 
            this.bt_progComplete.BackColor = System.Drawing.Color.White;
            this.bt_progComplete.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_progComplete.Location = new System.Drawing.Point(431, 489);
            this.bt_progComplete.Name = "bt_progComplete";
            this.bt_progComplete.Size = new System.Drawing.Size(276, 48);
            this.bt_progComplete.TabIndex = 5;
            this.bt_progComplete.Text = "Programming Complete";
            this.bt_progComplete.UseVisualStyleBackColor = false;
            this.bt_progComplete.Click += new System.EventHandler(this.bt_progComplete_Click);
            // 
            // bt_checkSum
            // 
            this.bt_checkSum.BackColor = System.Drawing.Color.White;
            this.bt_checkSum.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_checkSum.Location = new System.Drawing.Point(745, 489);
            this.bt_checkSum.Name = "bt_checkSum";
            this.bt_checkSum.Size = new System.Drawing.Size(158, 48);
            this.bt_checkSum.TabIndex = 6;
            this.bt_checkSum.Text = "Check Sum";
            this.bt_checkSum.UseVisualStyleBackColor = false;
            this.bt_checkSum.Click += new System.EventHandler(this.bt_checkSum_Click);
            // 
            // bt_firmware
            // 
            this.bt_firmware.BackColor = System.Drawing.Color.White;
            this.bt_firmware.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_firmware.Location = new System.Drawing.Point(44, 489);
            this.bt_firmware.Name = "bt_firmware";
            this.bt_firmware.Size = new System.Drawing.Size(158, 48);
            this.bt_firmware.TabIndex = 7;
            this.bt_firmware.Text = "Firmware";
            this.bt_firmware.UseVisualStyleBackColor = false;
            this.bt_firmware.Click += new System.EventHandler(this.bt_firmware_Click);
            // 
            // tt_result
            // 
            this.tt_result.AutoPopDelay = 15000;
            this.tt_result.InitialDelay = 500;
            this.tt_result.ReshowDelay = 100;
            this.tt_result.Tag = "";
            this.tt_result.ToolTipTitle = "     Detail";
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(968, 584);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormConfig";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_pathAndHex;
        private System.Windows.Forms.Button bt_selectPathHex;
        private System.Windows.Forms.Button bt_hex;
        private System.Windows.Forms.Button bt_verify;
        private System.Windows.Forms.Button bt_result;
        private System.Windows.Forms.Button bt_progComplete;
        private System.Windows.Forms.Button bt_checkSum;
        private System.Windows.Forms.Button bt_firmware;
        private System.Windows.Forms.ToolTip tt_result;
    }
}