using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Plugins.SMS.Global.ComObjects.Requests
{
    [Serializable]
    public class comdata_rqStaff : Notifications.Global.Core.Communication.Base.BaseObjects.aBaseRequest
    {
        public comdata_rqStaff() { }
        public string username;
    }
}
