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
using Notifications.Plugins.SMS.Server;

namespace Notifications.Plugins.SMS.Client.UI.Pages
{
    /// <summary>
    /// Interaction logic for admSMS.xaml
    /// </summary>

    public partial class admSMS : Page
    {
          
        public admSMS()
        {
            InitializeComponent();

            Notifications.Client.Interop.NetworkComms.addDataHandler((new Global.ComObjects.Response.comdata_rpProxy(new Global.ComObjects.Requests.comdata_rqProxy())), Proxy);
            Notifications.Client.Interop.NetworkComms.addDataHandler((new Global.ComObjects.Response.comdata_rpEmail(new Global.ComObjects.Requests.comdata_rqEmail())), yougotMail);
            Notifications.Client.Interop.NetworkComms.addDataHandler((new Global.ComObjects.Response.comdata_rpSMSGlobal(new Global.ComObjects.Requests.comdata_rqSMSGlobal())), SMS);

            loadPreviousData();
        }
        private void loadPreviousData() {

            Global.ComObjects.Requests.comdata_rqSMSGlobal rSMS = new Global.ComObjects.Requests.comdata_rqSMSGlobal();
            rSMS.getData = true;
            Notifications.Client.Interop.NetworkComms.sendMessage(rSMS);

            Global.ComObjects.Requests.comdata_rqProxy rProxy = new Global.ComObjects.Requests.comdata_rqProxy();
            rProxy.getData = true;
            Notifications.Client.Interop.NetworkComms.sendMessage(rProxy);

            Global.ComObjects.Requests.comdata_rqEmail rMail = new Global.ComObjects.Requests.comdata_rqEmail();
            rMail.getData = true;
            Notifications.Client.Interop.NetworkComms.sendMessage(rMail);
        }
        private object Proxy(Object response) {

            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpProxy t = (Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpProxy)response;

            if (t.dataRetrieved == true)
            {
                txtProxyUsername.Text = t.username;
                pswProxyPassword.Password = t.password;
            }
            else
            {
                if (t.SaveSucessful == true)
                {
                    lblProxySave.Content = "Saved!";
                }
                else
                {
                    lblProxySave.Content = "Save failed";
                }
            }
            return false;
        }
        private object SMS(Object response)
        {

            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpSMSGlobal t = (Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpSMSGlobal)response;

            if (t.dataRetrieved == true)
            {

                txtSMSUsername.Text = t.username;
                psbSMSpassword.Password = t.password;
            }
            else
            {
                if (t.SaveSucessful == true)
                {
                    lblSMSSave.Content = "Saved!";
                }
                else
                {
                    lblSMSSave.Content = "Save failed";
                }
            }
            return false;
        }
        private object yougotMail(Object response)
        {
            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpEmail t = (Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpEmail)response;

            if (t.dataRetrieved == true)
            {
                txtGmailUserlogin.Text = t.username;
                psbGmailPassword.Password = t.password;
            }
            else
            {
                if (t.SaveSucessful == true)
                {
                    lblMailSave.Content = "Saved!";
                }
                else
                {
                    lblMailSave.Content = "Save failed";
                }
            }
            return false;
        }

        private void btnLoginSave_Click(object sender, RoutedEventArgs e)
        {
            //Send the username/password to the Settings Project.
            lblSMSSave.Content = "";
            Global.ComObjects.Requests.comdata_rqSMSGlobal rSMS = new Global.ComObjects.Requests.comdata_rqSMSGlobal();
            rSMS.username = txtSMSUsername.Text;
            rSMS.password = psbSMSpassword.Password;
            rSMS.getData = false;
            Notifications.Client.Interop.NetworkComms.sendMessage(rSMS);

        }
        private void btnProxySave_Click(object sender, RoutedEventArgs e)
        {
            //Send the username/password to the Settings Project.
            lblProxySave.Content = "";
            Global.ComObjects.Requests.comdata_rqProxy rProxy = new Global.ComObjects.Requests.comdata_rqProxy();
            rProxy.username = txtProxyUsername.Text;
            rProxy.password = pswProxyPassword.Password;
            rProxy.getData = false;
            Notifications.Client.Interop.NetworkComms.sendMessage(rProxy);
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Send the username/password to the Settings Project.
            lblMailSave.Content = "";
            Global.ComObjects.Requests.comdata_rqEmail rMail = new Global.ComObjects.Requests.comdata_rqEmail();
            rMail.username = txtGmailUserlogin.Text;
            rMail.password = psbGmailPassword.Password;
            rMail.getData = false;
            Notifications.Client.Interop.NetworkComms.sendMessage(rMail);
        }

        public void txtUsername_LostFocus(object sender, RoutedEventArgs e)
        {
           
        }
        public void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {

        }
        private void psbGmailPassword_LostFocus(object sender, RoutedEventArgs e)
        {
          
        }
        private void tbGmailUserlogin_LostFocus(object sender, RoutedEventArgs e)
        {
        
        }
        private void pswProxyPassword_LostFocus(object sender, RoutedEventArgs e)
        {
           
        }
        private void txtProxyUsername_LostFocus(object sender, RoutedEventArgs e)
        {
          
        }
    }

}
