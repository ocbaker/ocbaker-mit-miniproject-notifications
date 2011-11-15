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
            Interop.EventManager.handleEvent("Client.LoggedOut", glbh_UserLoggedOut);
            Interop.EventManager.handleEvent("Client.Window.AddTab", glbh_AddTab);
            Interop.EventManager.handleEvent("Client.Window.RemoveTab", glbh_RemoveTab);
            Interop.EventManager.handleEvent("Client.Window.changePage", glbh_changePage);
            Interop.UserInterface.addTab = addTab;
            Interop.UserInterface.addPage = addPage;
            // Insert code required on object creation below this point.
            Ribbon.IsEnabled = false;
            Ribbon.IsMinimized = true;
            Ribbon.IsHitTestVisible = false;
            Notifications.Client.Core.Manager.PluginManager.start();
            Interop.EventManager.raiseEvents("Client.Window.ChangePage", new Core.Core.UI.Pages.pgeLogin());
            //frame1.Content = new Core.Core.UI.Pages.pgeLogin();
            //foreach (System.Reflection.AssemblyName assem in System.Reflection.Assembly.GetExecutingAssembly().GetReferencedAssemblies())
            //{
            //    Console.WriteLine(assem.FullName);
            //}
            Interop.EventManager.raiseEvents("Client.Window.Initialized");
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
            throw new NotImplementedException();
        }

        public void addPage(Object key, Object value)
        {
            throw new NotImplementedException();
        }

        public void glbh_AddTab(Object tab)
        {
            try
            {
                Ribbon.Items.Add(tab);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Tab is already added");
            }
        }

        public void glbh_RemoveTab(Object tab)
        {
            try
            {
                Ribbon.Items.Remove(tab);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Tab does not exist on the Ribbon");
            }
        }

        //[Interop.EventMethod("Client.LoggedIn",glbh_UserLoggedIn)]
        public void glbh_UserLoggedIn()
        {
            //Console.WriteLine("GetProperty: " + Interop.PropertiesManager.GetProperty(Console.ReadLine()));
            Group1.Header = "Logged In: " + ((Notifications.Global.Core.Communication.Core.Data.UserInformation)Interop.PropertiesManager.GetProperty("User")).username;
            Ribbon.IsEnabled = true;
            Ribbon.IsMinimized = false;
            Ribbon.IsHitTestVisible = true;
            Ribbon.SelectedIndex = 0;
        }

        [Interop.StaticEventMethod("Client.LoggedOut")]
        protected static void glbh_UserLoggedOut()
        {
            //Ribbon.IsEnabled = false;
            //Ribbon.IsMinimized = true;
            //Ribbon.IsHitTestVisible = false;
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Interop.EventManager.raiseEvents("Client.Window.ChangePage", new Core.Core.UI.Pages.pgePatientList());
        }
    }
}
