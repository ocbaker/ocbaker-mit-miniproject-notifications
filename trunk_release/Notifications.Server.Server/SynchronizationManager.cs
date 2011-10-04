using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Nito.Async;

namespace Notifications.Server.Server
{
    internal class SynchronizationManager
    {

        private static ActionDispatcherSynchronizationContext safeContext;
        private static ActionDispatcher actDisp;
        private static Thread workerThread;

        internal static void letMeHandleIt()
        {
            if (SynchronizationContext.Current == null)
            {
                if (safeContext == null)
                {
                    workerThread = new Thread(new ThreadStart(continueHandlingIt));
                    actDisp = new ActionDispatcher();
                    safeContext = new ActionDispatcherSynchronizationContext(actDisp);
                }
                SynchronizationContext.SetSynchronizationContext(safeContext);
            
                workerThread.Start();
            }
        }

        private static void continueHandlingIt(){
            while (true)
            {
                Thread.Sleep(10);
                actDisp.Run(); 
            }
        }
    }
}
