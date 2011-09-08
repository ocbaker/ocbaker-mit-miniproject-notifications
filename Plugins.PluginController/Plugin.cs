using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugins.PluginController
{
    /// <summary>
    /// Identifies a Plugin Object and its components
    /// </summary>
    internal class Plugin
    {

        #region Variables

        private string _assemblyFilename;
        private string _author;
        private Version _version;
        private string _description;

        #endregion

        #region Constructors

        public Plugin(string assemblyFileName)
        {
            //Load Assembly XML Definition

            //Write Definitions

            //Finished
        }

        #endregion

        #region Properties

        public string assemblyFilename{
         get { return _assemblyFilename; }
        }
        public string author{
            get { return _author; }
        }
        public Version version{
            get{ return new Version(_version.ToString()); }
        }
        public string description{
            get { return _description; }
        }

        #endregion

    }
}
