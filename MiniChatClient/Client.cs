using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniChatClient
{
    class Client
    {
        public void Start()
        { 
        String SendStr = "Package";
            using (TcpClient socket = new TcpClient("localhost", 7070))
            using (NetworkStream ns = socket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                foreach (var s in Console.ReadLine())
                {
                    sw.WriteLine(SendStr);
                    sw.Flush();

                    string incomingstr = sr.ReadLine();
    Console.WriteLine("Modtaget ", incomingstr);
                }
               


            }
        }
    }
}
