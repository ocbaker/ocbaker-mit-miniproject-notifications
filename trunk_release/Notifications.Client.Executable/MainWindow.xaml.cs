﻿using System;
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
        public NetworkComms con2;
        public MainWindow()
        {
            InitializeComponent();

            // Insert code required on object creation below this point.
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            con2 = new NetworkComms();
            con2.connect();
        }

        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {
            Client.Core.Core.UI.Dialogs.frmLoginDialog frm = new Core.Core.UI.Dialogs.frmLoginDialog();
            frm.ShowDialog();
        }

        //public void
    }
}
