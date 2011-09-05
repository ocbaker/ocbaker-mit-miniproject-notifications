using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Linq;
using System.Text;

namespace Extensions.ConnectionCom.Classes
{
    [DataContract()]
    public class RequestObject<t>
    {
        [DataMember]
        public string action;

        [DataMember]
        public int responseid;

        [DataMember]
        public t data;
    }
}
