using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Linq;
using System.Text;

namespace Notifications.Global.Core.Communication.Base.BaseObjects
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
