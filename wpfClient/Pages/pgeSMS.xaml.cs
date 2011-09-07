﻿using System;
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

namespace wpfClient.Pages
{
    /// <summary>
    /// Interaction logic for pgeSMS.xaml
    /// </summary>
    /// 
    public partial class pgeSMS : Page
    {
        apiValidateLogin vlogin = new apiValidateLogin();
        apiSendSms vSendSms = new apiSendSms();
        notifications n = new notifications();



        public pgeSMS()
        {
            InitializeComponent();
        }

        private void btnSendSMS_Click(object sender, RoutedEventArgs e)
        {
            txtFrom.SetStatus("Errored", TextBoxStatuses.ERRORED);
            return;

            try
            {
                vSendSms.sms_from = txtFrom.Text;
            } catch (ArgumentException ex) {
                txtFrom.SetStatus("Errored", TextBoxStatuses.ERRORED);
            }
            try
            {
                vSendSms.sms_to = txtTo.Text;
            } catch (ArgumentException ex) {

            }
            try
            {
                vSendSms.msg_content = txtMessage.Text;
            } catch(ArgumentException ex) {
              
            }
            try
            {
                if (vSendSms._responce == "") 
                {


                }

              lblmsgid.Content = "Message sent! Message ID number:" + n.soapSMS(vSendSms);
            }
            catch (Exception ex) { }


        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //Windows_7_Dialogs.SecurityDialog dialog = new Windows_7_Dialogs.SecurityDialog();
            // dialog.Show("SMSGlobal Credentials", "SMSGlobal is requesting your username and password");

            //vlogin.APIusername = dialog.UserData.Username;
            //vlogin.APIpassword = dialog.UserData.Password;
            vlogin.APIpassword = "81953801";
            vlogin.APIusername = "lolhi";


            try
            {
                vSendSms.ticket = n.requestLogin(vlogin);
            }
            catch (Exception ex)
            {
                //n.HttpSMS(vSendSms, vlogin);            
            }

            lblmsgid.Content = vSendSms.ticket;

            if (vSendSms.ticket == null)
            {
                btnSend.IsEnabled = false;
            }
            else { btnSend.IsEnabled = true; }
        }



    }
}
