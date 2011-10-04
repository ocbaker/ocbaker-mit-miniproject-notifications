using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Nito.Async;

namespace Notifications.Testing.ServerConsole
{
    class Program
    {
        private static ActionDispatcherSynchronizationContext context;
        private static ActionDispatcher actDisp;
        public static Notifications.Server.Server.ConnectionV2 con;
        

        static void Main(string[] args)
        {
            //testContext form = new testContext();
            actDisp = new ActionDispatcher();
            context = new ActionDispatcherSynchronizationContext(actDisp);
            //con2 = new System.Windows.Forms.WindowsFormsSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(context);
            //form.DoWork();
            
            //form.ShowDialog();
            con = new Server.Server.ConnectionV2();
            con.startListening();
            Console.WriteLine("Started Listening");
            while (true)
            {
                Thread.Sleep(5);
                actDisp.Run();
            }
            Console.ReadLine();
            
        }
    }
}
