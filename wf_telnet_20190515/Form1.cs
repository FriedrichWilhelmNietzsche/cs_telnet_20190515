using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace wf_telnet_20190515
{
    public partial class Form1 : Form
    {
        public static NetworkStream stream;
        public static TcpClient tcpclient;
        //private readonly int BuffSize = 1024 * 4;

        private bool isDeviceConnected = false;


        //Device Connect state 
        public bool IsDeviceConnected
        {
            get { return isDeviceConnected; }
            set
            {
                isDeviceConnected = value;
                if (isDeviceConnected)
                {
                    ShowStatusBar("The device is connected !!", true);
                    btnConnect.Text = "Disconnect";
                    ToggleControls(true);
                }
                else
                {
                    tcpclient.Close();
                    ShowStatusBar("The device is diconnected !!", true);
                    btnConnect.Text = "Connect";
                    ToggleControls(false);
                }
            }
        }

        //ToggleControls
        private void ToggleControls(bool value)
        {
            btnDeviceInfo.Enabled = value;
            btnGetONU.Enabled = value;
            btnGetLoid.Enabled = value;
            btnGetFPGAVersion.Enabled = value;
            btnUpgradeGPON.Enabled = value;
            btnUpgradeEPON.Enabled = value;
            btnLogData.Enabled = value;
            btnRestartDevice.Enabled = value;
            btnLogin.Enabled = value;
            //btnAbout.Enabled = value;
            btnSendCommand.Enabled = value;
            tbxSendCommand.Enabled = value;
            tbxPort.Enabled = !value;
            tbxDeviceIP.Enabled = !value;
            tbxLogin.Enabled = !value;
            tbxPassword.Enabled = !value;
            // Color.FromArgb(204, 204, 204)
            rtbShowInfo.BackColor = Color.FromArgb(204, 204, 204);
            //tbxSendCommand.BackColor = Color.FromArgb(245, 245, 243);
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        { UniversalStatic.DrawLineInFooter(pnlHeader, Color.FromArgb(204, 204, 204), 2); }

        //Communication
        //public Communication commu;


        public Form1()
        {
            InitializeComponent();
            ToggleControls(false);
            ShowStatusBar(string.Empty, true);
            //DisplayEmpty();

        }

        //private void RaiseDeviceEvent(object sender, string actionType)
        //{
        //    switch (actionType)
        //    {
        //        case UniversalStatic.acx_Disconnect:
        //            {
        //                ShowStatusBar("The device is switched off", true);
        //                // DisplayEmpty();
        //                btnConnect.Text = "Connect";
        //                ToggleControls(false);
        //                break;
        //            }

        //        default:
        //            break;
        //    }

        //}

        public void ShowStatusBar(string message, bool type)
        {
            if (message.Trim() == string.Empty)
            {
                lblStatus.Visible = false;
                return;
            }

            lblStatus.Visible = true;
            lblStatus.Text = message;
            lblStatus.ForeColor = Color.White;

            if (type) { 
                lblStatus.BackColor = Color.FromArgb(79, 208, 154);
            lblHeader.ForeColor = Color.FromArgb(79, 208, 154); }
            else
            {
                lblStatus.BackColor = Color.FromArgb(230, 112, 134);
                lblHeader.ForeColor = Color.FromArgb(230, 112, 134);
            }

        }
       
        //btnConnect_Click
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ShowStatusBar(string.Empty, true);

                if (IsDeviceConnected)
                {
                    IsDeviceConnected = false;
                    this.Cursor = Cursors.Default;

                    return;
                }

                string ipAddress = tbxDeviceIP.Text.Trim();
                string port = tbxPort.Text.Trim();
                string login = tbxLogin.Text.Trim();
                string password = tbxPassword.Text.Trim();
                if (ipAddress == string.Empty || port == string.Empty || login == string.Empty || password == string.Empty)
                    throw new Exception("The Device IP Port Login and Password is mandotory !!");

                //int portNumber = 23;
                //if (!int.TryParse(port, out portNumber))
                //    throw new Exception("Not a valid port number");

                bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
                if (!isValidIpA)
                    throw new Exception("The Device IP is invalid !!");

                isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
                if (!isValidIpA)
                    throw new Exception("The device at " + ipAddress + ":" + port + " did not respond!!");

                tcpclient = new TcpClient(ipAddress, int.Parse(port));  // connect server
                stream = tcpclient.GetStream();   // get net stream
                IsDeviceConnected = true;
           
            //objZkeeper = new ZkemClient(RaiseDeviceEvent);
            //IsDeviceConnected = objZkeeper.Connect_Net(ipAddress, portNumber);
            //string result = string.Empty;
            if (IsDeviceConnected)
            {
                        
            }
            }
            catch (Exception ex)
            {
                ShowStatusBar(ex.Message, false);
                //rtbShowInfo.Text += "Device has been connected, and connot be connected twice at one time!!";
            }
            this.Cursor = Cursors.Default;
            Thread.Sleep(200);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Thread.Sleep(500);
            string ipAddress = tbxDeviceIP.Text.Trim();
            string port = tbxPort.Text.Trim();
            string login = tbxLogin.Text.Trim();
            string password = tbxPassword.Text.Trim();
            try
            {
                tcpclient = new TcpClient(ipAddress, int.Parse(port));  // connect device
                stream = tcpclient.GetStream();   // get net stream
                Byte[] output = new Byte[1024];
                String responseoutput = String.Empty;
                Byte[] cmd = System.Text.Encoding.ASCII.GetBytes(""); //"\n"
                stream.Write(cmd, 0, cmd.Length);

                Thread.Sleep(100);
                Int32 bytes = stream.Read(output, 0, output.Length);
                responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
                rtbShowInfo.Text += responseoutput;

                Regex objToMatch = new Regex("Login:");
                if (objToMatch.IsMatch(responseoutput))
                {
                    cmd = System.Text.Encoding.ASCII.GetBytes(login + "\r\n");
                    stream.Write(cmd, 0, cmd.Length);
                }
                Thread.Sleep(100);
                bytes = stream.Read(output, 0, output.Length);
                responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
                rtbShowInfo.Text += responseoutput;

                objToMatch = new Regex("Passwd:");
                if (objToMatch.IsMatch(responseoutput))
                {
                    cmd = System.Text.Encoding.ASCII.GetBytes(password + "\r\n");
                    stream.Write(cmd, 0, cmd.Length);
                }
                Thread.Sleep(100);
                bytes = stream.Read(output, 0, output.Length);
                responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
                rtbShowInfo.Text += responseoutput;

                objToMatch = new Regex("-->");
                if (objToMatch.IsMatch(responseoutput))
                {
                    cmd = System.Text.Encoding.ASCII.GetBytes("get device info" + "\r\n");
                    stream.Write(cmd, 0, cmd.Length);
                }
                Thread.Sleep(100);
                bytes = stream.Read(output, 0, output.Length);
                responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
                rtbShowInfo.Text += responseoutput;
                //  tcpclient.Close();
            }
            catch { }
        }

        //Ping
        private void btnPingDevice_Click(object sender, EventArgs e)
        {
            ShowStatusBar(string.Empty, true);

            string ipAddress = tbxDeviceIP.Text.Trim();

            bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
            if (!isValidIpA)
                throw new Exception("The Device IP is invalid !!");

            isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
            if (isValidIpA)
                ShowStatusBar("The device is active", true);
            else
                ShowStatusBar("Could not read any response", false);

        }


        //get device info 获取当前板卡版本信息，温度，ip，mac，sn，pn等
        private void btn_DeviceInfo_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            Byte[] output = new Byte[1024];
            String responseoutput = String.Empty;
            Byte[] cmd = System.Text.Encoding.ASCII.GetBytes("\n");
            stream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            cmd = System.Text.Encoding.ASCII.GetBytes("get device info" + "\r");
            stream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            Int32 bytes = stream.Read(output, 0, output.Length);
            responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
            rtbShowInfo.Text += responseoutput;
        }

            //get pon0_valid_onu  获取当前链路里上行ONU的sn和onu id
            private void btnGetONU_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            Byte[] output = new Byte[1024];
            String responseoutput = String.Empty;
            Byte[] cmd = System.Text.Encoding.ASCII.GetBytes("\n");
            stream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            cmd = System.Text.Encoding.ASCII.GetBytes("get pon0_valid_onu" + "\r");
            stream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            Int32 bytes = stream.Read(output, 0, output.Length);
            responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
            rtbShowInfo.Text += responseoutput;

        }

            

        //get loid_pwd_rssi 获取当前链路里loid,password,sn-passwd,rssi的相关信息
        private void btnGetLoid_Click(object sender, EventArgs e)
        {
            Byte[] output = new Byte[1024];
            String responseoutput = String.Empty;
            Byte[] cmd = System.Text.Encoding.ASCII.GetBytes("\n");
            stream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);            
            cmd = System.Text.Encoding.ASCII.GetBytes("get loid_pwd_rssi" + "\r");
            stream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            Int32 bytes = stream.Read(output, 0, output.Length);
            responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
            rtbShowInfo.Text += responseoutput;
        }

        //spi read 0查看FPGA版本
        private void btnGetFPGAVersion_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            Byte[] output = new Byte[1024];
            String responseoutput = String.Empty;
            Byte[] cmd = System.Text.Encoding.ASCII.GetBytes("\n");
            stream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            cmd = System.Text.Encoding.ASCII.GetBytes("spi read 0" + "\r");
            stream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            Int32 bytes = stream.Read(output, 0, output.Length);
            responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
            rtbShowInfo.Text += responseoutput;
        }

        //upgrade fpga tftp 192.168.1.x top.bin 更新FPGA版本，192.168.1.x为PC的ip，
        //更新完版本后通过system restart重启设备
        //upgrade fpga gpon tftp 192.168.1.88 top.bin           //gpon升级
        private void btnUpgradeGPON_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            Byte[] output = new Byte[1024];
            String responseoutput = String.Empty;
            Byte[] cmd = System.Text.Encoding.ASCII.GetBytes("\n");
            stream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            cmd = System.Text.Encoding.ASCII.GetBytes("upgrade fpga gpon tftp 192.168.1.88 top.bin" + "\r");
            stream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            Int32 bytes = stream.Read(output, 0, output.Length);
            responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
            rtbShowInfo.Text += responseoutput;
        }

        //upgrade fpga epon tftp 192.168.1.88 top.bin             //epon升级
        private void btnUpgradeEPON_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            Byte[] output = new Byte[1024];
            String responseoutput = String.Empty;
            Byte[] cmd = System.Text.Encoding.ASCII.GetBytes("\n");
            stream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            cmd = System.Text.Encoding.ASCII.GetBytes("upgrade fpga epon tftp 192.168.1.88 top.bin" + "\r");
            stream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            Int32 bytes = stream.Read(output, 0, output.Length);
            responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
            rtbShowInfo.Text += responseoutput;
        }

        //set uart1_debug enable 打开串口打印信息
        private void btnLogData_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            Byte[] output = new Byte[1024];
            String responseoutput = String.Empty;
            Byte[] cmd = System.Text.Encoding.ASCII.GetBytes("\n");
            stream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            cmd = System.Text.Encoding.ASCII.GetBytes("set uart1_debug enable" + "\r");
            stream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            Int32 bytes = stream.Read(output, 0, output.Length);
            responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
            rtbShowInfo.Text += responseoutput;
        }

        //system restart重启设备
        private void btnRestartDevice_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            Byte[] output = new Byte[1024];
            String responseoutput = String.Empty;
            Byte[] cmd = System.Text.Encoding.ASCII.GetBytes("\n");
            stream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            cmd = System.Text.Encoding.ASCII.GetBytes("system restart" + "\r");
            stream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            Int32 bytes = stream.Read(output, 0, output.Length);
            responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
            rtbShowInfo.Text += responseoutput;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            Form_About form = new Form_About();
            form.Show();
        }

        private void btnSendCommand_Click(object sender, EventArgs e)
        {
            string SendCommand = tbxSendCommand.Text.Trim();
            Thread.Sleep(100);
            Byte[] output = new Byte[1024];
            String responseoutput = String.Empty;
            Byte[] cmd = System.Text.Encoding.ASCII.GetBytes("\n");
            stream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            cmd = System.Text.Encoding.ASCII.GetBytes(SendCommand + "\r");
            stream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            Int32 bytes = stream.Read(output, 0, output.Length);
            responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
            rtbShowInfo.Text += responseoutput;
        }
    }
}
