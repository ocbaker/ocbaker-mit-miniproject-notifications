using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Windows.Controls.Ribbon;
using System.Windows;


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

            RibbonButton btnAdmMsg = new RibbonButton();
            btnAdmMsg.Label = "Data Settings";
            btnAdmMsg.Click += new RoutedEventHandler(btnAdmMsg_Click);
            rg.Items.Add(btnAdmMsg);

            Interop.EventManager.raiseEvents("Plugin.Administration.Tab.AddGroup", rg);
        }
         static void btnAdmMsg_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RibbonButton srcRButton = e.Source as RibbonButton;
            Interop.EventManager.raiseEvents("Client.Window.ChangePage", new UI.Pages.admSMS());
        }

        public bool setup()
        {
            SMSTab = new UI.tabSMSTab();
            return true;
        }
    }


}
