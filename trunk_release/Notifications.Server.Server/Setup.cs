using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvntM = Notifications.Server.Interop.EventManager;

namespace Notifications.Server.Server
{
    public static class Setup
    {
        private static Notifications.Server.Server.NetworkComms con;
        public static bool setup()
        {
            EvntM.addEvent("server.finished_setup");
            con = new NetworkComms();
            con.addDefaultHandlers();
            
            EvntM.addEvent("Server.myEvent");
            
            con.startListening();
            Notifications.Server.Core.Manager.PluginManager.start();
            return true;
        }

        static void Setup_myEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        static void Setup2_myEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        static void myEventS() { }
    }
}
