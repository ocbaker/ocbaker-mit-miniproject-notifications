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
using SMS_API;
using Extensions;
using Microsoft.Windows.Controls;
using System.Threading;

namespace wpfClient.Pages
{
    /// <summary>
    /// Interaction logic for pgeSMS.xaml
    /// </summary>
    /// 
    public partial class pgeSMS : Page
    {
        
        public static apiValidateLogin vlogin = new apiValidateLogin();
        public static apiSendSms vSendSms = new apiSendSms();
        notifications n = new notifications();
        //DispatcherTimer timer = new DispatcherTimer();
        //Maybe use thread.sleep(3000); lbl.enabled = false


        public pgeSMS()
        {
            InitializeComponent();
            btnSend.IsEnabled = false;

            //Take the current loged in user, get their employee ID number, use it as their FROM: In the SMS FROM
            txtFrom.Text = Convert.ToString(000001);

            //Get the SMSGLobal username & password from the database (only admin can set), and Login using SMSvalidateapi
            //connectToDatabase();
            //loginToSMSGlobal();
        }


        private void txtFrom_LostFocus(object sender, RoutedEventArgs e) 
        {
            //try
            //{
            //    vSendSms.sms_from = txtFrom.Text;
            //    txtFrom.SetStatus("OK", TextBoxStatuses.OK);
            //} catch (ArgumentException ex) {
            //   txtFrom.SetStatus("Errored", TextBoxStatuses.ERRORED);
            //}
        }

        private void txtTo_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                vSendSms.sms_to = txtTo.Text;
                txtTo.SetStatus("OK", TextBoxStatuses.OK);
            }
            catch (ArgumentException ex)
            {
                txtTo.SetStatus("Errored", TextBoxStatuses.ERRORED);
            }
        }

        private void txtMessage_LostFocus(object sender,RoutedEventArgs e)
        {
            try
            {
                vSendSms.msg_content = txtMessage.Text;
                txtMessage.SetStatus("OK", TextBoxStatuses.OK);
            }
            catch (ArgumentException ex)
            {
                txtMessage.SetStatus("Errored", TextBoxStatuses.ERRORED);
            }
        }

        private void btnSendSMS_Click(object sender, RoutedEventArgs e)
        {
            //vSendSms.schedule = Convert.ToString(dtp.DateTimeSelected);
            //If (dtp.DateTimeSelected) / Write to some DB and set timer.
            try
            {
                n.soapSMS(vSendSms);

                if (vSendSms._responce == "") 
                {
                    lblmsgid.Content = "Message send failed.";
                }else{ 
                    lblmsgid.Content = "Message sent! Message ID number: " + vSendSms._responce;                
                }
            }
            catch (Exception ex) { }

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //Windows_7_Dialogs.SecurityDialog dialog = new Windows_7_Dialogs.SecurityDialog();
            //dialog.Show("SMSGlobal Credentials", "SMSGlobal is requesting your username and password");
            
            //vlogin.APIusername = dialog.UserData.Username;
            //vlogin.APIpassword = dialog.UserData.Password;
            

            loginToSMSGlobal();

            

            //lblmsgid.Content = vSendSms.ticket;

        }

        private void loginToSMSGlobal() 
        {
            //Remove when i can connect to the database.
            vlogin.APIpassword = "81953801";
            vlogin.APIusername = "lolhi";

            try 
            {
                n.requestLogin(vlogin, vSendSms);
            } catch (Exception ex) {
               // n.HttpSMS(vSendSms, vlogin);
            }

            if (vSendSms.ticket == null)
            {
                btnSend.IsEnabled = false;
            }
            else { btnSend.IsEnabled = true; }

        }

        private void connectToDatabase()
        {

        }

    }
}
