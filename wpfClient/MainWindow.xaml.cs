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

namespace wpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public static Dictionary<Page, String> StateDictionary;
        
        //Need to make a list of pages, with objects to save state. Save the states in here, 
        //Load them from here when needed.

        public MainWindow()
        {
            InitializeComponent();
            
            // Insert code required on object creation below this point.
        }

        private void Ribbon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count == 0) 
            {
                return;
            } else {
                switch (((RibbonTab)e.AddedItems[0]).Name)
                {
                    case "admTab":
                        changePage("pgeAdmin");
                        break;
                    case "SMSTab":
                        changePage("pgeSMS");
                        break;
                    case "HomeTab":
                        changePage("pgeLogin");
                        break;
                    default:
                        break;
                }
            }
            
        }

        private void SendSMS_Click(object sender, RoutedEventArgs e)
        {
            changePage("pgeSMS");
        }
        private void smsTemplate_Click(object sender, RoutedEventArgs e)
        {
            changePage("pgeSMStemplate");
        }
        private void smsHistory_Click(object sender, RoutedEventArgs e)
        {
            changePage("pgeSMShistory");
        }
        private void changePage(string arg0) 
        {
            frame1.NavigationService.Source = new Uri("/Pages/"+ arg0 + ".xaml", UriKind.Relative);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            changePage("Administration/admSMS");
        }
    }
}
