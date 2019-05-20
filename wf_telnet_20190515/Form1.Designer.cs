namespace wf_telnet_20190515
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.tbxDeviceIP = new System.Windows.Forms.TextBox();
            this.tbxLogin = new System.Windows.Forms.TextBox();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.btnPingDevice = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label_bottom = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDeviceInfo = new System.Windows.Forms.Button();
            this.btnGetONU = new System.Windows.Forms.Button();
            this.btnGetLoid = new System.Windows.Forms.Button();
            this.btnGetFPGAVersion = new System.Windows.Forms.Button();
            this.btnUpgradeGPON = new System.Windows.Forms.Button();
            this.btnUpgradeEPON = new System.Windows.Forms.Button();
            this.btnLogData = new System.Windows.Forms.Button();
            this.btnRestartDevice = new System.Windows.Forms.Button();
            this.btnResetAPP = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.tbxSendCommand = new System.Windows.Forms.TextBox();
            this.rtbShowInfo = new System.Windows.Forms.RichTextBox();
            this.pnlHeader.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.tbxPassword);
            this.pnlHeader.Controls.Add(this.tbxDeviceIP);
            this.pnlHeader.Controls.Add(this.tbxLogin);
            this.pnlHeader.Controls.Add(this.tbxPort);
            this.pnlHeader.Controls.Add(this.btnPingDevice);
            this.pnlHeader.Controls.Add(this.label4);
            this.pnlHeader.Controls.Add(this.label3);
            this.pnlHeader.Controls.Add(this.btnConnect);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 37);
            this.pnlHeader.TabIndex = 713;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(374, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Login";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.lblHeader.Location = new System.Drawing.Point(12, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(75, 19);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "FOH-100";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Device IP";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPassword.Location = new System.Drawing.Point(528, 11);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(64, 21);
            this.tbxPassword.TabIndex = 6;
            this.tbxPassword.Text = "admin";
            // 
            // tbxDeviceIP
            // 
            this.tbxDeviceIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDeviceIP.Location = new System.Drawing.Point(175, 11);
            this.tbxDeviceIP.Name = "tbxDeviceIP";
            this.tbxDeviceIP.Size = new System.Drawing.Size(99, 21);
            this.tbxDeviceIP.TabIndex = 0;
            this.tbxDeviceIP.Text = "192.168.1.12";
            // 
            // tbxLogin
            // 
            this.tbxLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxLogin.Location = new System.Drawing.Point(419, 11);
            this.tbxLogin.MaxLength = 6;
            this.tbxLogin.Name = "tbxLogin";
            this.tbxLogin.Size = new System.Drawing.Size(44, 21);
            this.tbxLogin.TabIndex = 8;
            this.tbxLogin.Text = "admin";
            // 
            // tbxPort
            // 
            this.tbxPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPort.Location = new System.Drawing.Point(312, 11);
            this.tbxPort.MaxLength = 6;
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.Size = new System.Drawing.Size(56, 21);
            this.tbxPort.TabIndex = 2;
            this.tbxPort.Text = "23";
            // 
            // btnPingDevice
            // 
            this.btnPingDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPingDevice.Location = new System.Drawing.Point(705, 9);
            this.btnPingDevice.Name = "btnPingDevice";
            this.btnPingDevice.Size = new System.Drawing.Size(75, 23);
            this.btnPingDevice.TabIndex = 5;
            this.btnPingDevice.Text = "Ping Device";
            this.btnPingDevice.UseVisualStyleBackColor = true;
            this.btnPingDevice.Click += new System.EventHandler(this.btnPingDevice_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(469, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Port";
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(624, 9);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(0, 37);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(309, 25);
            this.lblStatus.TabIndex = 714;
            this.lblStatus.Text = "label3";
            // 
            // label_bottom
            // 
            this.label_bottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_bottom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_bottom.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_bottom.Location = new System.Drawing.Point(0, 426);
            this.label_bottom.Margin = new System.Windows.Forms.Padding(3);
            this.label_bottom.Name = "label_bottom";
            this.label_bottom.Size = new System.Drawing.Size(800, 25);
            this.label_bottom.TabIndex = 715;
            this.label_bottom.Text = "Version: 1.0";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.btnDeviceInfo);
            this.flowLayoutPanel1.Controls.Add(this.btnGetONU);
            this.flowLayoutPanel1.Controls.Add(this.btnGetLoid);
            this.flowLayoutPanel1.Controls.Add(this.btnGetFPGAVersion);
            this.flowLayoutPanel1.Controls.Add(this.btnUpgradeGPON);
            this.flowLayoutPanel1.Controls.Add(this.btnUpgradeEPON);
            this.flowLayoutPanel1.Controls.Add(this.btnLogData);
            this.flowLayoutPanel1.Controls.Add(this.btnRestartDevice);
            this.flowLayoutPanel1.Controls.Add(this.btnResetAPP);
            this.flowLayoutPanel1.Controls.Add(this.btnAbout);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 62);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 54);
            this.flowLayoutPanel1.TabIndex = 716;
            // 
            // btnDeviceInfo
            // 
            this.btnDeviceInfo.Location = new System.Drawing.Point(3, 3);
            this.btnDeviceInfo.Name = "btnDeviceInfo";
            this.btnDeviceInfo.Size = new System.Drawing.Size(112, 48);
            this.btnDeviceInfo.TabIndex = 9;
            this.btnDeviceInfo.Text = "Get Device Info";
            this.btnDeviceInfo.UseVisualStyleBackColor = true;
            this.btnDeviceInfo.Click += new System.EventHandler(this.btn_DeviceInfo_Click);
            // 
            // btnGetONU
            // 
            this.btnGetONU.Location = new System.Drawing.Point(121, 3);
            this.btnGetONU.Name = "btnGetONU";
            this.btnGetONU.Size = new System.Drawing.Size(90, 48);
            this.btnGetONU.TabIndex = 10;
            this.btnGetONU.Text = "Get ONU Info";
            this.btnGetONU.UseVisualStyleBackColor = true;
            this.btnGetONU.Click += new System.EventHandler(this.btnGetONU_Click);
            // 
            // btnGetLoid
            // 
            this.btnGetLoid.Location = new System.Drawing.Point(217, 3);
            this.btnGetLoid.Name = "btnGetLoid";
            this.btnGetLoid.Size = new System.Drawing.Size(92, 48);
            this.btnGetLoid.TabIndex = 892;
            this.btnGetLoid.Text = "Get Loid_pwd_rssi";
            this.btnGetLoid.UseVisualStyleBackColor = true;
            this.btnGetLoid.Click += new System.EventHandler(this.btnGetLoid_Click);
            // 
            // btnGetFPGAVersion
            // 
            this.btnGetFPGAVersion.Location = new System.Drawing.Point(315, 3);
            this.btnGetFPGAVersion.Name = "btnGetFPGAVersion";
            this.btnGetFPGAVersion.Size = new System.Drawing.Size(65, 48);
            this.btnGetFPGAVersion.TabIndex = 889;
            this.btnGetFPGAVersion.Text = "Get FPGA Version ";
            this.btnGetFPGAVersion.UseVisualStyleBackColor = true;
            this.btnGetFPGAVersion.Click += new System.EventHandler(this.btnGetFPGAVersion_Click);
            // 
            // btnUpgradeGPON
            // 
            this.btnUpgradeGPON.Location = new System.Drawing.Point(386, 3);
            this.btnUpgradeGPON.Name = "btnUpgradeGPON";
            this.btnUpgradeGPON.Size = new System.Drawing.Size(77, 48);
            this.btnUpgradeGPON.TabIndex = 887;
            this.btnUpgradeGPON.Text = "Upgrade FPGA GPON";
            this.btnUpgradeGPON.UseVisualStyleBackColor = true;
            this.btnUpgradeGPON.Click += new System.EventHandler(this.btnUpgradeGPON_Click);
            // 
            // btnUpgradeEPON
            // 
            this.btnUpgradeEPON.Location = new System.Drawing.Point(469, 3);
            this.btnUpgradeEPON.Name = "btnUpgradeEPON";
            this.btnUpgradeEPON.Size = new System.Drawing.Size(70, 48);
            this.btnUpgradeEPON.TabIndex = 5;
            this.btnUpgradeEPON.Text = "Upgrade FPGA EPON";
            this.btnUpgradeEPON.UseVisualStyleBackColor = true;
            this.btnUpgradeEPON.Click += new System.EventHandler(this.btnUpgradeEPON_Click);
            // 
            // btnLogData
            // 
            this.btnLogData.Location = new System.Drawing.Point(545, 3);
            this.btnLogData.Name = "btnLogData";
            this.btnLogData.Size = new System.Drawing.Size(65, 48);
            this.btnLogData.TabIndex = 890;
            this.btnLogData.Text = "Get Log Data";
            this.btnLogData.UseVisualStyleBackColor = true;
            this.btnLogData.Click += new System.EventHandler(this.btnLogData_Click);
            // 
            // btnRestartDevice
            // 
            this.btnRestartDevice.Location = new System.Drawing.Point(616, 3);
            this.btnRestartDevice.Name = "btnRestartDevice";
            this.btnRestartDevice.Size = new System.Drawing.Size(72, 48);
            this.btnRestartDevice.TabIndex = 886;
            this.btnRestartDevice.Text = "Restart Device";
            this.btnRestartDevice.UseVisualStyleBackColor = true;
            this.btnRestartDevice.Click += new System.EventHandler(this.btnRestartDevice_Click);
            // 
            // btnResetAPP
            // 
            this.btnResetAPP.Location = new System.Drawing.Point(694, 3);
            this.btnResetAPP.Name = "btnResetAPP";
            this.btnResetAPP.Size = new System.Drawing.Size(51, 48);
            this.btnResetAPP.TabIndex = 894;
            this.btnResetAPP.Text = "Reset APP";
            this.btnResetAPP.UseVisualStyleBackColor = true;
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(751, 3);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(43, 48);
            this.btnAbout.TabIndex = 893;
            this.btnAbout.Text = "About ";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendCommand.Location = new System.Drawing.Point(705, 37);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(75, 23);
            this.btnSendCommand.TabIndex = 10;
            this.btnSendCommand.Text = "Send";
            this.btnSendCommand.UseVisualStyleBackColor = true;
            // 
            // tbxSendCommand
            // 
            this.tbxSendCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSendCommand.Location = new System.Drawing.Point(315, 39);
            this.tbxSendCommand.Name = "tbxSendCommand";
            this.tbxSendCommand.Size = new System.Drawing.Size(387, 21);
            this.tbxSendCommand.TabIndex = 717;
            // 
            // rtbShowInfo
            // 
            this.rtbShowInfo.Location = new System.Drawing.Point(135, 187);
            this.rtbShowInfo.Name = "rtbShowInfo";
            this.rtbShowInfo.Size = new System.Drawing.Size(536, 200);
            this.rtbShowInfo.TabIndex = 718;
            this.rtbShowInfo.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbShowInfo);
            this.Controls.Add(this.tbxSendCommand);
            this.Controls.Add(this.btnSendCommand);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label_bottom);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pnlHeader);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxDeviceIP;
        private System.Windows.Forms.TextBox tbxPort;
        private System.Windows.Forms.Button btnPingDevice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label_bottom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.TextBox tbxLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDeviceInfo;
        private System.Windows.Forms.Button btnGetONU;
        private System.Windows.Forms.Button btnGetLoid;
        private System.Windows.Forms.Button btnUpgradeGPON;
        private System.Windows.Forms.Button btnUpgradeEPON;
        private System.Windows.Forms.Button btnLogData;
        private System.Windows.Forms.Button btnRestartDevice;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnGetFPGAVersion;
        private System.Windows.Forms.Button btnSendCommand;
        private System.Windows.Forms.TextBox tbxSendCommand;
        private System.Windows.Forms.Button btnResetAPP;
        private System.Windows.Forms.RichTextBox rtbShowInfo;
    }
}

