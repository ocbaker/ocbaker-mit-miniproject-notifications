using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Extensions;
using Extensions.ConnectionCom;
using Extensions.ConnectionCom.Classes;
using Extensions.ConnectionCom.Classes.Requests;
using Extensions.ConnectionCom.Classes.Responses;
using Client.Dialogs.Messaging;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           // SrvCon.Connection.connectAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SrvCon.Connection.connectAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSendSMS a = new frmSendSMS();
            a.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //RequestObject<comdata_rqLogin> reqObj = new RequestObject<comdata_rqLogin>();
            //reqObj.action = "login";
            //reqObj.responseid = 1234;
            //reqObj.data = new comdata_rqLogin();
            //reqObj.data.username = "ocbaker";
            //reqObj.data.password = "myPassword";
            //ObjectWrapper<RequestObject<comdata_rqLogin>,ResponseObject<comdata_rtLogin>> objWrap = new ObjectWrapper<RequestObject<comdata_rqLogin>,ResponseObject<comdata_rtLogin>>(reqObj);
            ////objWrap.submitQuery();
            //String JSON = ObjectConverter.ToJSON<RequestObject<comdata_rqLogin>>(reqObj);
            //SrvCon.Connection.SendData(JSON);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool success = false;

            while (success == false)
            {
                
                Windows_7_Dialogs.SecurityDialog secDiag = new Windows_7_Dialogs.SecurityDialog();
                secDiag.Show("Login to Notifications Application", "Please Enter in your credentials to log into the Patient Notifications Centre.");
                RequestObject<comdata_rqLogin> reqObj = new RequestObject<comdata_rqLogin>();
                reqObj.action = "login";
                reqObj.responseid = 1234;
                reqObj.data = new comdata_rqLogin();
                reqObj.data.username = secDiag.UserData.Username;
                reqObj.data.password = secDiag.UserData.Password;
                ObjectWrapper<RequestObject<comdata_rqLogin>, ResponseObject<comdata_rtLogin>> objWrap = new ObjectWrapper<RequestObject<comdata_rqLogin>, ResponseObject<comdata_rtLogin>>(reqObj);
                //objWrap.submitQuery();
                String JSON = ObjectConverter.ToJSON<RequestObject<comdata_rqLogin>>(reqObj);
                String rtJSON = SrvCon.Connection.SendData(JSON);
                ResponseObject<comdata_rtLogin> rtObject = ObjectConverter.ToObject<ResponseObject<comdata_rtLogin>>(rtJSON);
                if (rtObject.error_code == 0)
                {
                    if (rtObject.data.loginSuccessful)
                    {
                        success = true;
                        MessageBox.Show("Login Successful! Welcome: " + reqObj.data.username);
                    }
                    else
                    {
                        MessageBox.Show("Login Unsuccessful");

                    }

                }
                else
                {
                    MessageBox.Show("Login Unsuccessful");
                    //Error has happened
                }
            }
            
        }
    }
}
