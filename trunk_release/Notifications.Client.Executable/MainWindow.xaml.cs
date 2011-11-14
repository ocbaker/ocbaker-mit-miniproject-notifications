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

namespace Notifications.Client.Executable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public NetworkComms con2;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                con2 = new NetworkComms();
                con2.connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Connecting to Server");
            }
            Interop.EventManager.handleEvent("Client.LoggedIn", glbh_UserLoggedIn);
            Interop.UserInterface.addTab = addTab;
            Interop.UserInterface.addPage = addPage;
            // Insert code required on object creation below this point.
            Ribbon.IsEnabled = false;
            Ribbon.IsMinimized = true;
            frame1.Content = new Core.Core.UI.Pages.pgeLogin();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {
            //Client.Core.Core.UI.Dialogs.frmLoginDialog frm = new Core.Core.UI.Dialogs.frmLoginDialog();
            //frm.ShowDialog();
        }

        public void addTab(Object key, Object value)
        {

        }

        public void addPage(Object key, Object value)
        {

        }

        public void glbh_UserLoggedIn(object username)
        {
            Group1.Header = "Logged In: " + username;
            Ribbon.IsEnabled = true;
            Ribbon.IsMinimized = false;
            Ribbon.SelectedIndex = 0;
        }
    }
}
