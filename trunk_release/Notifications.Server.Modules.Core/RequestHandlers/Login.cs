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
            //Server.Interop.NetworkComms.addDataHandler(, handleLogin);
        }

        [Server.Interop.RequestHandlerMethod(typeof(Global.Core.Communication.Core.Requests.comdata_rqLogin))]
        public static object handleLogin(object request)
        {
            
            Global.Core.Communication.Core.Requests.comdata_rqLogin reqo = (Global.Core.Communication.Core.Requests.comdata_rqLogin)request;
            string FirstName="";
            string LastName="";
            int userLevel=-1;
            string password = "";
            bool canLogin = true;
            switch (reqo.username)
            {
                case "bake266":
                    password = "lol";
                    FirstName = "Oliver";
                    LastName = "Baker";
                    userLevel = 0;
                    break;
                case "burf9":
                    password = "lol";
                    FirstName = "Shane";
                    LastName = "Burfield-Mills";
                    userLevel = 1;
                    break;
                default:
                    canLogin = false;
                    break;
            }
            if (canLogin && reqo.password == password)
            {
                Global.Core.Communication.Core.Responses.comdata_rtLogin respo = new Global.Core.Communication.Core.Responses.comdata_rtLogin(reqo, new Global.Core.Communication.Core.Data.UserInformation(reqo.username.ToLower(), FirstName, LastName, userLevel));
                Interop.EventManager.raiseEvents("Server.Network.LoggedIn", reqo.messageID, respo.userInformation);
                return respo;
            }
            else
            {
                return new Global.Core.Communication.Core.Responses.comdata_rtLogin(reqo, null);
            }
        }
    }
}
