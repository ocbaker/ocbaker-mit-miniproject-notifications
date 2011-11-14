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
using Notifications.Global.Core.Utils;


namespace Notifications.Plugins.SMS.Client.UI.Pages
{
    /// <summary>
    /// Interaction logic for pgeSMS.xaml
    /// </summary>
    public partial class pgeSMS : Page
    {
        /// <summary>
        /// Interaction logic for pgeSMS.xaml
        /// </summary>

            int _count = 0;

            public static apiSendSMS vSendSms = new apiSendSMS();

            //public static   // RequestObject
            //public static serverNotification n = new serverNotification();

            public pgeSMS()
            {
                InitializeComponent();
                btnSend.IsEnabled = false;

                Notifications.Client.Interop.NetworkComms.addDataHandler((new Global.ComObjects.Response.comdata_textSent(new Global.ComObjects.Requests.comdata_sendSMS())), txt_serverResponse);
                Notifications.Client.Interop.NetworkComms.addDataHandler((new Global.ComObjects.Response.comdata_emailSent(new Global.ComObjects.Requests.comdata_sendEmail())), email_serverResponse);

                //Take the current loged in user, get their employee ID number, use it as their FROM: In the SMS FROM
                txtFrom.Text = Convert.ToString("00001234"); //Interop.PropertiesManager.GetProperty("Client.Username");

                // GET the user logged in. Get their 'ID'

            }
            private object txt_serverResponse(Object response)
            {
                Global.ComObjects.Response.comdata_textSent r = (Global.ComObjects.Response.comdata_textSent)response;

                switch (r.successfullText)
                {

                    case true:
                        lblmsgid.Content = "The text was sent sucessfully!";
                        break;

                    case false:
                        lblmsgid.Content = "The text failed to send.";
                        break;
                }

                return false;
            }

            private object email_serverResponse(Object response)
            {

                Global.ComObjects.Response.comdata_emailSent r = (Global.ComObjects.Response.comdata_emailSent)response;

                switch (r.successfullEmail)
                {

                    case true:
                        lblmsgid.Content += Environment.NewLine + "The Email was sent sucessfully!";
                        break;

                    case false:
                        lblmsgid.Content += Environment.NewLine + "The Email failed to send.";
                        break;
                }
                
                return false;
            }

            private void txtFrom_LostFocus(object sender, RoutedEventArgs e)
            {
                /// Will hopefully relate to the logged in user. Dr Smurf. EmployeeID = 00001
                


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
                lblmsgid.Content = "";
                try
                {
                    if (cbSMS.IsEnabled)
                    {
                        try
                        {
                            //n.soapSMS(vSendSms); // <-INSTEAD OF Creating a request object, inherits aBaseRequest, using the vSendSMS, then using NetworkComs 'sendMessage' to send to the server.
                            
                            Global.ComObjects.Requests.comdata_sendSMS rSMS = new Global.ComObjects.Requests.comdata_sendSMS();
                            rSMS.sms_from = vSendSms.sms_from;
                            rSMS.sms_to = vSendSms.sms_to;
                            rSMS.msg_content = vSendSms.msg_content;
                            rSMS.msg_type = vSendSms.msg_type;
                            rSMS.schedule = vSendSms.schedule;
                            rSMS.unicode = vSendSms.unicode;
                            rSMS.email = vSendSms.email;
                            Notifications.Client.Interop.NetworkComms.sendMessage(rSMS);
                        }
                        catch (Exception exxx)
                        {
                            lblmsgid.Content = "Cannot connect to the server. Please try again after reconnection to the server";
                        }
                    }

                    if (cbEmail.IsEnabled)
                    {
                        Global.ComObjects.Requests.comdata_sendEmail rEmail = new Global.ComObjects.Requests.comdata_sendEmail();

                        rEmail.email_to = vSendSms.email;
                        rEmail.msg_content = vSendSms.msg_content;

                        Notifications.Client.Interop.NetworkComms.sendMessage(rEmail); //Send the email data to the server so that it can send the email                  
                    }
                }
                catch (Exception ex) { }

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
