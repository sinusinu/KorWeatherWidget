
namespace WeatherWidget {
    partial class WidgetWindow {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WidgetWindow));
            this.lblLocation = new System.Windows.Forms.Label();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.bwDataUpdater = new System.ComponentModel.BackgroundWorker();
            this.tmrUpdateInvoker = new System.Windows.Forms.Timer(this.components);
            this.ttLastUpdateTimeTeller = new System.Windows.Forms.ToolTip(this.components);
            this.csmContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmCopyright = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLocationDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.tspSep = new System.Windows.Forms.ToolStripSeparator();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.csmContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLocation
            // 
            this.lblLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblLocation.Location = new System.Drawing.Point(14, 9);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(327, 51);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "데이터 받아오는 중";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLocation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlsMouseDown);
            // 
            // pbxIcon
            // 
            this.pbxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbxIcon.Image")));
            this.pbxIcon.Location = new System.Drawing.Point(350, 9);
            this.pbxIcon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(48, 48);
            this.pbxIcon.TabIndex = 1;
            this.pbxIcon.TabStop = false;
            this.ttLastUpdateTimeTeller.SetToolTip(this.pbxIcon, "마지막 업데이트: 2021년 6월 22일 오후 10:20");
            this.pbxIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlsMouseDown);
            // 
            // lblTemperature
            // 
            this.lblTemperature.BackColor = System.Drawing.Color.Transparent;
            this.lblTemperature.Font = new System.Drawing.Font("나눔바른고딕", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTemperature.Location = new System.Drawing.Point(406, 12);
            this.lblTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(127, 23);
            this.lblTemperature.TabIndex = 2;
            this.lblTemperature.Text = "0.0℃";
            this.lblTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTemperature.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlsMouseDown);
            // 
            // lblText
            // 
            this.lblText.BackColor = System.Drawing.Color.Transparent;
            this.lblText.Font = new System.Drawing.Font("나눔바른고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblText.Location = new System.Drawing.Point(407, 38);
            this.lblText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(126, 18);
            this.lblText.TabIndex = 3;
            this.lblText.Text = "맑음";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlsMouseDown);
            // 
            // bwDataUpdater
            // 
            this.bwDataUpdater.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDataUpdater_DoWork);
            this.bwDataUpdater.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwDataUpdater_RunWorkerCompleted);
            // 
            // tmrUpdateInvoker
            // 
            this.tmrUpdateInvoker.Enabled = true;
            this.tmrUpdateInvoker.Interval = 60000;
            this.tmrUpdateInvoker.Tick += new System.EventHandler(this.tmrUpdateInvoker_Tick);
            // 
            // ttLastUpdateTimeTeller
            // 
            this.ttLastUpdateTimeTeller.ShowAlways = true;
            // 
            // csmContextMenu
            // 
            this.csmContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCopyright,
            this.tsmLocationDisplay,
            this.tspSep,
            this.tsmExit});
            this.csmContextMenu.Name = "csmContextMenu";
            this.csmContextMenu.Size = new System.Drawing.Size(144, 76);
            // 
            // tsmCopyright
            // 
            this.tsmCopyright.Enabled = false;
            this.tsmCopyright.Name = "tsmCopyright";
            this.tsmCopyright.Size = new System.Drawing.Size(143, 22);
            this.tsmCopyright.Text = "© 2021 sinu";
            // 
            // tsmLocationDisplay
            // 
            this.tsmLocationDisplay.Checked = true;
            this.tsmLocationDisplay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmLocationDisplay.Name = "tsmLocationDisplay";
            this.tsmLocationDisplay.Size = new System.Drawing.Size(143, 22);
            this.tsmLocationDisplay.Text = "위치 표시(&D)";
            this.tsmLocationDisplay.Click += new System.EventHandler(this.tsmLocationDisplay_Click);
            // 
            // tspSep
            // 
            this.tspSep.Name = "tspSep";
            this.tspSep.Size = new System.Drawing.Size(140, 6);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(143, 22);
            this.tsmExit.Text = "닫기(&X)";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // frmWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(549, 69);
            this.ControlBox = false;
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblTemperature);
            this.Controls.Add(this.pbxIcon);
            this.Controls.Add(this.lblLocation);
            this.Font = new System.Drawing.Font("나눔바른고딕", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmWidget";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "날씨";
            this.Activated += new System.EventHandler(this.frmWidget_Activated);
            this.Load += new System.EventHandler(this.frmWidget_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmWidget_MouseDown);
            this.Resize += new System.EventHandler(this.frmWidget_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.csmContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.PictureBox pbxIcon;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.Label lblText;
        private System.ComponentModel.BackgroundWorker bwDataUpdater;
        private System.Windows.Forms.Timer tmrUpdateInvoker;
        private System.Windows.Forms.ToolTip ttLastUpdateTimeTeller;
        private System.Windows.Forms.ContextMenuStrip csmContextMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmCopyright;
        private System.Windows.Forms.ToolStripSeparator tspSep;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmLocationDisplay;
    }
}

