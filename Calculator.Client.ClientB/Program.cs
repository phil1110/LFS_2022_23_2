using Calculator.Client.Shared;
using Calculator.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Client.ClientB
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleClient cc = new ConsoleClient(new IPEndPoint(IPAddress.Parse("127.0.0.1"), Consts.PORT), "Client-B");
            cc.Run();
            Console.ReadKey();
        }
    }
}
