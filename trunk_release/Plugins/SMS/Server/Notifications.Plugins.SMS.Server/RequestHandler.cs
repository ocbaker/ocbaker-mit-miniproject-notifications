using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Notifications.Global.Core.Communication.Base;

namespace Notifications.Plugins.SMS.Server
{
    class RequestHandler : Notifications.Global.Base.Plugin.Server.IRequestHandler
    {
        private static string cachedUsername;
        private static string cachedPassword;
        private static apiValidateLogin v;

        public void setupHandlers()
        {
            Console.WriteLine("Setting up SMS Server Plugin....");
            //Nito.Async.ActionDispatcher.Current.QueueAction(new Action(
            Notifications.Server.Interop.NetworkComms.addDataHandler((new Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_sendSMS()), textSent);
            
        }


        private static object textSent(object request)
        {
            Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_sendSMS requ = (Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_sendSMS)request;
            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_textSent respo = new Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_textSent(requ);

            respo.successfullText = false;
     
            if (v.LastCheck < DateTime.Now)
            {
                v.LastCheck = DateTime.Now.AddMinutes(10);
                // Connect to database and get get username/password, add to CachedUsername, cachedPassword
            }
            v = new apiValidateLogin(cachedUsername, cachedPassword);

            serverNotification sn = new serverNotification();
            try
            {
               // sn.requestLogin( some object which has info's )
                try
                {
                    sn.soapSMS(requ);
                    respo.messageID = requ.response;
                    respo.successfullText = true;
                    
                }
                catch (Exception ex)
                {
                    sn.HttpSMS(v, requ);
                    respo.messageID = requ.response;
                    respo.successfullText = true;
                }
            }           
            catch (Exception ex) {
                respo.successfullText = false;
                respo.messageID = "Failed to send";
            }

            recordMessage(respo, requ);

            return respo;
        }
        private static void recordMessage(Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_textSent r, Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_sendSMS rq)
        {
         //   Save whatver data is needed using respo and resu.

        }

    }
}