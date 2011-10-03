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
using Extensions;

namespace wpfClient.Pages.Administration
{
    /// <summary>
    /// Interaction logic for admSMS.xaml
    /// </summary>
    public partial class admSMS : Page
    {
        apiValidateLogin Login= pgeSMS.vlogin;
        public admSMS()
        {
            InitializeComponent();
        }

        public void txtUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            try {
                Login.APIusername = txtUsername.Text;
                txtUsername.SetStatus("OK", TextBoxStatuses.OK);
            } catch (ArgumentException ex) {
                txtUsername.SetStatus("Error", TextBoxStatuses.ERRORED);
            }
        }
        public void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            try {
                Login.APIpassword = txtPassword.Text;
                txtPassword.SetStatus("OK", TextBoxStatuses.OK);
            } catch (ArgumentException ex) {
                txtPassword.SetStatus("Error", TextBoxStatuses.ERRORED);
            }

        }

        private void btnLoginSave_Click(object sender, RoutedEventArgs e)
        {
            //Send the username/password to the Settings Project.
        }
    }
}
