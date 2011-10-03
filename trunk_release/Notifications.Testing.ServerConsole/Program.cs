using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Testing.ServerConsole
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Notifications.Server.Server.ConnectionV2 con = new Server.Server.ConnectionV2();
            con.startListening();
            Console.ReadLine();
            
        }
    }
}
