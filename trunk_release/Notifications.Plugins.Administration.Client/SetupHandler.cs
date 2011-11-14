using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interop = Notifications.Client.Interop;
namespace Notifications.Plugins.Administration.Client
{
    public class SetupHandler : Notifications.Global.Base.Plugin.Client.ISetupHandler
    {
        private UI.Tabs.tabAdminTab AdminTab;
        public bool setup()
        {
            Console.WriteLine("Admininstration Setup Running");
            AdminTab = new UI.Tabs.tabAdminTab();
            //throw new Exception("lol");
            //Interop.EventManager.handleEvent("Plugin.Administration.Tab.AddGroup",);

            return true;
        }


    }
}
