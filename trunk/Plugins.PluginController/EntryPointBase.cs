using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugins.PluginController
{
    internal class EntryPointBase
    {

        
        #region Variables
        private List<Plugin> _loadedPlugins;
        private String _pluginsFolder;
        #endregion

        #region Constructors

        internal EntryPointBase(string PluginsFolder){
            _loadedPlugins = new List<string>();
            _pluginsFolder = PluginsFolder;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use this method to load plugins from the plugin folder.
        /// </summary>
        public void LoadPlugins()
        {

        }
        /// <summary>
        /// Used to unload a plugin from 
        /// </summary>
        public void UnLoadPlugin(){


        }

        #endregion

        #region Properties

        internal String pluginsFolder{
            get { return _pluginsFolder; }
        }
        internal List<Plugin> loadedPlugins{
            get { return _loadedPlugins; }
        }
        

        #endregion
    }
}
