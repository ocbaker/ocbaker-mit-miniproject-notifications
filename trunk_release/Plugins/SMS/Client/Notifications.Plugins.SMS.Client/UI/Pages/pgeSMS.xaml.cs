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
using Interop = Notifications.Client.Interop;
using System.Text.RegularExpressions;
using System.Data;
using System.Web;

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
            public pgeSMS()
            {
                InitializeComponent();
                btnSend.IsEnabled = false;

                Notifications.Client.Interop.NetworkComms.addDataHandler((new Global.ComObjects.Response.comdata_textSent(new Global.ComObjects.Requests.comdata_sendSMS())), txt_serverResponse);
                Notifications.Client.Interop.NetworkComms.addDataHandler((new Global.ComObjects.Response.comdata_emailSent(new Global.ComObjects.Requests.comdata_sendEmail())), email_serverResponse);
                Notifications.Client.Interop.NetworkComms.addDataHandler((new Global.ComObjects.Response.comdata_rpUserID(new Global.ComObjects.Requests.comdata_rqStaff())), returned_UserID);
                Notifications.Client.Interop.NetworkComms.addDataHandler((new Global.ComObjects.Response.comdata_rpTemplates(new Global.ComObjects.Requests.comdata_rqTemplates())), getMyTemplate);

                /// Take the current loged in user, get their employee ID number, use it as their FROM: In the SMS FROM
               Global.ComObjects.Requests.comdata_rqStaff rGetID = new Global.ComObjects.Requests.comdata_rqStaff();
               rGetID.username = Interop.PropertiesManager.GetProperty("User.Username").ToString();
               Notifications.Client.Interop.NetworkComms.sendMessage(rGetID);

               Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqTemplates dT = new Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqTemplates();
               dT.getALL = true;
               Notifications.Client.Interop.NetworkComms.sendMessage(dT);

            }

            private object getMyTemplate(object response)
            {
                Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpTemplates t = (Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpTemplates)response;
                try
                {
                    if (t.dataresponse == true)
                    {
                        try
                        {
                            foreach (DataRow r in t.retrievedData.Tables[0].Rows)
                            {
                                comboBox1.Items.Add(r["TemplateName"]);
                            }
                            comboBox1.SelectedIndex = 0;
                        }
                        catch (Exception ex)
                        {
                            comboBox1.Items.Add("Items failed to load");
                        }
                    }
                    else
                    {
                        lblmsgid.Visibility = System.Windows.Visibility.Visible;
                        txtBlockmessage.Text = HttpUtility.HtmlDecode(t.retrievedData.Tables[0].Rows[0]["TemplateText"].ToString());
                    }
                }
                catch (Exception ex)
                {

                }

                return false;
            }
            private object txt_serverResponse(Object response)
            {
                Global.ComObjects.Response.comdata_textSent r = (Global.ComObjects.Response.comdata_textSent)response;

                    switch (r.successfullText)
                    {
                        case true:
                            lblmsgid.Visibility = System.Windows.Visibility.Visible;
                            txtBlockmessage.Text = "The text was sent sucessfully!";
                            break;

                        case false:
                            txtBlockmessage.Text = "The text failed to send.";
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
                        txtBlockmessage.Text += Environment.NewLine + "The Email was sent sucessfully!";
                        break;

                    case false:
                        txtBlockmessage.Text += Environment.NewLine + "The Email failed to send.";
                        break;
                }
                
                return false;
            }
            private object returned_UserID(Object response)
            {
                Global.ComObjects.Response.comdata_rpUserID r = (Global.ComObjects.Response.comdata_rpUserID)response;

                txtFrom.Text = r.userID;
                return false;
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
                    if (cbSMS.IsChecked.Value)
                    {
                        try
                        {
                            Global.ComObjects.Requests.comdata_sendSMS rSMS = new Global.ComObjects.Requests.comdata_sendSMS();
                            rSMS.sms_from = vSendSms.sms_from;
                            rSMS.msg_content = vSendSms.msg_content;
                            rSMS.sms_to = vSendSms.sms_to;
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

                    if (cbEmail.IsChecked.Value)
                    {
                        Global.ComObjects.Requests.comdata_sendEmail rEmail = new Global.ComObjects.Requests.comdata_sendEmail();
                        rEmail.email_to = txtEmail.Text;
                        rEmail.msg_content = vSendSms.msg_content;
                        try
                        {
                            Notifications.Client.Interop.NetworkComms.sendMessage(rEmail); //Send the email data to the server so that it can send the email                  
                        }
                        catch (Exception xe)
                        {

                        }
                    }
                }
                catch (Exception ex) { 
                }
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

            private void checkBox1_Checked(object sender, RoutedEventArgs e)
            {
                if (cbdefTemplate.IsChecked == true)
                {
                    txtMessage.Visibility = System.Windows.Visibility.Hidden;
                    lblReason.Visibility = System.Windows.Visibility.Visible;
                    lblName.Visibility = System.Windows.Visibility.Visible;
                    lblDate.Visibility = System.Windows.Visibility.Visible;
                    txtReason.Visibility = System.Windows.Visibility.Visible;
                    txtName.Visibility = System.Windows.Visibility.Visible;
                    txtDate.Visibility = System.Windows.Visibility.Visible;
                }
            }

            private void cbdefTemplate_Unchecked(object sender, RoutedEventArgs e)
            {
                if (cbdefTemplate.IsChecked == false)
                {
                    txtMessage.Visibility = System.Windows.Visibility.Visible;
                    txtReason.Visibility = System.Windows.Visibility.Hidden;
                    txtName.Visibility = System.Windows.Visibility.Hidden;
                    txtDate.Visibility = System.Windows.Visibility.Hidden;
                    lblReason.Visibility = System.Windows.Visibility.Hidden;
                    lblName.Visibility = System.Windows.Visibility.Hidden;
                    lblDate.Visibility = System.Windows.Visibility.Hidden;
                }
            }

            private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqTemplates dT = new Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqTemplates();
                dT.getALL = false;
                dT.templateName = comboBox1.SelectedItem.ToString();
                Notifications.Client.Interop.NetworkComms.sendMessage(dT);
            }
            private string ReplaceWords(string oldtext)
            {

                if (oldtext.Contains("~reason~") && txtReason.Text != "") oldtext = oldtext.Replace("~reason~", txtReason.Text);
                if (oldtext.Contains("~date~") && txtDate.Text != "") oldtext = oldtext.Replace("~date~", txtDate.Text);
                if (oldtext.Contains("~name~") && txtName.Text != "") oldtext = oldtext.Replace("~name~", txtName.Text);

                return oldtext;
            }

            private void txtName_LostFocus(object sender, RoutedEventArgs e)
            {
                txtBlockmessage.Text = ReplaceWords(txtBlockmessage.Text.ToString());
                _count = txtBlockmessage.Text.Length;
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
                lblSMScount.Content = _count + "/160";
                lblSMScount.Foreground = ExtensionServices.fromRGB(red, green, blue);
                try { vSendSms.msg_content = txtBlockmessage.Text; btnSend.IsEnabled = true; }
                catch (Exception ex)
                {
                    btnSend.IsEnabled = false;
                }
            }

            private void txtReason_LostFocus(object sender, RoutedEventArgs e)
            {
                txtBlockmessage.Text = ReplaceWords(txtBlockmessage.Text.ToString());
                _count = txtBlockmessage.Text.Length;
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
                lblSMScount.Content = _count + "/160";
                lblSMScount.Foreground = ExtensionServices.fromRGB(red, green, blue);
                try { vSendSms.msg_content = txtBlockmessage.Text; btnSend.IsEnabled = true; }
                catch (Exception ex)
                {
                    btnSend.IsEnabled = false;
                }
            }

            private void txtDate_LostFocus(object sender, RoutedEventArgs e)
            {
                txtBlockmessage.Text = ReplaceWords(txtBlockmessage.Text.ToString());
                _count = txtBlockmessage.Text.Length;
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
                lblSMScount.Content = _count + "/160";
                lblSMScount.Foreground = ExtensionServices.fromRGB(red, green, blue);
                try { vSendSms.msg_content = txtBlockmessage.Text; btnSend.IsEnabled = true; }
                catch (Exception ex)
                {
                    btnSend.IsEnabled = false;
                }
            }


        }
}
