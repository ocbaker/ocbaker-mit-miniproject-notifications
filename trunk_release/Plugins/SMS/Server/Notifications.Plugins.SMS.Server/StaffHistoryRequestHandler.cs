using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Notifications.Plugins.SMS.Server
{
    class StaffHistoryRequestHandler : Notifications.Global.Base.Plugin.Server.IRequestHandler
    {
        public void setupHandlers()
        {
            Notifications.Server.Interop.NetworkComms.addDataHandler((new Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqStaffHistory()), staffHistory);
        }
        public static object staffHistory(Object request)
        {

            Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqStaffHistory requ = (Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqStaffHistory)request;
            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpStaffHistory respo = new Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpStaffHistory(requ);
            try
            {
                SqlConnection mycon = new SqlConnection("server=(local);" +
                                          "Trusted_Connection=yes;" +
                                          "database=PatientNotifications; " +
                                          "connection timeout=30");

                mycon.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter("SELECT FamilyName, GivenName, Email, Mobile, Phone, ReminderText, ReminderDate, Doctor FROM PatientData WHERE (Doctor = '" + requ.staffUsername + "')", mycon);

                da.Fill(ds);
                respo.ds = ds;
                respo.d = new List<Global.ComObjects.Data.data_PatientInformation>();
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Global.ComObjects.Data.data_PatientInformation n = new Global.ComObjects.Data.data_PatientInformation();
                    String[] s = new String[8];
                    int i = 0;
                    foreach (DataColumn d in ds.Tables[0].Columns)
                    {
                        s[i] = r[d].ToString();
                        i++;
                    }
                    try
                    {
                        respo.d.Add((new Global.ComObjects.Data.data_PatientInformation(s[0], s[1], s[2], s[3], s[4], s[5], s[6], s[7])));
                    }
                    catch (Exception exx)
                    {

                    }
                }

                mycon.Close();
            }
            catch (Exception ex)
            {

            }
            return respo;
        }
    }
}
