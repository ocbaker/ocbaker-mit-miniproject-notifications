using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Notifications.Client.Core.Core.UI.Dialogs
{
    public partial class frmLoginDialog : Form
    {
        public frmLoginDialog()
        {
            InitializeComponent();
            Interop.NetworkComms.addDataHandler((new Global.Core.Communication.Core.Responses.comdata_rtLogin(new Global.Core.Communication.Core.Requests.comdata_rqLogin())), handleResponse);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Global.Core.Communication.Core.Requests.comdata_rqLogin rqL = new Global.Core.Communication.Core.Requests.comdata_rqLogin();
            rqL.username = txtUsername.Text;
            rqL.password = txtPassword.Text;
            Interop.NetworkComms.sendMessage(rqL);
            }

        private object handleResponse(object response)
        {

            return false;
        }

        public void showd()
        {
            this.Show();
        }
    }
}
