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

namespace wpfClient.Pages
{
    /// <summary>
    /// Interaction logic for pgeLogin.xaml
    /// </summary>
    public partial class pgeLogin : Page
    {
        public pgeLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var obj = this.Parent;
        }
    }
}
