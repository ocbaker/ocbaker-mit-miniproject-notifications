 using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Linq;
using System.Text;

namespace Notifications.Global.Core.Communication.Core.Responses
{
    [DataContract]
    /// <summary>
    /// A class defining the data of a Login Response sent from the server
    /// </summary>
    public class comdata_rtFile
    {

        [DataMember]
        public byte[] File;
    }
}
