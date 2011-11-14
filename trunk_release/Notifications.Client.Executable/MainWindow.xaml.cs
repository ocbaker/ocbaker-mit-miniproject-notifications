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
            Interop.ConsoleManager.Show();
            //System.IO.FileStream fs = new System.IO.FileStream("DebuggingInfo.txt",System.IO.FileMode.Create);
            //System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
            
            //Console.SetOut(sw);
            Console.WriteLine("DEBUGGING FILE");
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
            Interop.EventManager.handleEvent("Client.Window.AddTab", glbh_AddTab);
            Interop.EventManager.handleEvent("Client.Window.RemoveTab", glbh_RemoveTab);
            Interop.EventManager.handleEvent("Client.Window.changePage", glbh_changePage);
            Interop.UserInterface.addTab = addTab;
            Interop.UserInterface.addPage = addPage;
            // Insert code required on object creation below this point.
            Ribbon.IsEnabled = false;
            Ribbon.IsMinimized = true;
            Notifications.Client.Core.Manager.PluginManager.start();
            Interop.EventManager.raiseEvents("Client.Window.ChangePage", new Core.Core.UI.Pages.pgeLogin());
            //frame1.Content = new Core.Core.UI.Pages.pgeLogin();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Interop.EventManager.raiseEvents("Client.LoggedOut", null);
        }

        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {
            //Client.Core.Core.UI.Dialogs.frmLoginDialog frm = new Core.Core.UI.Dialogs.frmLoginDialog();
            //frm.ShowDialog();
            RibbonGroup rg = new RibbonGroup();
            rg.Header = "Test Group Added With Eventing";
            Interop.EventManager.raiseEvents("Plugin.Administration.Tab.AddGroup", rg);
        }

        public void glbh_changePage(Object page)
        {
            frame1.Content = page;
        }

        public void addTab(Object key, Object value)
        {

        }

        public void addPage(Object key, Object value)
        {

        }

        public void glbh_AddTab(Object tab)
        {
            Ribbon.Items.Add(tab);
        }

        public void glbh_RemoveTab(Object tab)
        {
            Ribbon.Items.Remove(tab);
        }

        [Interop.EventMethod("Client.LoggedIn")]
        public void glbh_UserLoggedIn()
        {
            Group1.Header = "Logged In: " + Interop.PropertiesManager.GetProperty("Client.Username");
            Ribbon.IsEnabled = true;
            Ribbon.IsMinimized = false;
            Ribbon.SelectedIndex = 0;
        }
    }
}
