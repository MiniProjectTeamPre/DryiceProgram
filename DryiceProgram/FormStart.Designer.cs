namespace DryiceProgram {
    partial class FormStart {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStart));
            this.ntfi_Main = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctms_close = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctms_closeProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.tm_main = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_processWait = new System.Windows.Forms.Label();
            this.lb_resultUpload = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pn_upLoad5 = new System.Windows.Forms.Panel();
            this.pn_upLoad4 = new System.Windows.Forms.Panel();
            this.pn_upLoad3 = new System.Windows.Forms.Panel();
            this.pn_upLoad2 = new System.Windows.Forms.Panel();
            this.cb_debug = new System.Windows.Forms.CheckBox();
            this.bt_config = new System.Windows.Forms.Button();
            this.pgb_upLoad = new System.Windows.Forms.ProgressBar();
            this.bt_upLoad = new System.Windows.Forms.Button();
            this.lb_stLink = new System.Windows.Forms.Label();
            this.bt_stLink = new System.Windows.Forms.Button();
            this.lb_hexFile = new System.Windows.Forms.Label();
            this.bt_hex = new System.Windows.Forms.Button();
            this.pn_upLoad1 = new System.Windows.Forms.Panel();
            this.tm_progressBar = new System.Windows.Forms.Timer(this.components);
            this.ctms_close.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ntfi_Main
            // 
            this.ntfi_Main.ContextMenuStrip = this.ctms_close;
            this.ntfi_Main.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfi_Main.Icon")));
            this.ntfi_Main.Text = "DryiceProgram";
            this.ntfi_Main.Visible = true;
            this.ntfi_Main.DoubleClick += new System.EventHandler(this.ntfi_Main_DoubleClick);
            // 
            // ctms_close
            // 
            this.ctms_close.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctms_closeProgram});
            this.ctms_close.Name = "ctms_close";
            this.ctms_close.Size = new System.Drawing.Size(153, 26);
            // 
            // ctms_closeProgram
            // 
            this.ctms_closeProgram.Name = "ctms_closeProgram";
            this.ctms_closeProgram.Size = new System.Drawing.Size(152, 22);
            this.ctms_closeProgram.Text = "Close Program";
            this.ctms_closeProgram.Click += new System.EventHandler(this.ctms_closeProgram_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1386, 921);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "V2023.01";
            // 
            // tm_main
            // 
            this.tm_main.Tick += new System.EventHandler(this.tm_main_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = global::DryiceProgram.Properties.Resources.Header;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1466, 92);
            this.panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.BackgroundImage = global::DryiceProgram.Properties.Resources.MainGUI;
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox2.Controls.Add(this.lb_processWait);
            this.groupBox2.Controls.Add(this.lb_resultUpload);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.pn_upLoad5);
            this.groupBox2.Controls.Add(this.pn_upLoad4);
            this.groupBox2.Controls.Add(this.pn_upLoad3);
            this.groupBox2.Controls.Add(this.pn_upLoad2);
            this.groupBox2.Controls.Add(this.cb_debug);
            this.groupBox2.Controls.Add(this.bt_config);
            this.groupBox2.Controls.Add(this.pgb_upLoad);
            this.groupBox2.Controls.Add(this.bt_upLoad);
            this.groupBox2.Controls.Add(this.lb_stLink);
            this.groupBox2.Controls.Add(this.bt_stLink);
            this.groupBox2.Controls.Add(this.lb_hexFile);
            this.groupBox2.Controls.Add(this.bt_hex);
            this.groupBox2.Controls.Add(this.pn_upLoad1);
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1466, 800);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // lb_processWait
            // 
            this.lb_processWait.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_processWait.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_processWait.Location = new System.Drawing.Point(1238, 677);
            this.lb_processWait.Name = "lb_processWait";
            this.lb_processWait.Size = new System.Drawing.Size(184, 35);
            this.lb_processWait.TabIndex = 12;
            this.lb_processWait.Text = "Process wait (0)";
            this.lb_processWait.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lb_processWait.Click += new System.EventHandler(this.lb_processWait_Click);
            // 
            // lb_resultUpload
            // 
            this.lb_resultUpload.BackColor = System.Drawing.Color.White;
            this.lb_resultUpload.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_resultUpload.Location = new System.Drawing.Point(66, 687);
            this.lb_resultUpload.Name = "lb_resultUpload";
            this.lb_resultUpload.Size = new System.Drawing.Size(584, 60);
            this.lb_resultUpload.TabIndex = 11;
            this.lb_resultUpload.Text = "Success";
            this.lb_resultUpload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(600, 107);
            this.label4.TabIndex = 10;
            this.label4.Text = "DryIce Programming\r\nSelect Hex File and Number of ST-Link\r\nClick Upload and wait " +
    "to success";
            // 
            // pn_upLoad5
            // 
            this.pn_upLoad5.BackColor = System.Drawing.Color.White;
            this.pn_upLoad5.Location = new System.Drawing.Point(774, 563);
            this.pn_upLoad5.Name = "pn_upLoad5";
            this.pn_upLoad5.Size = new System.Drawing.Size(648, 102);
            this.pn_upLoad5.TabIndex = 9;
            // 
            // pn_upLoad4
            // 
            this.pn_upLoad4.BackColor = System.Drawing.Color.White;
            this.pn_upLoad4.Location = new System.Drawing.Point(774, 455);
            this.pn_upLoad4.Name = "pn_upLoad4";
            this.pn_upLoad4.Size = new System.Drawing.Size(648, 102);
            this.pn_upLoad4.TabIndex = 1;
            // 
            // pn_upLoad3
            // 
            this.pn_upLoad3.BackColor = System.Drawing.Color.White;
            this.pn_upLoad3.Location = new System.Drawing.Point(774, 347);
            this.pn_upLoad3.Name = "pn_upLoad3";
            this.pn_upLoad3.Size = new System.Drawing.Size(648, 102);
            this.pn_upLoad3.TabIndex = 1;
            // 
            // pn_upLoad2
            // 
            this.pn_upLoad2.BackColor = System.Drawing.Color.White;
            this.pn_upLoad2.Location = new System.Drawing.Point(774, 239);
            this.pn_upLoad2.Name = "pn_upLoad2";
            this.pn_upLoad2.Size = new System.Drawing.Size(648, 102);
            this.pn_upLoad2.TabIndex = 1;
            // 
            // cb_debug
            // 
            this.cb_debug.AutoSize = true;
            this.cb_debug.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_debug.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_debug.Location = new System.Drawing.Point(1209, 68);
            this.cb_debug.Name = "cb_debug";
            this.cb_debug.Size = new System.Drawing.Size(96, 34);
            this.cb_debug.TabIndex = 8;
            this.cb_debug.Text = "Debug";
            this.cb_debug.UseVisualStyleBackColor = true;
            this.cb_debug.Click += new System.EventHandler(this.cb_debug_Click);
            // 
            // bt_config
            // 
            this.bt_config.BackgroundImage = global::DryiceProgram.Properties.Resources.Config;
            this.bt_config.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_config.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_config.Location = new System.Drawing.Point(1322, 19);
            this.bt_config.Name = "bt_config";
            this.bt_config.Size = new System.Drawing.Size(100, 83);
            this.bt_config.TabIndex = 7;
            this.bt_config.UseVisualStyleBackColor = true;
            this.bt_config.Click += new System.EventHandler(this.bt_config_Click);
            // 
            // pgb_upLoad
            // 
            this.pgb_upLoad.Location = new System.Drawing.Point(55, 677);
            this.pgb_upLoad.Name = "pgb_upLoad";
            this.pgb_upLoad.Size = new System.Drawing.Size(604, 80);
            this.pgb_upLoad.TabIndex = 6;
            // 
            // bt_upLoad
            // 
            this.bt_upLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_upLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_upLoad.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_upLoad.Location = new System.Drawing.Point(55, 627);
            this.bt_upLoad.Name = "bt_upLoad";
            this.bt_upLoad.Size = new System.Drawing.Size(604, 44);
            this.bt_upLoad.TabIndex = 5;
            this.bt_upLoad.Text = "Upload                                                                       ";
            this.bt_upLoad.UseVisualStyleBackColor = false;
            this.bt_upLoad.Click += new System.EventHandler(this.bt_upLoad_Click);
            // 
            // lb_stLink
            // 
            this.lb_stLink.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_stLink.Location = new System.Drawing.Point(50, 503);
            this.lb_stLink.Name = "lb_stLink";
            this.lb_stLink.Size = new System.Drawing.Size(609, 71);
            this.lb_stLink.TabIndex = 4;
            this.lb_stLink.Text = "_____";
            // 
            // bt_stLink
            // 
            this.bt_stLink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_stLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_stLink.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_stLink.Location = new System.Drawing.Point(55, 456);
            this.bt_stLink.Name = "bt_stLink";
            this.bt_stLink.Size = new System.Drawing.Size(604, 44);
            this.bt_stLink.TabIndex = 3;
            this.bt_stLink.Text = "ST-Link                                                                       ";
            this.bt_stLink.UseVisualStyleBackColor = false;
            this.bt_stLink.Click += new System.EventHandler(this.bt_stLink_Click);
            // 
            // lb_hexFile
            // 
            this.lb_hexFile.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_hexFile.Location = new System.Drawing.Point(50, 299);
            this.lb_hexFile.Name = "lb_hexFile";
            this.lb_hexFile.Size = new System.Drawing.Size(600, 107);
            this.lb_hexFile.TabIndex = 2;
            this.lb_hexFile.Text = "_____";
            // 
            // bt_hex
            // 
            this.bt_hex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_hex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_hex.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_hex.Location = new System.Drawing.Point(55, 252);
            this.bt_hex.Name = "bt_hex";
            this.bt_hex.Size = new System.Drawing.Size(604, 44);
            this.bt_hex.TabIndex = 1;
            this.bt_hex.Text = "Hex File                                                                     ";
            this.bt_hex.UseVisualStyleBackColor = false;
            this.bt_hex.Click += new System.EventHandler(this.bt_hex_Click);
            // 
            // pn_upLoad1
            // 
            this.pn_upLoad1.BackColor = System.Drawing.Color.White;
            this.pn_upLoad1.Location = new System.Drawing.Point(774, 131);
            this.pn_upLoad1.Name = "pn_upLoad1";
            this.pn_upLoad1.Size = new System.Drawing.Size(648, 102);
            this.pn_upLoad1.TabIndex = 0;
            // 
            // tm_progressBar
            // 
            this.tm_progressBar.Interval = 250;
            this.tm_progressBar.Tick += new System.EventHandler(this.tm_progressBar_Tick);
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1490, 961);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dryice Program";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStart_FormClosing);
            this.Load += new System.EventHandler(this.FormStart_Load);
            this.Resize += new System.EventHandler(this.FormStart_Resize);
            this.ctms_close.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon ntfi_Main;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tm_main;
        private System.Windows.Forms.ContextMenuStrip ctms_close;
        private System.Windows.Forms.ToolStripMenuItem ctms_closeProgram;
        private System.Windows.Forms.Panel pn_upLoad1;
        private System.Windows.Forms.Button bt_hex;
        private System.Windows.Forms.Button bt_config;
        private System.Windows.Forms.Panel pn_upLoad5;
        private System.Windows.Forms.Panel pn_upLoad4;
        private System.Windows.Forms.Panel pn_upLoad3;
        private System.Windows.Forms.Panel pn_upLoad2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_processWait;
        public System.Windows.Forms.Label lb_stLink;
        public System.Windows.Forms.Label lb_hexFile;
        public System.Windows.Forms.ProgressBar pgb_upLoad;
        public System.Windows.Forms.Button bt_upLoad;
        public System.Windows.Forms.Button bt_stLink;
        public System.Windows.Forms.Label lb_resultUpload;
        private System.Windows.Forms.Timer tm_progressBar;
        public System.Windows.Forms.CheckBox cb_debug;
    }
}

