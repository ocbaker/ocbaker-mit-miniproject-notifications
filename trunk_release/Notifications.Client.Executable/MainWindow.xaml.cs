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
using Microsoft.Windows.Controls.Ribbon;

namespace Notifications.Client.Executable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public ConnectionV3 con;
        public ConnectionV2 con2;
        public MainWindow()
        {
            InitializeComponent();

            // Insert code required on object creation below this point.
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            con = new ConnectionV3();
            con.startListening ();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            con2 = new ConnectionV2();
            con2.connect();
        }
    }
}
