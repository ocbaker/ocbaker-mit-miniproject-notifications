using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Plugins.SMS.Global.ComObjects.Requests
{
    [Serializable]
    public class comdata_rqEmail : Notifications.Global.Core.Communication.Base.BaseObjects.aBaseRequest
    {
        public comdata_rqEmail() { } 
        public string username;
        public string password;
        public bool getData;
    }
}
