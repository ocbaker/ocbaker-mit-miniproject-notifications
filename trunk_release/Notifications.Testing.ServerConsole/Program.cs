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
            
            string fn = Console.ReadLine();
            Notifications.Global.Core.Communication.Core.Requests.comdata_rqFile msg = new Notifications.Global.Core.Communication.Core.Requests.comdata_rqFile();
            msg.FileName = fn;
            msg.File = System.IO.File.ReadAllBytes(fn);
            con.writeMessage(msg);
            Console.ReadLine();
            while (true)
            {
                Thread.Sleep(5);
                //actDisp.Run();
            }
        }
    }
}
