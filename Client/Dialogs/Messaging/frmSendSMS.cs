using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SMS_API;

namespace Client.Dialogs.Messaging
{

    public partial class frmSendSMS : Form
    {
        apiValidateLogin vlogin = new apiValidateLogin();
        apiSendSms vSendSms = new apiSendSms();
        notifications n = new notifications();
        public frmSendSMS()
        {
            InitializeComponent();
            if (vSendSms.ticket == null) {
                btnSend.Enabled = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Windows_7_Dialogs.SecurityDialog dialog = new Windows_7_Dialogs.SecurityDialog();
           // dialog.Show("SMSGlobal Credentials", "SMSGlobal is requesting your username and password");

            //vlogin.APIusername = dialog.UserData.Username;
            //vlogin.APIpassword = dialog.UserData.Password;
            vlogin.APIpassword = "81953801";
            vlogin.APIusername = "lolhi";

            
            try
            {
                n.requestLogin(vlogin, vSendSms);
             
            } catch(Exception ex) {
                //n.HttpSMS(vSendSms, vlogin);            
            }

            lblTicket.Text = vSendSms.ticket;

            if (vSendSms.ticket == null)
            {
                btnSend.Enabled = false;
            }
            else { btnSend.Enabled = true; }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            vSendSms.sms_from = txtFrom.Text;
            vSendSms.sms_to = txtTo.Text;
            vSendSms.msg_content = txtMessage.Text;
            try
            {
                n.soapSMS(vSendSms);
            } catch (Exception ex) { }
             

        }
    }
}
