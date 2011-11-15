using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interop = Notifications.Client.Interop;
namespace Notifications.Plugins.Administration.Client
{
    public class SetupHandler : Notifications.Global.Base.Plugin.Client.ISetupHandler
    {
        private static UI.Tabs.tabAdminTab AdminTab;
        public bool setup()
        {
            //Console.WriteLine("Admininstration Setup Running");
            AdminTab = new UI.Tabs.tabAdminTab();
            //throw new Exception("lol");
            //Interop.EventManager.handleEvent("Plugin.Administration.Tab.AddGroup",);

            return true;
        }

        [Interop.StaticEventMethod("Client.LoggedIn")]
        public static void UserLoggedIn()
        {
            Console.WriteLine("LOLLERS");
            Global.Class1 c1 = new Global.Class1();
            Interop.EventManager.raiseEvents("Client.Window.AddTab", (Object)AdminTab);
        }
        [Interop.StaticEventMethod("Client.LoggedOut")]
        public static void UserLoggedOut()
        {
            Interop.EventManager.raiseEvents("Client.Window.RemoveTab", (Object)AdminTab);
        }
        
    }
}
