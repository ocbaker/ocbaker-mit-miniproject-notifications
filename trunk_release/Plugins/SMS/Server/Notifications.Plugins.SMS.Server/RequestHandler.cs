using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Plugins.SMS.Server
{
    class RequestHandler : Global.Base.Plugin.Server.IRequestHandler
    {

        public void setupHandlers()
        {
            Notifications.Server.Interop.NetworkComms.addDataHandler((new Global.Core.Communication.Core.Requests.comdata_rqLogin()), handleLogin);
        }


        private static object handleLogin(object request)
        {
            return 0;
        }
    }
}
