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
            Interop.EventManager.raiseEvents("Client.Window.AddTab", (Object)this);
            //Interop.EventManager.handleEvent("Client.LoggedIn",LoggedIn);
            //Interop.EventManager.handleEvent("Client.LoggedOut", LoggedOut);
            
        }

        private void addGroup(object group)
        {
            RibbonGroup rGroup = (RibbonGroup)group;
            this.Items.Add(rGroup);
        }

        //[Interop.StaticEventMethod("Client.Window.Initalized")]
        private void LoggedIn()
        {
            this.IsEnabled = true;
        }
        private void LoggedOut()
        {
            this.IsEnabled = false;
            //Interop.EventManager.raiseEvents("Client.Window.RemoveTab", (Object)this);
        }

        private void SendSMS_Click(object sender, RoutedEventArgs e)
        {
            Interop.EventManager.raiseEvents("Client.Window.ChangePage", new UI.Pages.pgeSMS());
        }

        private void smsHistory_Click(object sender, RoutedEventArgs e)
        {
            Interop.EventManager.raiseEvents("Client.Window.ChangePage", new UI.Pages.pgeSMShistory());
        }

        private void smsTemplate_Click(object sender, RoutedEventArgs e)
        {
            Interop.EventManager.raiseEvents("Client.Window.ChangePage", new UI.Pages.pgeSMSTemplate());
        }

        private void smsCust_Click(object sender, RoutedEventArgs e)
        {
            Interop.EventManager.raiseEvents("Client.Window.ChangePage", new UI.Pages.pgeCustomerLookup());
        }


    }
    
}
