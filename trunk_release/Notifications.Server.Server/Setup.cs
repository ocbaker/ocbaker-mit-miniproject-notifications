using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Server.Server
{
    public static class Setup
    {
        private static Notifications.Server.Server.NetworkComms con;
        public static bool setup()
        {
            con = new NetworkComms();
            con.addDefaultHandlers();


            con.startListening();
            Notifications.Server.Core.Manager.PluginManager.start();
            return true;
        }
    }
}
