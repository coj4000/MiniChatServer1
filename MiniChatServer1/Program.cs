using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChatServer1
{
    class Program
    {
        private const int PORT = 7070;
        static void Main(string[] args)
        {
            Server server = new Server(PORT);
            server.Start();

            Console.ReadLine();
        }
    }
}
