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
using Notifications.Global.Base.Plugin.Client.GUIObjects;

namespace Notifications.Client.Core.Core.UI.Pages
{
    /// <summary>
    /// Interaction logic for pgeMain.xaml
    /// </summary>
    public partial class pgeMain : Page
    {
        public static pgeMain copyOfMe;
        public pgeMain()
        {
            copyOfMe = this;
            InitializeComponent();
        }



        [Interop.StaticEventMethod("Client.LoggedIn")]
        public static void UserLoggedIn()
        {
            copyOfMe = new pgeMain();
            Interop.EventManager.raiseEvents("Client.Window.changePage", (Object)copyOfMe);
        }

        [Interop.StaticEventMethod("Client.Pages.showMainPage")]
        public static void ShowMainPage()
        {
            copyOfMe = new pgeMain();
            Interop.EventManager.raiseEvents("Client.Window.changePage", (Object)copyOfMe);
        }
    }
}
