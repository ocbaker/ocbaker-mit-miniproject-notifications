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
using System.IO;
using Interop = Notifications.Client.Interop;


namespace Notifications.Plugins.SMS.Client.UI.Pages
{
    /// <summary>
    /// Interaction logic for pgeSMShistory.xaml
    /// </summary>
    public partial class pgeSMShistory : Page
    {
        public pgeSMShistory()
        {
            InitializeComponent();
            
            /// http://www.wpftutorial.net/DataGrid.html
            /// WPF DataGrid c#
            /// http://www.c-sharpcorner.com/uploadfile/mahesh/datagrid-in-wpf/
            /// http://www.codeproject.com/KB/WPF/WPFDataGridExamples.aspx
            /// 
            Notifications.Client.Interop.NetworkComms.addDataHandler((new Global.ComObjects.Response.comdata_rpStaffHistory(new Global.ComObjects.Requests.comdata_rqStaffHistory())), gotHistory, true);
            loadData();
            //bind dataset to wpf datagrid
            //http://stackoverflow.com/questions/1111804/data-binding-a-wpf-datagrid-control-to-a-system-data-datatable-object
            ///http://stackoverflow.com/questions/2511177/how-to-bind-a-table-in-a-dataset-to-a-wpf-datagrid-in-c-sharp-and-xaml

            cbColumnList.Items.Add("GivenName");
            cbColumnList.Items.Add("FamilyName");
            cbColumnList.Items.Add("Email");
            cbColumnList.Items.Add("Mobile");
            cbColumnList.Items.Add("Phone");
            cbColumnList.Items.Add("ReminderText");
            cbColumnList.Items.Add("ReminderDate");
            cbColumnList.Items.Add("Doctor");
            cbColumnList.SelectedIndex = 0;
        }
        private void loadData()
        {
            Global.ComObjects.Requests.comdata_rqStaffHistory gH = new Global.ComObjects.Requests.comdata_rqStaffHistory();
            gH.LookupElement = "Doctor";
            gH.LookupData = Interop.PropertiesManager.GetProperty("User.Username").ToString();
            Notifications.Client.Interop.NetworkComms.sendMessage(gH);
        }
        private object gotHistory(Object response)
        { 
            Global.ComObjects.Response.comdata_rpStaffHistory r = (Global.ComObjects.Response.comdata_rpStaffHistory)response;
            this.DataContext = r.ds.Tables[0];
            
            return false;  
        }


        private void cbColumnList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbColumnList.SelectedItem.ToString())
            {
                case "ReminderDate":
                    txtPara1.IsEnabled = true;
                    txtPara2.IsEnabled = true;
                    break;
                default:
                    txtPara1.IsEnabled = true;
                    txtPara2.IsEnabled = false;
                    break;
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            Global.ComObjects.Requests.comdata_rqStaffHistory gH = new Global.ComObjects.Requests.comdata_rqStaffHistory();
            gH.LookupElement = cbColumnList.SelectedItem.ToString();
            gH.LookupData = txtPara1.Text;
            Notifications.Client.Interop.NetworkComms.sendMessage(gH);


        } 
    }
}
