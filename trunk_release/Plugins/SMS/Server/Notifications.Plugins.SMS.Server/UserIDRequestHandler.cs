using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Notifications.Plugins.SMS.Server
{
    class UserIDRequestHandler : Notifications.Global.Base.Plugin.Server.IRequestHandler
    {

         public void setupHandlers()
        {
            try
            {
              Notifications.Server.Interop.NetworkComms.addDataHandler((new Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqStaff()), Getid);
            } catch (Exception e) 
            {

                }
        }

        public static object Getid(Object request)
        {
            Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqStaff requ = (Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_rqStaff)request;
            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpUserID respo = new Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpUserID(requ);


            try
            {

                SqlConnection mycon = new SqlConnection("server=(local);" +
                                    "Trusted_Connection=yes;" +
                                    "database=PatientNotifications; " +
                                    "connection timeout=30");

                mycon.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Username, ID FROM dbo.Staff WHERE (Username = 'burf9')", mycon);

                da.Fill(ds);
                respo.userID = ds.Tables[0].Rows[0]["ID"].ToString();

                mycon.Close();
            }
            catch (Exception ex)
            {

            }



            return respo;
        }

   
    }
}
