 using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Linq;
using System.Text;

namespace Extensions.ConnectionCom.Classes.Responses
{
    [DataContract]
    /// <summary>
    /// A class defining the data of a Login Response sent from the server
    /// </summary>
    public class comdata_rtLogin
    {

        [DataMember]
        public bool loginSuccessful;
    }
}
