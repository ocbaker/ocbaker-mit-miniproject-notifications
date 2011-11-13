using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Notifications.Global.Core.Communication.Base;

namespace Notifications.Plugins.SMS.Server
{
    class RequestHandler : Global.Base.Plugin.Server.IRequestHandler
    {

        public void setupHandlers()
        {
          //  Notifications.Server.Interop.NetworkComms.addDataHandler((new Notifications.Global.Core.Communication.Requests.comdata_rqLogin()), handleLogin);
        }


        private static object handleLogin(object request)
        {
            return 0;
        }
    }
}
