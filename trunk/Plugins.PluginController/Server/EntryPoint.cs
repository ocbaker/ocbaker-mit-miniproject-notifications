using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugins.PluginController.Server
{
    /// <summary>
    /// Used by the server as an Entry Point for Plugins
    /// </summary>
    public class EntryPoint : EntryPointBase
    {
        #region Variables
        
        private String pluginsFolder = "ServerPlugins";
        #endregion

        #region Constructors

        /// <summary>
        /// Required Constructor
        /// </summary>
        public EntryPoint() :base("ServerPlugins")
        {
            

            
        }

        ///// <summary>
        ///// Required Constructor
        ///// </summary>
        //public EntryPoint(String arg0) : base("ServerPlugins",arg0)
        //{



        //}

        #endregion

        #region Methods

        /// <summary>
        /// Use this method to load plugins from the plugin folder.
        /// </summary>
        public void LoadPlugins()
        {

        }

        public void UnLoadPlugin(){


        }

        #endregion

        #region Properties

        #endregion
    }
}
