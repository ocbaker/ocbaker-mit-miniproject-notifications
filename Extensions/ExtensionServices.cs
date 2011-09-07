using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Extensions
{
    static class ExtensionServices
    {
        [Extension()]
        public static void SetStatus(ref TextBox me, String statusText, TextBoxStatuses status){

        }
    }

    public static enum TextBoxStatuses
	{
	    BLANK,
        OK,
        ERRORED
	}
}
