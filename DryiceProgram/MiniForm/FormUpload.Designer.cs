namespace DryiceProgram {
    partial class FormUpload {
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
            this.lb_head = new System.Windows.Forms.Label();
            this.pgb_upLoad = new System.Windows.Forms.ProgressBar();
            this.lb_result = new System.Windows.Forms.Label();
            this.ctms_close = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lb_stLink = new System.Windows.Forms.Label();
            this.lb_hex = new System.Windows.Forms.Label();
            this.bt_viewStatus = new System.Windows.Forms.Button();
            this.tm_progressbar = new System.Windows.Forms.Timer(this.components);
            this.tc_show = new System.Windows.Forms.TabControl();
            this.tp_upload = new System.Windows.Forms.TabPage();
            this.tp_waitAck = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.ctms_close2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctms_close2_ = new System.Windows.Forms.ToolStripMenuItem();
            this.lb_headWaitAck = new System.Windows.Forms.Label();
            this.ctms_close.SuspendLayout();
            this.tc_show.SuspendLayout();
            this.tp_upload.SuspendLayout();
            this.tp_waitAck.SuspendLayout();
            this.ctms_close2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_head
            // 
            this.lb_head.AutoSize = true;
            this.lb_head.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_head.Location = new System.Drawing.Point(6, 5);
            this.lb_head.Name = "lb_head";
            this.lb_head.Size = new System.Drawing.Size(120, 21);
            this.lb_head.TabIndex = 0;
            this.lb_head.Text = "Programming 1";
            // 
            // pgb_upLoad
            // 
            this.pgb_upLoad.Location = new System.Drawing.Point(10, 79);
            this.pgb_upLoad.Name = "pgb_upLoad";
            this.pgb_upLoad.Size = new System.Drawing.Size(612, 10);
            this.pgb_upLoad.TabIndex = 1;
            // 
            // lb_result
            // 
            this.lb_result.ContextMenuStrip = this.ctms_close;
            this.lb_result.Cursor = System.Windows.Forms.Cursors.Default;
            this.lb_result.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_result.Location = new System.Drawing.Point(478, 5);
            this.lb_result.Name = "lb_result";
            this.lb_result.Size = new System.Drawing.Size(144, 33);
            this.lb_result.TabIndex = 2;
            this.lb_result.Text = "Uploading";
            this.lb_result.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctms_close
            // 
            this.ctms_close.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.ctms_close.Name = "ctms_close";
            this.ctms_close.Size = new System.Drawing.Size(104, 26);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // lb_stLink
            // 
            this.lb_stLink.AutoSize = true;
            this.lb_stLink.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_stLink.Location = new System.Drawing.Point(150, 5);
            this.lb_stLink.Name = "lb_stLink";
            this.lb_stLink.Size = new System.Drawing.Size(172, 21);
            this.lb_stLink.TabIndex = 3;
            this.lb_stLink.Text = "ST-Link : 651686168461";
            // 
            // lb_hex
            // 
            this.lb_hex.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_hex.Location = new System.Drawing.Point(6, 33);
            this.lb_hex.Name = "lb_hex";
            this.lb_hex.Size = new System.Drawing.Size(466, 40);
            this.lb_hex.TabIndex = 4;
            this.lb_hex.Text = "Hex : adjldfgrtbrtbfthtyhtyjmnhyhvsd.hex";
            // 
            // bt_viewStatus
            // 
            this.bt_viewStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_viewStatus.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_viewStatus.Location = new System.Drawing.Point(503, 44);
            this.bt_viewStatus.Name = "bt_viewStatus";
            this.bt_viewStatus.Size = new System.Drawing.Size(119, 29);
            this.bt_viewStatus.TabIndex = 5;
            this.bt_viewStatus.Text = "View Detail";
            this.bt_viewStatus.UseVisualStyleBackColor = true;
            this.bt_viewStatus.Click += new System.EventHandler(this.bt_viewStatus_Click);
            // 
            // tm_progressbar
            // 
            this.tm_progressbar.Interval = 250;
            this.tm_progressbar.Tick += new System.EventHandler(this.tm_progressbar_Tick);
            // 
            // tc_show
            // 
            this.tc_show.Controls.Add(this.tp_upload);
            this.tc_show.Controls.Add(this.tp_waitAck);
            this.tc_show.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tc_show.Location = new System.Drawing.Point(0, -19);
            this.tc_show.Name = "tc_show";
            this.tc_show.SelectedIndex = 0;
            this.tc_show.Size = new System.Drawing.Size(648, 122);
            this.tc_show.TabIndex = 6;
            // 
            // tp_upload
            // 
            this.tp_upload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tp_upload.Controls.Add(this.lb_head);
            this.tp_upload.Controls.Add(this.pgb_upLoad);
            this.tp_upload.Controls.Add(this.bt_viewStatus);
            this.tp_upload.Controls.Add(this.lb_result);
            this.tp_upload.Controls.Add(this.lb_hex);
            this.tp_upload.Controls.Add(this.lb_stLink);
            this.tp_upload.Location = new System.Drawing.Point(4, 22);
            this.tp_upload.Name = "tp_upload";
            this.tp_upload.Padding = new System.Windows.Forms.Padding(3);
            this.tp_upload.Size = new System.Drawing.Size(640, 96);
            this.tp_upload.TabIndex = 0;
            this.tp_upload.Text = "tabPage1";
            // 
            // tp_waitAck
            // 
            this.tp_waitAck.ContextMenuStrip = this.ctms_close2;
            this.tp_waitAck.Controls.Add(this.lb_headWaitAck);
            this.tp_waitAck.Controls.Add(this.label1);
            this.tp_waitAck.Location = new System.Drawing.Point(4, 22);
            this.tp_waitAck.Name = "tp_waitAck";
            this.tp_waitAck.Padding = new System.Windows.Forms.Padding(3);
            this.tp_waitAck.Size = new System.Drawing.Size(640, 96);
            this.tp_waitAck.TabIndex = 1;
            this.tp_waitAck.Text = "tabPage2";
            this.tp_waitAck.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(214, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wait Ack ...";
            // 
            // ctms_close2
            // 
            this.ctms_close2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctms_close2_});
            this.ctms_close2.Name = "ctms_close2";
            this.ctms_close2.Size = new System.Drawing.Size(104, 26);
            // 
            // ctms_close2_
            // 
            this.ctms_close2_.Name = "ctms_close2_";
            this.ctms_close2_.Size = new System.Drawing.Size(103, 22);
            this.ctms_close2_.Text = "Close";
            this.ctms_close2_.Click += new System.EventHandler(this.ctms_close2__Click);
            // 
            // lb_headWaitAck
            // 
            this.lb_headWaitAck.AutoSize = true;
            this.lb_headWaitAck.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_headWaitAck.Location = new System.Drawing.Point(11, 7);
            this.lb_headWaitAck.Name = "lb_headWaitAck";
            this.lb_headWaitAck.Size = new System.Drawing.Size(120, 21);
            this.lb_headWaitAck.TabIndex = 1;
            this.lb_headWaitAck.Text = "Programming 1";
            // 
            // FormUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(648, 102);
            this.Controls.Add(this.tc_show);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormUpload";
            this.Text = "FormUpload";
            this.ctms_close.ResumeLayout(false);
            this.tc_show.ResumeLayout(false);
            this.tp_upload.ResumeLayout(false);
            this.tp_upload.PerformLayout();
            this.tp_waitAck.ResumeLayout(false);
            this.tp_waitAck.PerformLayout();
            this.ctms_close2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bt_viewStatus;
        private System.Windows.Forms.ProgressBar pgb_upLoad;
        private System.Windows.Forms.Label lb_result;
        private System.Windows.Forms.Label lb_stLink;
        private System.Windows.Forms.Label lb_hex;
        private System.Windows.Forms.Timer tm_progressbar;
        private System.Windows.Forms.ContextMenuStrip ctms_close;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label lb_head;
        private System.Windows.Forms.TabControl tc_show;
        private System.Windows.Forms.TabPage tp_upload;
        private System.Windows.Forms.TabPage tp_waitAck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip ctms_close2;
        private System.Windows.Forms.ToolStripMenuItem ctms_close2_;
        private System.Windows.Forms.Label lb_headWaitAck;
    }
}