using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Windows.Controls.Ribbon;

using Interop = Notifications.Client.Interop;

namespace Notifications.Plugins.SMS.Client
{
    class SetupHandlers : Notifications.Global.Base.Plugin.Client.ISetupHandler
    {
        
        private UI.tabSMSTab SMSTab;

        [Interop.StaticEventMethod("Client.Executable.LoadedPlugins")]
        public static void ClientPluginLoaded()
        {

            RibbonGroup rg = new RibbonGroup();
            rg.Header = "Messaging";


            RibbonButton rb = new RibbonButton();
            rb.Label = "Data Settings";
            //rb.Click += "A";

            rg.Items.Add(rb);

            Interop.EventManager.raiseEvents("Plugin.Administration.Tab.AddGroup", rg);
        }
        public bool setup()
        {
            SMSTab = new UI.tabSMSTab();

            


            return true;
        }
    }


}
