using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Server.Core.Core.RequestHandlers
{
    public class Login : Notifications.Global.Base.Plugin.Server.IRequestHandler
    {

        public void setupHandlers()
        {
            Server.Interop.NetworkComms.addDataHandler((new Global.Core.Communication.Core.Requests.comdata_rqLogin()), handleLogin);
        }

        private static object handleLogin(object request)
        {
            
            Global.Core.Communication.Core.Requests.comdata_rqLogin reqo = (Global.Core.Communication.Core.Requests.comdata_rqLogin)request;
            Global.Core.Communication.Core.Responses.comdata_rtLogin respo = new Global.Core.Communication.Core.Responses.comdata_rtLogin(reqo);
            respo.loginSuccessful = false;
            string password = "";
            bool canLogin = true;
            switch (reqo.username)
            {
                case "bake266":
                    password = "lol";
                    break;
                case "burf9":
                    password = "lol";
                    break;
                default:
                    canLogin = false;
                    break;
            }
            respo.username = reqo.username;
            if (canLogin && reqo.password == password)
            {
                respo.loginSuccessful = true;
            }
            return respo;
        }
    }
}
