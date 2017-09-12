using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MiniChatServer1
{
    internal class Server
    {
        private readonly int PORT = 0;
        public Server(int port)
        {
            PORT = port;
        }
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 7070);
            server.Start();
            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();
                    Task.Run(() =>
                    {
                        TcpClient LocalSocket = socket;
                        DoClient(LocalSocket);
                    });
                    
            }
         
        }

        private static void DoClient(TcpClient socket)
        {

            String nameofclient = "";
            String nameofserver = "";
            using (NetworkStream ns = socket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                //Server
                Console.WriteLine("Whom ist thou (Server)");
                String myLine = Console.ReadLine();
                nameofserver = myLine;
                //Client
                String line = sr.ReadLine();
                String[] sline = line.Split(' ');
                nameofclient = sline[1];
                sw.WriteLine($"Hello: {nameofserver}");
                sw.Flush();
                while (!String.IsNullOrWhiteSpace(line) && !line.Trim().ToLower().Equals("stop"))
                {
                    //Chat loop starter
                    
                    //read from client
                    line = sr.ReadLine();
                    Console.WriteLine($"{nameofclient}: {line}");

                    //write to client
                    Console.WriteLine($"{nameofserver}: ");
                    myLine = Console.ReadLine().Trim() ?? ""; // if readlline = null empty string
                    sw.WriteLine(myLine);
                    sw.Flush();
                    if (myLine.ToLower().Equals("stop"))
                    {
                        line = "stop";
                    }
                }

            }
        }
    }
}
