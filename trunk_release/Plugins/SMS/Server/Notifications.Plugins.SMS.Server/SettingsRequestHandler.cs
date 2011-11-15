﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Notifications.Plugins.SMS.Server
{
    class SettingsRequestHandler : Notifications.Global.Base.Plugin.Server.IRequestHandler
    {
        public void setupHandlers()
        {
            Notifications.Server.Interop.NetworkComms.addDataHandler((new Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqSMSGlobal()), smsGlobalsaveToDatabase);
            Notifications.Server.Interop.NetworkComms.addDataHandler((new Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqProxy()), EmailsaveToDatabase);
            Notifications.Server.Interop.NetworkComms.addDataHandler((new Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqEmail()), ProxysaveToDatabase);
        }

        private static object smsGlobalsaveToDatabase(Object request)
        {

            Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqSMSGlobal requ = (Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqSMSGlobal)request;
            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpSMSGlobal respo = new Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpSMSGlobal(requ);

            if (requ.getData == true)
            {
                // GET the data respo.username = 'Username' | respo.password = 'Password'

                SqlConnection mycon = new SqlConnection("server=(local);" +
                                       "Trusted_Connection=yes;" +
                                       "database=PatientNotifications; " +
                                       "connection timeout=30");

                mycon.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter("SELECT [Key], Value FROM dbo.Settings WHERE ([Key] = 'SMSGlobalusername') OR ([Key] = 'SMSGlobalpassword'", mycon);
                
                da.Fill(ds);
                respo.username = ds.Tables[0].Rows[0]["Value"].ToString();
                respo.password = ds.Tables[0].Rows[1]["Value"].ToString();
                
                mycon.Close();
                respo.dataRetrieved = true;
            }
            else
            {
                // POST data to the server using Use requ.username and requ.password 
                try
                {
                    SqlConnection mycon = new SqlConnection("server=(local);" +
                                       "Trusted_Connection=yes;" +
                                       "database=PatientNotifications; " +
                                       "connection timeout=30");

                    mycon.Open();

                    SqlCommand com = new SqlCommand("UPDATE dbo.Settings SET Value=N'" + requ.username + "', Value=N'" + requ.password + "' WHERE [Key] = 'SMSGlobalusername', [Key] = 'SMSGlobalpassword';", mycon);
                    com.ExecuteNonQuery();
                    mycon.Close();

                    respo.SaveSucessful = true;
                }
                catch (Exception ex)
                {
                    respo.SaveSucessful = false;
                }
                respo.dataRetrieved = false;
            }
            

            return respo;
        }
        private static object EmailsaveToDatabase(Object request)
        {

            Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqEmail requ = (Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqEmail)request;
            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpEmail respo = new Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpEmail(requ);

            if (requ.getData == true)
            {
                // GET the data respo.username = 'Username' | respo.password = 'Password'

                SqlConnection mycon = new SqlConnection("server=(local);" +
                                       "Trusted_Connection=yes;" +
                                       "database=PatientNotifications; " +
                                       "connection timeout=30");

                mycon.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter("SELECT [Key], Value FROM dbo.Settings WHERE ([Key] = 'Mailusername') OR ([Key] = 'Mailpassword'", mycon);

                da.Fill(ds);
                respo.username = ds.Tables[0].Rows[0]["Value"].ToString();
                respo.password = ds.Tables[0].Rows[1]["Value"].ToString();

                mycon.Close();

                respo.dataRetrieved = true;
            }
            else
            {
                // POST data to the server using Use requ.username and requ.password 
                try
                {

                    SqlConnection mycon = new SqlConnection("server=(local);" +
                                       "Trusted_Connection=yes;" +
                                       "database=PatientNotifications; " +
                                       "connection timeout=30");

                    mycon.Open();

                    SqlCommand com = new SqlCommand("UPDATE dbo.Settings SET Value=N'" + requ.username + "', Value=N'" + requ.password + "' WHERE [Key] = 'Mailusername', [Key] = 'Mailpassword';", mycon);
                    com.ExecuteNonQuery();
                    mycon.Close();

                    respo.SaveSucessful = true;
                }
                catch (Exception ex)
                {
                    respo.SaveSucessful = false;
                }
                respo.dataRetrieved = false;
            }


            return respo;
        }
        private static object ProxysaveToDatabase(Object request)
        {

            Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqProxy requ = (Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqProxy)request;
            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpProxy respo = new Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpProxy(requ);

        


            if (requ.getData == true)
            {
                // GET the data respo.username = 'Username' | respo.password = 'Password'

                SqlConnection mycon = new SqlConnection("server=(local);" +
                                      "Trusted_Connection=yes;" +
                                      "database=PatientNotifications; " +
                                      "connection timeout=30");

                mycon.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter("SELECT [Key], Value FROM dbo.Settings WHERE ([Key] = 'Proxyusername') OR ([Key] = 'Proxypassword'", mycon);

                da.Fill(ds);
                respo.username = ds.Tables[0].Rows[0]["Value"].ToString();
                respo.password = ds.Tables[0].Rows[1]["Value"].ToString();

                mycon.Close();

                respo.dataRetrieved = true;
            }
            else
            {
                // POST data to the server using Use requ.username and requ.password 
                try
                {
                    SqlConnection mycon = new SqlConnection("server=(local);" +
                                       "Trusted_Connection=yes;" +
                                       "database=PatientNotifications; " +
                                       "connection timeout=30");

                mycon.Open();

                SqlCommand com = new SqlCommand("UPDATE dbo.Settings SET Value=N'" + requ.username + "', Value=N'" + requ.password + "' WHERE [Key] = 'Proxyusername', [Key] = 'Proxypassword';", mycon);
                com.ExecuteNonQuery();
                mycon.Close();
                    respo.SaveSucessful = true;
                }
                catch (Exception ex)
                {
                    respo.SaveSucessful = false;
                }
                respo.dataRetrieved = false;
            }

            return respo;
        }
    }
}