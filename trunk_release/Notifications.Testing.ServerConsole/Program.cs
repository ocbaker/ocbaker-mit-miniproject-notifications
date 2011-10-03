using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Testing.ServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Notifications.Server.Server.Class1.test());
            Console.ReadLine();
        }
    }
}
