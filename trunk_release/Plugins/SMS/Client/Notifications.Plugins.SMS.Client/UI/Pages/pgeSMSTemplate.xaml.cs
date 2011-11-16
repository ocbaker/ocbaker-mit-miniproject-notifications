using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Notifications.Plugins.SMS.Server;
using Notifications.Global.Core.Utils;
using Interop = Notifications.Client.Interop;


namespace Notifications.Plugins.SMS.Client.UI.Pages
{
    /// <summary>
    /// Interaction logic for pgeSMSTemplate.xaml
    /// </summary>
    public partial class pgeSMSTemplate : Page
    {
        int _count = 0;
        public pgeSMSTemplate()
        {
            InitializeComponent();
            lblSMScount.Content = _count + "/160";

            Notifications.Client.Interop.NetworkComms.addDataHandler((new Global.ComObjects.Response.comdata_rpTemplate(new Global.ComObjects.Requests.comdata_rqTemplate())), template);

            getPreviousTemplate();

        }
        private object template(Object request)
        {

            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpTemplate t = (Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpTemplate)request;

            if (t.POST == true)
            {
                if (t.successfulSave == true)
                {
                    textBox1.Text = HttpUtility.HtmlDecode(t.retrieved_data);
                    _count = HttpUtility.HtmlDecode(t.retrieved_data).Length;
                    lblSMScount.Content = _count + "/160";
                    lblmsgResponse.Foreground = ExtensionServices.fromRGB(40, 155, 66);
                    lblmsgResponse.Content = "Template successfully saved!";
                }
                else
                {
                    lblmsgResponse.Foreground = ExtensionServices.fromRGB(40, 155, 66);
                    lblmsgResponse.Content = "Template failed to saved!";
                }
            } else {
                textBox1.Text = HttpUtility.HtmlDecode(t.retrieved_data);
                _count = HttpUtility.HtmlDecode(t.retrieved_data).Length;
                lblSMScount.Content = _count + "/160";
            }
            return false;  
        }
        private void getPreviousTemplate()
        {
            Global.ComObjects.Requests.comdata_rqTemplate rTemp = new Global.ComObjects.Requests.comdata_rqTemplate();
            rTemp.TempContent = null;
            rTemp.retrieveSavedTemp = true;
            Notifications.Client.Interop.NetworkComms.sendMessage(rTemp);
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            byte red = (byte)_count;
            byte green = 150, blue = 150;

            if (_count + 150 > 255)
            {
                red = 255;
                blue = 0;
                green = 0;
            }
            else
            {
                red = (byte)((int)150 + (int)_count);

                blue = (byte)((int)150 - (int)_count);
                green = blue;
            }
            lblSMScount.Foreground = ExtensionServices.fromRGB(red, green, blue);

            if (Keyboard.IsKeyDown(Key.Back))
            {
                _count -= 1;
            }
            else
            {
                _count += 1;
            }
            if (_count > 160)
            {
                btnTemplateSave.IsEnabled = false;
            } else {
                btnTemplateSave.IsEnabled = true;
            }

            _count = textBox1.Text.Length;

            lblSMScount.Content = _count + "/160";
            lblmsgResponse.Content = "";
        }
        private void btnTemplateSave_Click(object sender, RoutedEventArgs e)
        {
            lblmsgResponse.Content = "";
            //Save to a User profile.
            Global.ComObjects.Requests.comdata_rqTemplate rTemp = new Global.ComObjects.Requests.comdata_rqTemplate();
            rTemp.TempContent = textBox1.Text;
            rTemp.retrieveSavedTemp = false;
            rTemp.username = Interop.PropertiesManager.GetProperty("User.Username").ToString();
            
             Notifications.Client.Interop.NetworkComms.sendMessage(rTemp);
            

                        
        }
    }
}
