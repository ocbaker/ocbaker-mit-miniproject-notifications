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

namespace wpfClientPluginTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            // Insert code required on object creation below this point.
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            plgTabAdmin plg = new plgTabAdmin();
            ribbon.Items.Add(plg);
            
        }
    }
}
