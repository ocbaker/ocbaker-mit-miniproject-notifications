using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Plugins.SMS.Global.ComObjects.Requests
{
    [Serializable]
    public class comdata_sendSMS : Notifications.Global.Core.Communication.Base.BaseObjects.aBaseRequest
    {
        public comdata_sendSMS() { }

        public string sms_to;
        public string sms_from;
        public string msg_content;
        public string unicode;
        public string schedule;
        public string msg_type;
        public string response;
    }
}
