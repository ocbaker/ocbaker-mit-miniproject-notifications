using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interop = Notifications.Client.Interop;

namespace Notifications.Plugins.SMS.Client
{
    class SetupHandlers : Notifications.Global.Base.Plugin.Client.ISetupHandler
    {
        private UI.tabSMSTab SMSTab;
        public bool setup()
        {
            SMSTab = new UI.tabSMSTab();
            Console.WriteLine("SMS Setup Running");


            return true;
        }
    }


}
