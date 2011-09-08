using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugins.PluginController.Client
{
    /// <summary>
    /// Used by the client as an Entry Point for Client Plugins
    /// </summary>
    public abstract class EntryPoint : EntryPointBase
    {

        #region Variables

        private List<String> LoadedPlugins;
        private String pluginsFolder = "ClientPlugins";

        #endregion

        #region Constructors

        /// <summary>
        /// Required Constructor
        /// </summary>
        public EntryPoint()
            : base("ServerPlugins")
        {
            LoadedPlugins = new List<string>();
            pluginsFolder = "ClientPlugins";
        }

        #endregion

        #region Methods

        public void LoadPlugins(){

        }

        #endregion

        #region Properties

        #endregion

    }
}
