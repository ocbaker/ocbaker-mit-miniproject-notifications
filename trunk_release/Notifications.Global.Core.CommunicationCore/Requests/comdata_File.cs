 using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Linq;
using System.Text;

namespace Notifications.Global.Core.Communication.Core.Requests
{
    [Serializable]
    /// <summary>
    /// A class defining the data of a Login Request sent to the server
    /// </summary>
    public class comdata_rqFile
    {
        
        public string FileName;

        
        public byte[] File;
    }
}
