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
using Interop = Notifications.Client.Interop;

namespace Notifications.Plugins.Administration.Client.UI.Tabs
{
    /// <summary>
    /// Interaction logic for tabAdminTab.xaml
    /// </summary>
    public partial class tabAdminTab : RibbonTab
    {
        public tabAdminTab()
        {
            Console.WriteLine("lol");
            InitializeComponent();
            //Interop.EventManager.handleEvent("Client.LoggedIn",LoggedIn);
            //Interop.EventManager.handleEvent("Client.LoggedOut", LoggedOut);
            Interop.EventManager.handleEvent("Plugin.Administration.Tab.AddGroup", addGroup);
            Console.WriteLine("Administration Tab Initialized");
        }

        private void addGroup(object group)
        {
            //RibbonGroup rGroup = (RibbonGroup)group;
            this.Items.Add(group);
        }
        private void LoggedIn()
        {
            Console.WriteLine("Administration LoggedIn Function Running");
            //Interop.EventManager.raiseEvents("Client.Window.AddTab", (Object)this);
        }
        private void LoggedOut()
        {
            //Interop.EventManager.raiseEvents("Client.Window.RemoveTab", (Object)this);
        }
    }
}