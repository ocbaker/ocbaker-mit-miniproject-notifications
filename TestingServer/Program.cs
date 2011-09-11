using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServerCode;

namespace TestingServer
{
    class Program
    {
        private static srvConnection srvCon;
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Server: Version 0.1");
            Console.WriteLine("---------------------------");
            Console.WriteLine("");
            Console.WriteLine("FOR DEVELOPMENT PURPOSES ONLY!");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine(Extensions.GuidGenerator.GenerateTimeBasedGuid(DateTime.Now));
            srvCon = new srvConnection();
            Console.ReadLine();
        }
    }
}
