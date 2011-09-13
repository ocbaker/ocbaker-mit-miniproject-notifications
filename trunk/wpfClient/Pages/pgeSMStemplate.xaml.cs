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

namespace wpfClient.Pages
{
    /// <summary>
    /// Interaction logic for pgeSMStemplate.xaml
    /// </summary>
    public partial class pgeSMStemplate : Page
    {
        int _count = 0;
        public pgeSMStemplate()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

            //If chr = backspace, -1
            _count += 1;
            byte red = (byte)_count;
            byte green = 150, blue = 150;

            if(_count+150 > 255){
                red = 255;
                blue = 0;
                green = 0;
            }else{
                red = (byte)((int)150 + (int)_count);
                
                blue = (byte)((int)150 - (int)_count);
                green = blue;
            }
            lblSMScount.Foreground = ExtensionServices.fromRGB(red,green,blue);

            lblSMScount.Content = _count + "/160";


        //    if (_count > 150 && _count <161) 
        //    {
        //        lblSMScount.Foreground = ExtensionServices.fromHex("#FF0000");
        //    }
        //    else  if (_count > 160) 
        //    {
        //         lblSMScount.Foreground = ExtensionServices.fromHex("#FF0000");
        //    }
        //    else {
        //        lblSMScount.Foreground = ExtensionServices.fromHex("#FF0000");
        //    }
            
        //    
        }
    }
}
