using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Notifications.Plugins.SMS.Server
{
    class TemplateRequestHandler : Notifications.Global.Base.Plugin.Server.IRequestHandler
    {
        public void setupHandlers()
        {
            Notifications.Server.Interop.NetworkComms.addDataHandler((new Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqTemplate()), template);
        }

        private static object template(object request)
        {
            Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqTemplate requ = (Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqTemplate)request;
            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpTemplate respo = new Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpTemplate(requ);

            if (requ.retrieveSavedTemp == true)
            {
                try {
                // Connect to database and GET the template and put into respo.retrieved_data
                SqlConnection mycon = new SqlConnection("server=(local);" +
                                       "Trusted_Connection=yes;" +
                                       "database=PatientNotifications; " +
                                       "connection timeout=30");

                mycon.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Username, SMStemplate FROM  dbo.Staff WHERE (Username = N'" + requ.username + "')", mycon);

               

                da.Fill(ds);
                
                
                    respo.retrieved_data = ds.Tables[0].Rows[0]["SMStemplate"].ToString();
                    mycon.Close();
                }
                catch (Exception ex)
                {

                }
            }
            else
            { 
                // Connect to database and replace the template with the requ.TempContent

                SqlConnection mycon = new SqlConnection("server=(local);" +
                                       "Trusted_Connection=yes;" +
                                       "database=PatientNotifications; " +
                                       "connection timeout=30");

                mycon.Open();

                SqlCommand com = new SqlCommand("UPDATE dbo.Staff SET SMStemplate='" + requ.TempContent+ "' WHERE Username='" + requ.username + "';", mycon);
                try
                {
                    com.ExecuteNonQuery();
                    respo.retrieved_data = requ.TempContent;
                }
                catch (Exception e)
                {

                }
                mycon.Close();
            }

            
            return respo;
        }
    }
}
