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

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Windows_7_Dialogs.SecurityDialog dialog = new Windows_7_Dialogs.SecurityDialog();
           // dialog.Show("SMSGlobal Credentials", "SMSGlobal is requesting your username and password");

            //vlogin.APIusername = dialog.UserData.Username;
            //vlogin.APIpassword = dialog.UserData.Password;
            vlogin.APIpassword = "81953801";
            vlogin.APIusername = "lolhi";

            //n.HttpSMS(vSendSms, vlogin);
            vSendSms.ticket = n.requestLogin(vlogin);
            lblTicket.Text = vSendSms.ticket;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            vSendSms.sms_from = txtFrom.Text;
            vSendSms.sms_to = txtTo.Text;
            vSendSms.msg_content = txtMessage.Text;

            n.soapSMS(vSendSms);

        }
    }
}
