using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;

namespace Extensions
{
    public static class ExtensionServices
    {
        public static void SetStatus(this TextBox me, String statusText, TextBoxStatuses status)  {



            me.BorderBrush = Brushes.SlateBlue;
            
        }
    }

    public enum TextBoxStatuses
	{
	    BLANK,
        OK,
        ERRORED
	}
}
