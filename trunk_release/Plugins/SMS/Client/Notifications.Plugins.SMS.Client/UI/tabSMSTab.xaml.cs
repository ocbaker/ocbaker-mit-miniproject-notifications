using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Windows.Controls.Ribbon;
using Interop = Notifications.Client.Interop;


namespace Notifications.Plugins.SMS.Client.UI
{
    /// <summary>
    /// Interaction logic for tabSMSTab.xaml
    /// </summary>
    public partial class tabSMSTab : RibbonTab
    {
        public tabSMSTab()
        {
            InitializeComponent();
            Interop.EventManager.handleEvent("Client.LoggedIn",LoggedIn);
            Interop.EventManager.handleEvent("Client.LoggedOut", LoggedOut);
            Interop.EventManager.handleEvent("Plugin.Administration.Tab.AddGroup", addGroup);
            Console.WriteLine("SMS Tab Initialized");
        }

        private void addGroup(object group)
        {
            //RibbonGroup rGroup = (RibbonGroup)group;
            this.Items.Add(group);
        }
        private void LoggedIn()
        {
            Console.WriteLine("SMS LoggedIn Function Running");
            Interop.EventManager.raiseEvents("Client.Window.AddTab", (Object)this);
        }
        private void LoggedOut()
        {
            Interop.EventManager.raiseEvents("Client.Window.RemoveTab", (Object)this);
        }

        private void SendSMS_Click(object sender, RoutedEventArgs e)
        {
            Interop.EventManager.raiseEvents("Client.Window.ChangePage", new UI.Pages.pgeSMS());
        }

        private void smsHistory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void smsTemplate_Click(object sender, RoutedEventArgs e)
        {

        }


    }
    
}
