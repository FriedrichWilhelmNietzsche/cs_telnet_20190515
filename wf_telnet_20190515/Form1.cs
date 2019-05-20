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
        private readonly int BuffSize = 1024 * 4;

        private bool isDeviceConnected = false;

        //telnet protocol
        enum Verbs
        {
            WILL = 251, WONT = 252, DO = 253, DONT = 254, IAC = 255
        }
        enum Options
        {
            RD = 1, SGA = 3
        }

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
            btnResetAPP.Enabled = value;
            btnAbout.Enabled = value;
            btnSendCommand.Enabled = value;
            tbxSendCommand.Enabled = value;
            tbxPort.Enabled = !value;
            tbxDeviceIP.Enabled = !value;
            tbxLogin.Enabled = !value;
            tbxPassword.Enabled = !value;
        }

        public Form1()
        {
            InitializeComponent();
            ToggleControls(false);
            ShowStatusBar(string.Empty, true);
            //DisplayEmpty();
        }

        private void RaiseDeviceEvent(object sender, string actionType)
        {
            switch (actionType)
            {
                case UniversalStatic.acx_Disconnect:
                    {
                        ShowStatusBar("The device is switched off", true);
                        // DisplayEmpty();
                        btnConnect.Text = "Connect";
                        ToggleControls(false);
                        break;
                    }

                default:
                    break;
            }

        }

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

            if (type)
                lblStatus.BackColor = Color.FromArgb(79, 208, 154);

            else
                lblStatus.BackColor = Color.FromArgb(230, 112, 134);
        }


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
                    // string deviceInfo = manipulator.FetchDeviceInfo(objZkeeper, int.Parse(tbxMachineNumber.Text.Trim()));
                    //  lblDeviceInfo.Text = deviceInfo;
                    //  connectHost(login, password);
                    connectHost(login, password);

                }

            }
            catch (Exception ex)
            {
                ShowStatusBar(ex.Message, false);
            }
            this.Cursor = Cursors.Default;

        }

        //login and passwd
        public void connectHost(string user, string passwd)
        {
            StreamWriter sw = new StreamWriter(stream);
            StreamReader sr = new StreamReader(stream);
            while (true)
            {
                try
                {
                    //Read Echo
                    //Set ReadEcho Timeout
                    stream.ReadTimeout = 10;

                    while (true)
                    {
                        char c = (char)sr.Read();
                        if (c < 256)
                        {
                            if (c == 27)
                            {
                                while (sr.Read() != 109) { }
                            }
                            else
                            {
                                Console.Write(c);
                            }
                        }
                    }
                }
                catch
                {
                }
                //Send CMD
                //  sw.Write("{0}\r\n", Console.ReadLine());
                // sw.Flush();

                Byte[] output = new Byte[1024];
                String responseoutput = String.Empty;
                Byte[] cmd = System.Text.Encoding.ASCII.GetBytes("\n");
                //stream.Write(cmd, 0, cmd.Length);

                Thread.Sleep(100);
                Int32 bytes = stream.Read(output, 0, output.Length);
                responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
                rtbShowInfo.Text += responseoutput;
                Regex objToMatch = new Regex("Login:");
                if (objToMatch.IsMatch(responseoutput))
                {
                    cmd = System.Text.Encoding.ASCII.GetBytes(user + "\r\n");
                    //stream.Write(cmd, 0, cmd.Length);
                    sw.Write(cmd);
                    sw.Flush();
                    rtbShowInfo.Text += responseoutput;

                }

                objToMatch = new Regex("Passwd:");
                if (objToMatch.IsMatch(responseoutput))
                {
                    cmd = System.Text.Encoding.ASCII.GetBytes(passwd + "\r\n");
                    sw.Write(cmd);
                    sw.Flush();
                    rtbShowInfo.Text += responseoutput;

                }

                //bool i = true;
                //while (i)  //while (i) 
                //{
                //    //Console.WriteLine("Connecting.....");
                //    Byte[] output = new Byte[1024];
                //    String responseoutput = String.Empty;
                //    Byte[] cmd = System.Text.Encoding.ASCII.GetBytes("\n");
                //    stream.Write(cmd, 0, cmd.Length);

                //    Thread.Sleep(100);
                //    Int32 bytes = stream.Read(output, 0, output.Length);
                //    responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
                //    rtbShowInfo.Text += responseoutput;

                //    Regex objToMatch = new Regex("Login:");
                //    if (objToMatch.IsMatch(responseoutput))
                //    {
                //        cmd = System.Text.Encoding.ASCII.GetBytes(user + "\r\n");
                //        stream.Write(cmd, 0, cmd.Length);
                //    }

                //    Thread.Sleep(100);
                //    bytes = stream.Read(output, 0, output.Length);
                //    responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
                //    rtbShowInfo.Text += responseoutput;

                //    objToMatch = new Regex("Passwd:");
                //    if (objToMatch.IsMatch(responseoutput))
                //    {
                //        cmd = System.Text.Encoding.ASCII.GetBytes(passwd + "\r\n");
                //        stream.Write(cmd, 0, cmd.Length);
                //    }

                //    Thread.Sleep(100);
                //    bytes = stream.Read(output, 0, output.Length);
                //    responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
                //    rtbShowInfo.Text += responseoutput;

                //objToMatch = new Regex("-->");
                //if (objToMatch.IsMatch(responseoutput))
                //{
                //    i = false;
                //        Thread.Sleep(100);

                //        bytes = stream.Read(output, 0, output.Length);
                //        responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
                //        rtbShowInfo.Text += responseoutput;

                //    }

                //}
            }
        }


        //Ping
        private void BtnPingDevice_Click(object sender, EventArgs e)
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

        //read byte stream 
        private byte[] ReceiveBytes()
        {
            byte[] result = new byte[0];
            byte[] buff = new byte[BuffSize];
            int numberOfRead = 0;
            if (IsDeviceConnected && stream.CanRead)
            {
                numberOfRead = stream.Read(buff, 0, BuffSize);
                result = new byte[numberOfRead];
                Array.Copy(buff, result, numberOfRead);
            }
            return result;
        }

        //receive
        public string Receive()
        {
            StringBuilder result = new StringBuilder();
            if (IsDeviceConnected && stream.CanRead)
            {
                byte[] buff = new byte[BuffSize];
                int numberOfRead = 0;
                do
                {
                    numberOfRead = stream.Read(buff, 0, BuffSize);
                    result.AppendFormat("{0}", Encoding.ASCII.GetString(buff, 0, numberOfRead));
                }
                while (stream.DataAvailable);
            }
            return result.ToString().Trim();
        }

        //send
        public void Send(string cmd, int waitTime)
        {
            if (IsDeviceConnected && stream.CanRead)
            {
                cmd += "\r\n";
                byte[] buff = Encoding.ASCII.GetBytes(cmd);
                stream.Write(buff, 0, buff.Length);
                System.Threading.Thread.Sleep(waitTime);
            }
        }


        //get device info 获取当前板卡版本信息，温度，ip，mac，sn，pn等
        private void btn_DeviceInfo_Click(object sender, EventArgs e)
        {

        }

        //get pon0_valid_onu  获取当前链路里上行ONU的sn和onu id
        private void btnGetONU_Click(object sender, EventArgs e)
        {

        }

        //get loid_pwd_rssi 获取当前链路里loid,password,sn-passwd,rssi的相关信息
        private void btnGetLoid_Click(object sender, EventArgs e)
        {

        }

        //spi read 0查看FPGA版本
        private void btnGetFPGAVersion_Click(object sender, EventArgs e)
        {

        }

        //upgrade fpga tftp 192.168.1.x top.bin 更新FPGA版本，192.168.1.x为PC的ip，
        //更新完版本后通过system restart重启设备
        //upgrade fpga gpon tftp 192.168.1.88 top.bin           //gpon升级
        private void btnUpgradeGPON_Click(object sender, EventArgs e)
        {

        }

        //upgrade fpga epon tftp 192.168.1.88 top.bin             //epon升级
        private void btnUpgradeEPON_Click(object sender, EventArgs e)
        {

        }

        //set uart1_debug enable 打开串口打印信息
        private void btnLogData_Click(object sender, EventArgs e)
        {

        }

        //system restart重启设备
        private void btnRestartDevice_Click(object sender, EventArgs e)
        {

        }

        private void btnAbout_Click(object sender, EventArgs e)
        {

        }
    }
}
