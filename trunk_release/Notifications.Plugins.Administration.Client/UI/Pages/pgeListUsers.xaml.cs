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
using Interop = Notifications.Client.Interop;

namespace Notifications.Plugins.Administration.Client.UI.Pages
{
    /// <summary>
    /// Interaction logic for pgeListUsers.xaml
    /// </summary>
    public partial class pgeListUsers : Page
    {
        public pgeListUsers()
        {
            InitializeComponent();
            Interop.NetworkComms.addDataHandler((new Global.ComObjects.Responses.rp_getUserList(new Global.ComObjects.Requests.rq_getUserList(), null)), handleResponse,true);
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsVisible)
            {
                Interop.NetworkComms.sendMessage(new Global.ComObjects.Requests.rq_getUserList());
            }
        }
        private object handleResponse(object rawResponse)
        {
            Global.ComObjects.Responses.rp_getUserList response = (Global.ComObjects.Responses.rp_getUserList)rawResponse;
            foreach (Global.ComObjects.Data.data_UserInfo userInfo in response.userList)
            {
                lbUsers.Items.Add("(" + userInfo.username + ") - " + userInfo.FirstName + " " + userInfo.LastName);
            }

            return false;
        }
    }
}
