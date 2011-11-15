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

namespace Notifications.Plugins.Administration.Client.UI.Tabs
{
    /// <summary>
    /// Interaction logic for tabAdminTab.xaml
    /// </summary>
    public partial class tabAdminTab : RibbonTab
    {
        private static Pages.pgeListUsers ListUsers;

        public tabAdminTab()
        {
            InitializeComponent();
            Interop.EventManager.handleEvent("Plugin.Administration.Tab.AddGroup", addGroup);
            
        }

        

        private void addGroup(object group)
        {
            //RibbonGroup rGroup = (RibbonGroup)group;
            this.Items.Add(group);
        }

        private void btnListUsers_Click(object sender, RoutedEventArgs e)
        {
            ListUsers = new Pages.pgeListUsers();
            Interop.EventManager.raiseEvents("Client.Window.ChangePage", (object)ListUsers);
        }
    }
}
