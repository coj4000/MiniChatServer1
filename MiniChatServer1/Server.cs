using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MiniChatServer1
{
    class Server
    {
        public void Start()
        {
            DoClient();
        }

        private static void DoClient()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 7070);
            server.Start();
            int a = 1;
            using (TcpClient socket = server.AcceptTcpClient())
            using (NetworkStream ns = socket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                do
                {
                    String line = sr.ReadLine();
                    string myLine = Console.ReadLine();
                    sw.WriteLine(line);
                    sw.Flush();
                    if (Console.ReadLine() == "stop")
                    {
                        a = 0;
                    }
                } while (a == 1);

            }
        }
    }
}
