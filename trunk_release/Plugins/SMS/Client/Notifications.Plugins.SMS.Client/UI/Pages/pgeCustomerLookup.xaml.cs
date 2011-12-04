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

namespace Notifications.Plugins.SMS.Client.UI.Pages
{
    /// <summary>
    /// Interaction logic for pgeCustomerLookup.xaml
    /// </summary>
    public partial class pgeCustomerLookup : Page
    {
        public pgeCustomerLookup()
        {
            InitializeComponent();

            Notifications.Client.Interop.NetworkComms.addDataHandler((new Global.ComObjects.Response.comdata_rpCustomerSearch(new Global.ComObjects.Requests.comdata_rqCustomerSearch())), search);

            Global.ComObjects.Requests.comdata_rqCustomerSearch rTemp = new Global.ComObjects.Requests.comdata_rqCustomerSearch();
            rTemp.LookupData = "smurf";
            Notifications.Client.Interop.NetworkComms.sendMessage(rTemp);
        }
        public object search(Object response)
        {
            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpCustomerSearch t = (Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpCustomerSearch)response;

            //this.DataContext = 




            return false;
        }
    }
}
