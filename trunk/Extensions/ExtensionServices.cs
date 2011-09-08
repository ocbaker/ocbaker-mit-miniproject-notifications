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
        #region System.Windows.Controls
        #region Textbox

        public static void SetStatus(this TextBox me, String statusText, TextBoxStatuses status)  {

            switch(status)
            {
                case TextBoxStatuses.ERRORED: 
                    {
                        me.BorderBrush = Brushes.Red;
                        me.Background = Brushes.PaleVioletRed;
                        me.BorderThickness = new System.Windows.Thickness(1);

                        return;
                    }
                case TextBoxStatuses.OK:
                    {
                        me.BorderBrush = Brushes.DarkGreen;
                        me.Background = Brushes.LightGreen;
                        me.BorderThickness = new System.Windows.Thickness(2);
                        return;
                    }
                case TextBoxStatuses.DEFAULT:
                    {
                        me.BorderBrush = Brushes.Gray;
                        me.Background = Brushes.White;
                        me.BorderThickness = new System.Windows.Thickness(0);
                        return;
                    }

            }
        #endregion
        #endregion
            
            
        }
    }

    public enum TextBoxStatuses
	{
	    DEFAULT,
        OK,
        ERRORED
	}
}
