using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Plugins.SMS.Server
{
    class TemplateRequestHandler : Notifications.Global.Base.Plugin.Server.IRequestHandler
    {
        public void setupHandlers()
        {
            Notifications.Server.Interop.NetworkComms.addDataHandler((new Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqTemplate()), template);
        }

        private static object template(object request)
        {
            Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqTemplate requ = (Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqTemplate)request;
            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpTemplate respo = new Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpTemplate(requ);

            if (requ.retrieveSavedTemp == true)
            {
                // Connect to database and GET the template and put into respo.retrieved_data
            }
            else
            { 
                // Connect to database and replace the template with the requ.TempContent
            }

            
            return respo;
        }
    }
}
