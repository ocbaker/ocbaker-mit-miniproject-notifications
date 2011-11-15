using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Notifications.Global.Core.Communication.Base;

namespace Notifications.Plugins.SMS.Server
{
    class RequestHandler : Notifications.Global.Base.Plugin.Server.IRequestHandler
    {
        private static string cachedUsername;
        private static string cachedPassword;
        private static apiValidateLogin v = new apiValidateLogin();
        
        public void setupHandlers()
        {
            Notifications.Server.Interop.NetworkComms.addDataHandler((new Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_sendSMS()), textSent);
            Notifications.Server.Interop.NetworkComms.addDataHandler((new Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_sendEmail()), emailsent);
        }

        private static object textSent(object request)
        {
           // v.LastCheck = DateTime.Now;
            Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_sendSMS requ = (Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_sendSMS)request;
            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_textSent respo = new Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_textSent(requ);

        
                respo.successfullText = false;

                //  if (v.LastCheck < DateTime.Now)
                //  {
                //  v.LastCheck = DateTime.Now.AddMinutes(10);
                // Connect to database and get get username/password, add to CachedUsername, cachedPassword

                SqlConnection mycon = new SqlConnection("server=(local);" +
                                    "Trusted_Connection=yes;" +
                                    "database=PatientNotifications; " +
                                    "connection timeout=30");

                mycon.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter("SELECT [Key], Value FROM dbo.Settings WHERE ([Key] = 'SMSGlobalusername') OR ([Key] = 'SMSGlobalpassword')", mycon);

                da.Fill(ds);
                cachedUsername = ds.Tables[0].Rows[0]["Value"].ToString();
                cachedPassword = ds.Tables[0].Rows[1]["Value"].ToString();

                mycon.Close();

                //  }
                v.APIusername = cachedUsername;
                v.APIpassword = cachedPassword;

                serverNotification sn = new serverNotification();
                try
                {
                    sn.requestLogin(v);
                    try
                    {
                        sn.soapSMS(requ);
                        respo.messageID = requ.response;
                        respo.successfullText = true;

                    }
                    catch (Exception ex)
                    {
                        sn.HttpSMS(v, requ);
                        respo.messageID = requ.response;
                        respo.successfullText = true;
                    }
                }
                catch (Exception ex)
                {
                    respo.successfullText = false;
                    respo.messageID = "Failed to send";
                }

                //recordMessage(respo, requ);

            return respo;
        }
        private static void recordMessage(Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_textSent r, Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_sendSMS rq)
        {
         //   Save whatver data is needed using respo and resu.
            try
            {
                SqlConnection mycon = new SqlConnection("server=(local);" +
                                           "Trusted_Connection=yes;" +
                                           "database=PatientNotifications; " +
                                           "connection timeout=30");

                mycon.Open();

                SqlCommand com = new SqlCommand("INSERT INTO PatientData (FamilyName,GivenName, Email, Mobile, Phone, ReminderText, ReminderDate) VALUES (" + "''," + rq.email + "," + rq.sms_to + ",''," + rq.msg_content + ",'');", mycon);
                com.ExecuteNonQuery(); // Force quit when trying to execute this line. SMS sends fine. 
                mycon.Close();
            }
            catch (Exception ex)
            {

            }
        }
        private static object emailsent(Object request)
        {
            Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_sendEmail requ = (Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_sendEmail)request;
            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_emailSent respo = new Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_emailSent(requ);
            serverNotification sn = new serverNotification();
            try
            {
                sn.sendEmail(requ);
            }
            catch (Exception e)
            {

            }


            return respo;
        }

    }
}