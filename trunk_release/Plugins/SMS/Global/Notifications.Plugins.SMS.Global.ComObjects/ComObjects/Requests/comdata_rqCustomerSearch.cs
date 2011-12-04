using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Plugins.SMS.Global.ComObjects.Requests
{
     [Serializable]
    public class comdata_rqCustomerSearch : Notifications.Global.Core.Communication.Base.BaseObjects.aBaseRequest
    {
        public string LookupData;
    }
}
