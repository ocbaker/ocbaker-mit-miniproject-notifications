using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Notifications.Server.Core.Core.RequestHandlers
{
    class PatientRequestHandler : Notifications.Global.Base.Plugin.Server.IRequestHandler
    {
        public void setupHandlers()
        {         }

        private static DataSet patients(List<String[]> s, Notifications.Global.Core.Communication.Core.Data.UserInformation uI)
        {
            DataSet ds = new DataSet();
            try
            {
                DataTable dt = ds.Tables.Add();
                try
                {
                    dt.Columns.Add("FamilyName");
                    dt.Columns.Add("GivenName");

                    dt.Columns.Add("Email");
                    dt.Columns.Add("Mobile");
                    dt.Columns.Add("Phone");
                    dt.Columns.Add("ReminderText");
                    dt.Columns.Add("ReminderDate");
                    dt.Columns.Add("Doctor");

                    try
                    {
                        foreach (string[] p in s)
                        {
                            DataRow dr = dt.NewRow();
                            try
                            {
                                dr["FamilyName"] = p[0];
                                dr["GivenName"] = p[1];
                                dr["Email"] = p[2];
                                dr["Mobile"] = p[3].ToString();
                                dr["Phone"] = p[4].ToString();
                                dr["ReminderText"] = p[5].ToString();
                                dr["ReminderDate"] = p[6].ToString();
                                dr["Doctor"] = uI.username;
                            }
                            catch (Exception ex)
                            {

                            }

                            dt.Rows.Add(dr);

                            //ds.Tables["patients"].Rows.Add(dr);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

                catch (Exception ex)
                {

                }
                
            }
            catch (Exception ex)
            {

            }
            return ds;
        }
        [Server.Interop.RequestHandlerMethod(typeof(Notifications.Global.Core.Communication.Core.Requests.comdata_rqsendCsv))]
        public static object Patients(object request)
        {
            Notifications.Global.Core.Communication.Core.Requests.comdata_rqsendCsv requ = (Notifications.Global.Core.Communication.Core.Requests.comdata_rqsendCsv)request;
            Notifications.Global.Core.Communication.Core.Responses.comdata_rpsendCsv respo = new Notifications.Global.Core.Communication.Core.Responses.comdata_rpsendCsv(requ);
            Notifications.Global.Core.Communication.Core.Data.UserInformation uI = (Notifications.Global.Core.Communication.Core.Data.UserInformation)requ._userInformation;
           
            SqlConnection mycon;
            try
            {
                mycon = new SqlConnection("server=(local);" +
                                                   "Trusted_Connection=yes;" +
                                                   "database=PatientNotifications; " +
                                                   "connection timeout=30");
                mycon.Open();
                foreach (string[] a in requ.parsedPatients)
                {
                    try
                    {
                        SqlCommand com = new SqlCommand("INSERT INTO PatientData (FamilyName,GivenName,Email,Mobile,Phone,ReminderText,ReminderDate,Doctor) VALUES ('" + a[0] + "','" + a[1] + "','" + a[2] + "','" + a[3] + "','" + a[4] + "','" + a[5] + "'," + "@mydate" + ",'" + uI.username + "')", mycon);

                        SqlParameter sqlpar = new SqlParameter();
                        sqlpar.ParameterName = "@mydate";
                        sqlpar.SqlDbType = SqlDbType.DateTime;
                        sqlpar.Value = a[6];
                        com.Parameters.Add(sqlpar);

                        com.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        respo.sucessfullSend = false;
                    }
                }
                mycon.Close();
            }
            catch (Exception ex)
            {

            }

            respo.sucessfullSend = true;

            respo.returnedPatients = patients(requ.parsedPatients, uI);
           
           
           
            
            return respo;
        }

    }
}
