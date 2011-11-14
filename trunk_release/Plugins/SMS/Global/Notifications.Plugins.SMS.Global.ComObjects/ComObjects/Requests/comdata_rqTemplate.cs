using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Plugins.SMS.Global.ComObjects.Requests
{
    [Serializable]
    public class comdata_rqTemplate : Notifications.Global.Core.Communication.Base.BaseObjects.aBaseRequest
    {
        public comdata_rqTemplate() { }
        public string TempContent;
        public bool retrieveSavedTemp;
        public string username;
    }
}
