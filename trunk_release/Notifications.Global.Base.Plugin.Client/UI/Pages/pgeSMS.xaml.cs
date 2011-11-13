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


namespace Notifications.Global.Base.Plugin.Client.UI.Pages
{
    /// <summary>
    /// Interaction logic for pgeSMS.xaml
    /// </summary>
    partial class pgeSMS : Page
    {
        /// <summary>
        /// Interaction logic for pgeSMS.xaml
        /// </summary>

            int _count = 0;
            public static apiValidateLogin vlogin = new apiValidateLogin();
            public static apiSendSMS vSendSms = new apiSendSMS();
            public static serverNotification n = new serverNotification();
        

            public pgeSMS()
            {
                
                InitializeComponent();
                btnSend.IsEnabled = false;
                
                //Take the current loged in user, get their employee ID number, use it as their FROM: In the SMS FROM
                txtFrom.Text = Convert.ToString("00001234");

                //Get the SMSGLobal username & password from the database (only admin can set), and Login using SMSvalidateapi
                //connectToDatabase();
                /// Won't need to 'login to sms global', the server will be, only here until there is support.
                loginToSMSGlobal();
            }


            private void txtFrom_LostFocus(object sender, RoutedEventArgs e)
            {
                /// Will hopefully relate to the logged in user. Dr Smurf. EmployeeID = 00001
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
                    txtTo.SetStatus("Errored" + ex.Message, TextBoxStatuses.ERRORED);
                }
            }

            private void txtMessage_LostFocus(object sender, RoutedEventArgs e)
            {
                try
                {
                    vSendSms.msg_content = txtMessage.Text;
                    txtMessage.SetStatus("OK", TextBoxStatuses.OK);
                }
                catch (ArgumentException ex)
                {
                    txtMessage.SetStatus("Errored" + ex.Message, TextBoxStatuses.ERRORED);
                }
            }

            private void btnSendSMS_Click(object sender, RoutedEventArgs e)
            {
                //vSendSms.schedule = Convert.ToString(dtp.DateTimeSelected);
                //If (dtp.DateTimeSelected) / Write to some DB and set timer.
                vSendSms.sms_from = txtFrom.Text;
                try
                {
                    if (cbSMS.IsEnabled)
                    {
                        try
                        {
                            n.soapSMS(vSendSms);
                        }
                        catch (Exception exxx)
                        {
                            /// Could have error logging.?
                            n.HttpSMS(vSendSms, vlogin);
                        }



                        if (vSendSms._responce == "")
                        {
                            //Timer t = new Timer();

                            lblmsgid.Visibility = System.Windows.Visibility.Visible;
                            lblmsgid.Content = "Message send failed.";
                            //t.SetSingleShot(new TimeSpan(3000));
                            // t.Enabled = true;
                            // lblmsgid.Visibility = System.Windows.Visibility.Collapsed;
                        }
                        else
                        {
                            lblmsgid.Visibility = System.Windows.Visibility.Visible;
                            lblmsgid.Content = "Message sent! Message ID number: " + vSendSms._responce;
                        }
                    }
                    if (cbEmail.IsEnabled)
                    {
                        n.sendEmail(vSendSms);
                    }
                }
                catch (Exception ex) { }

            }

            private void loginToSMSGlobal()
            {
                //Remove when i can connect to the database.
                vlogin.APIpassword = "81953801";
                vlogin.APIusername = "lolhi";

                try
                {
                    n.requestLogin(vlogin, vSendSms);
                }
                catch (Exception ex)
                {
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

            //private string SaveState()
            //{
            //   string[] states;



            //    return states;
            //}
            private void pgeSMS_LostFocus(object sender, RoutedEventArgs e)
            {

            }

            private void txtMessage_TextChanged(object sender, TextChangedEventArgs e)
            {
                byte red = (byte)_count;
                byte green = 150, blue = 150;

                if (_count + 150 > 255)
                {
                    red = 255;
                    blue = 0;
                    green = 0;
                }
                else
                {
                    red = (byte)((int)150 + (int)_count);

                    blue = (byte)((int)150 - (int)_count);
                    green = blue;
                }
                lblSMScount.Foreground = ExtensionServices.fromRGB(red, green, blue);

                if (Keyboard.IsKeyDown(Key.Back))
                {
                    _count -= 1;
                }
                else
                {
                    _count += 1;
                }
                if (_count > 160)
                {
                    btnSend.IsEnabled = false;
                }
                else
                    if (_count <= 160)
                    {
                        btnSend.IsEnabled = true;
                    }
                lblSMScount.Content = _count + "/160";
            }

            private void cbEmail_Checked(object sender, RoutedEventArgs e)
            {
                if (cbEmail.IsChecked == true)
                {
                    txtEmail.IsEnabled = true;
                }
            }

            private void cbSMS_Checked(object sender, RoutedEventArgs e)
            {
                if (cbSMS.IsChecked == true)
                {
                    txtTo.IsEnabled = true;
                }
            }

            private void cbSMS_Unchecked(object sender, RoutedEventArgs e)
            {
                if (cbSMS.IsChecked == false)
                {
                    txtTo.IsEnabled = false;
                }
            }

            private void cbEmail_Unchecked(object sender, RoutedEventArgs e)
            {
                if (cbEmail.IsChecked == false)
                {
                    txtEmail.IsEnabled = false;
                }
            }
        }
   
}
