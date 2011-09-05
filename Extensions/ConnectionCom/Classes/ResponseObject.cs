using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Linq;
using System.Text;

namespace Extensions.ConnectionCom.Classes
{
    [DataContract]
    public class ResponseObject<t>
    {
        [DataMember]
        public int repsoneid;

        [DataMember]
        public int error_code;

        [DataMember]
        public t data;
    }
}
