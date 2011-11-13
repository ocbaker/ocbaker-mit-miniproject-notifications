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

namespace Notifications.Global.Base.Plugin.Client.GUIObjects
{
    public abstract partial class aPage : Page, IPage
    {

        public int BaseID()
        {
            throw new NotImplementedException();
        }

        public int RefID()
        {
            throw new NotImplementedException();
        }
    }
}
