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
        private static Brush DefaultBorderBrush;
        public static void SetStatus(this TextBox me, String statusText, TextBoxStatuses status)  {
            if (DefaultBorderBrush == null){
                DefaultBorderBrush = me.BorderBrush;

            }
            switch(status)
            {
                case TextBoxStatuses.ERRORED: 
                    {
                        me.BorderBrush = fromHex("#CD0A0A");
                        me.Background = fromHex("#FEF1EC");
                        me.BorderThickness = new System.Windows.Thickness(1);
                        return;
                    }
                case TextBoxStatuses.OK:
                    {
                        me.BorderBrush = fromHex("#8CCE3B");
                        me.Background = fromHex("#F1FBE5");
                        me.BorderThickness = new System.Windows.Thickness(1);
                        return;
                    }
                case TextBoxStatuses.DEFAULT:
                    {
                        me.BorderBrush = DefaultBorderBrush;
                        me.Background = Brushes.White;
                        me.BorderThickness = new System.Windows.Thickness(1);
                        return;
                    }
            }
        #endregion
        #endregion

            
        }
        #region System.Windows.Media
        #region Brushes

            public static Brush fromHex(string hex) 
            {
                BrushConverter bc = new BrushConverter();
                return (Brush)bc.ConvertFrom(hex);

            }

#endregion
#endregion
    }

    public enum TextBoxStatuses
	{
	    DEFAULT,
        OK,
        ERRORED
	}
}
