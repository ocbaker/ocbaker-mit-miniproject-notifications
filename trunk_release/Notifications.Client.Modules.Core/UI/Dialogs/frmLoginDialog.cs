using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Requests = Notifications.Global.Core.Communication.Core.Requests;
using Responses = Notifications.Global.Core.Communication.Core.Responses;

namespace Notifications.Client.Core.Core.UI.Dialogs
{
    public partial class frmLoginDialog : Form
    {
        public frmLoginDialog()
        {
            InitializeComponent();
            Interop.NetworkComms.addDataHandler((new Responses.comdata_rtLogin(new Requests.comdata_rqLogin())), handleResponse);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Requests.comdata_rqLogin rqL = new Requests.comdata_rqLogin();
            rqL.username = txtUsername.Text;
            rqL.password = txtPassword.Text;
            Interop.NetworkComms.sendMessage(rqL);
        }

        private object handleResponse(object response)
        {
            Responses.comdata_rtLogin resp = (Responses.comdata_rtLogin)response;
            if (resp.loginSuccessful)
            {
                Close();
            }
            return false;
        }

        public void showd()
        {
            this.Show();
        }
    }
}
