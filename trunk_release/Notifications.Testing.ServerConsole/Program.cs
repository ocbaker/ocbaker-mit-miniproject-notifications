using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Notifications.Testing.ServerConsole
{
    class Program
    {
        public static Notifications.Server.Server.NetworkComms con;
        

        static void Main(string[] args)
        {

            con = new Server.Server.NetworkComms();
            con.startListening();
            Console.WriteLine("Started Listening");
            while (true)
            {
                Thread.Sleep(5);
                //actDisp.Run();
            }
            Console.ReadLine();
            
        }
    }
}
