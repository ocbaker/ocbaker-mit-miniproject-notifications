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
using Notifications.Plugins.SMS.Server;
using Notifications.Global.Core.Utils;


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
            lblSMScount.Content = _count + "/160";
        }

        private void btnTemplateSave_Click(object sender, RoutedEventArgs e)
        {
            //Save to a User profile.
        }
    }
}
