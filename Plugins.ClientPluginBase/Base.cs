using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Windows.Controls.Ribbon;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Plugins.ClientPluginBase
{
    /// <summary>
    /// Provides the base class for a Plugin used by the client.
    /// </summary>
    public abstract class Base
    {

        #region Variables

        private RibbonTab _bindingRibbonTab;
        private List<Page> _bindingRibbonPages;

        #endregion

        #region Constructors

        public Base(List<Page> ribbonPages, RibbonTab ribbonTab = null)
        {

        }
        #endregion

        #region Properties

        #endregion

        #region Methods

        #endregion
    }
}
