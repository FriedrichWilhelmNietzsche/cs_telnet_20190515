using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace cs_telnet_20190515
{
    class Program
    {
        public static NetworkStream stream;
        public static TcpClient tcpclient;
        public static string ip;
        public static int port;
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Device IP:");
                ip = Console.ReadLine();
                Console.WriteLine("Device Port:");
                port = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("ERROR! RUN AGAIN!");
                Thread.Sleep(1000);
                //Console.ReadKey();
                //System.Diagnostics.Process.GetCurrentProcess().Kill();
            }

            Run();
            //StreamWriter sw = new StreamWriter("txtstr.txt", false); //这个是绝对路径
            //sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff") + "Server IP:" + ip + "   Server Port:" + port   );
            //sw.Close();//写入 
        }

        static public void Run()
        {
            try
            {

                tcpclient = new TcpClient(ip, port);  // 连接服务器
                stream = tcpclient.GetStream();   // 获取网络数据流对象
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
                    sw.Write("{0}\r\n", Console.ReadLine());
                    sw.Flush();
                }
            }
            catch
            {
                Console.WriteLine("ERROR! RUN AGAIN!");
                //Thread.Sleep(5000);
                Console.ReadKey();
            }
        }
    }
}






