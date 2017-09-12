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
        private readonly int PORT;
        public Client(int port)
        {
            this.PORT = port;
        }
        public void Start()
        {
            String nameofclient = "";
            String nameofserver = "";
            Console.Write("Who are you ");
            nameofclient = Console.ReadLine();

            using (TcpClient socket = new TcpClient("localhost", PORT))
            using (NetworkStream ns = socket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns) {AutoFlush = true})
            {

                /*
                 * Hello between client server
                 */

                //client
                String line = "";
                String myLine = nameofclient;
                sw.WriteLine($"Hello: {nameofclient}");

                //Server
                String fromServer = sr.ReadLine();
                String[] strs = fromServer.Split(' ');
                nameofserver = strs[1];

                while (!myLine.Trim().ToLower().Equals("stop"))
                {
                    //Chat Loop Start
                    Console.Write($"{nameofclient}: ");
                    myLine = Console.ReadLine().Trim();
                    sw.WriteLine(myLine);
                    if (myLine.ToLower().Equals("stop"))
                    {
                        line = "stop";
                    }
                    else
                    {
                        line = sr.ReadLine();
                    }
                    Console.WriteLine($"{nameofserver}: {line}");
                }




            }
        }
    }
}
