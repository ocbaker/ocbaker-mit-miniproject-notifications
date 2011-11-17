using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Interop = Notifications.Client.Interop;

namespace Notifications.Plugins.SMS.Client.UI.Pages
{
    /// <summary>
    /// Interaction logic for pgeSMShistory.xaml
    /// </summary>
    public partial class pgeSMShistory : Page
    {
        public static System.Data.DataSet DSPatients { get; set; }

        public pgeSMShistory()
        {
            
            /// http://www.wpftutorial.net/DataGrid.html
            /// WPF DataGrid c#
            /// http://www.c-sharpcorner.com/uploadfile/mahesh/datagrid-in-wpf/
            /// http://www.codeproject.com/KB/WPF/WPFDataGridExamples.aspx
            /// 
            Notifications.Client.Interop.NetworkComms.addDataHandler((new Global.ComObjects.Response.comdata_rpStaffHistory(new Global.ComObjects.Requests.comdata_rqStaffHistory())), gotHistory);

            Global.ComObjects.Requests.comdata_rqStaffHistory gH = new Global.ComObjects.Requests.comdata_rqStaffHistory();
            gH.staffUsername = Interop.PropertiesManager.GetProperty("User.Username").ToString();
            Notifications.Client.Interop.NetworkComms.sendMessage(gH);

          

            InitializeComponent();
        }

        public void loadsourcedata() { }

        private static object gotHistory(Object response)
        {   // Does not get a reply back from the server????

            Global.ComObjects.Response.comdata_rpStaffHistory r = (Global.ComObjects.Response.comdata_rpStaffHistory)response;

            DSPatients = r.ds;

            //Data

            //DataGrid d = new DataGrid();

            //foreach (Global.ComObjects.Data.data_PatientInformation dp in r.d)
            //{
            //    d.Items.Add(dp.FamilyName);
            //    d.Items.Add(dp.GivenName);
            //    d.Items.Add(dp.Email);
            //    d.Items.Add(dp.Mobile);
            //    d.Items.Add(dp.Phone);
            //    d.Items.Add(dp.ReminderText);
            //    d.Items.Add(dp.ReminderDate);
            //    d.Items.Add(dp.Doctor);
            //}



            return false;  
        } 
    }
}
//<DataGrid AutoGenerateColumns="False" Height="339" HorizontalAlignment="Left" Margin="12,76,0,0"  Name="dgvSMSaHistory" VerticalAlignment="Top" Width="374" ItemsSource="{Binding ElementName=dgvSMSaHistory}">
//            <DataGrid.Columns>
//                <DataGridTemplateColumn Header="FamilyName" Width="80" IsReadOnly="True">
                    
//                </DataGridTemplateColumn>
                
               
//            </DataGrid.Columns>    
            
//         </DataGrid>
