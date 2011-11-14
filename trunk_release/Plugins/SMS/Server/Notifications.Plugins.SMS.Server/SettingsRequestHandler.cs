using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Plugins.SMS.Server
{
    class SettingsRequestHandler : Notifications.Global.Base.Plugin.Server.IRequestHandler
    {
        public void setupHandlers()
        {
            Notifications.Server.Interop.NetworkComms.addDataHandler((new Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqSMSGlobal()), smsGlobalsaveToDatabase);
            Notifications.Server.Interop.NetworkComms.addDataHandler((new Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqProxy()), EmailsaveToDatabase);
            Notifications.Server.Interop.NetworkComms.addDataHandler((new Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqEmail()), ProxysaveToDatabase);
        }

        private static object smsGlobalsaveToDatabase(Object request)
        {

            Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqSMSGlobal requ = (Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqSMSGlobal)request;
            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpSMSGlobal respo = new Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpSMSGlobal(requ);

            if (requ.getData == true)
            {
                // GET the data respo.username = 'Username' | respo.password = 'Password'
                respo.dataRetrieved = true;
            }
            else
            {
                // POST data to the server using Use requ.username and requ.password 
                try
                {

                    respo.SaveSucessful = true;
                }
                catch (Exception ex)
                {
                    respo.SaveSucessful = false;
                }
                respo.dataRetrieved = false;
            }
            

            return respo;
        }
        private static object EmailsaveToDatabase(Object request)
        {

            Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqEmail requ = (Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqEmail)request;
            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpEmail respo = new Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpEmail(requ);

            if (requ.getData == true)
            {
                // GET the data respo.username = 'Username' | respo.password = 'Password'
                respo.dataRetrieved = true;
            }
            else
            {
                // POST data to the server using Use requ.username and requ.password 
                try
                {

                    respo.SaveSucessful = true;
                }
                catch (Exception ex)
                {
                    respo.SaveSucessful = false;
                }
                respo.dataRetrieved = false;
            }


            return respo;
        }
        private static object ProxysaveToDatabase(Object request)
        {

            Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqProxy requ = (Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqProxy)request;
            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpProxy respo = new Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpProxy(requ);

        


            if (requ.getData == true)
            {
                // GET the data respo.username = 'Username' | respo.password = 'Password'
                respo.dataRetrieved = true;
            }
            else
            {
                // POST data to the server using Use requ.username and requ.password 
                try
                {

                    respo.SaveSucessful = true;
                }
                catch (Exception ex)
                {
                    respo.SaveSucessful = false;
                }
                respo.dataRetrieved = false;
            }

            return respo;
        }
    }
}
