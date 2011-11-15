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
using Requests = Notifications.Global.Core.Communication.Core.Requests;
using Responses = Notifications.Global.Core.Communication.Core.Responses;

namespace Notifications.Client.Core.Core.UI.Pages
{
    /// <summary>
    /// Interaction logic for pgeLogin.xaml
    /// </summary>
    public partial class pgeLogin : Page
    {
        public pgeLogin()
        {
            InitializeComponent();
            Interop.NetworkComms.addDataHandler((new Responses.comdata_rtLogin(new Requests.comdata_rqLogin(),null)), handleResponse);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            txtUsername.IsEnabled = false;
            txtPassword.IsEnabled = false;
            btnExit.IsEnabled = false;
            btnLogin.IsEnabled = false;
            Requests.comdata_rqLogin rqL = new Requests.comdata_rqLogin();
            rqL.username = txtUsername.Text;
            rqL.password = txtPassword.Password;
            Interop.NetworkComms.sendMessage(rqL);
        }

        private object handleResponse(object response)
        {
            Responses.comdata_rtLogin resp = (Responses.comdata_rtLogin)response;
            if (resp.userInformation != null)
            {
                
                Interop.PropertiesManager.SetProperty("User.username", resp.userInformation.username);
                Interop.PropertiesManager.SetProperty("User", resp.userInformation);
                Interop.EventManager.raiseEvents("Client.LoggedIn");
            }
            else
            {
                txtUsername.IsEnabled = true;
                txtPassword.IsEnabled = true;
                btnExit.IsEnabled = true;
                btnLogin.IsEnabled = true;
                lblError.Visibility = System.Windows.Visibility.Visible;
            }
            return false;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Interop.EventManager.raiseEvents("Client.Quit");
        }
    }
}
