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
        {
            Notifications.Server.Interop.NetworkComms.addDataHandler((new Notifications.Global.Core.Communication.Core.Requests.comdata_rqsendCsv()), Patients);
        }

        public static object Patients(Object request)
        {
            Notifications.Global.Core.Communication.Core.Requests.comdata_rqsendCsv requ = (Notifications.Global.Core.Communication.Core.Requests.comdata_rqsendCsv)request;
            Notifications.Global.Core.Communication.Core.Responses.comdata_rpsendCsv respo = new Notifications.Global.Core.Communication.Core.Responses.comdata_rpsendCsv(requ);

            foreach (string[] a in requ.parsedPatients)
            {
                try
                {
                    SqlConnection mycon = new SqlConnection("server=(local);" +
                                               "Trusted_Connection=yes;" +
                                               "database=PatientNotifications; " +
                                               "connection timeout=30");

                    mycon.Open();
                    //Isn't finished. VALUES () part of the statement is unfinished.
                    SqlCommand com = new SqlCommand("INSERT INTO PatientData (FamilyName,GivenName, Email, Mobile, Phone, ReminderText, ReminderDate) VALUES (" + a[0] + "," + a[1] + "," + a[2] + "," + a[3] + "," + a[4] + "," + a[5] + "," + a[6] + ")", mycon);
                    com.ExecuteNonQuery(); // Force quit when trying to execute this line. SMS sends fine. 
                    mycon.Close();
                }
                catch (Exception ex)
                {
                    respo.sucessfullSend = false;
                }

            }
            respo.sucessfullSend = true;
            
            return respo;
        }

    }
}
