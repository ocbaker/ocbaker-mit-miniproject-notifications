 using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Linq;
using System.Text;

namespace Extensions.ConnectionCom.Classes.Requests
{
    [DataContract]
    /// <summary>
    /// A class defining the data of a Login Request sent to the server
    /// </summary>
    public class comdata_rqLogin
    {
        [DataMember]
        public string username;

        [DataMember]
        public string password;
    }
}
