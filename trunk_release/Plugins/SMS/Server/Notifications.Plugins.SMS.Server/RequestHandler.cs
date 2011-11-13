using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Notifications.Global.Core.Communication.Base;

namespace Notifications.Plugins.SMS.Server
{
    class RequestHandler : Notifications.Global.Base.Plugin.Server.IRequestHandler
    {
        
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
            serverNotification sn = new serverNotification();
            try
            {
                sn.soapSMS(requ);
            }           
            catch (Exception ex) { 
                // sn.HttpSMS(request,(smsglobal information));
            }


            return respo;
        }

    }
}