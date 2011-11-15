using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Plugins.SMS.Global.ComObjects.Requests
{
    [Serializable]
    public class comdata_sendEmail : Notifications.Global.Core.Communication.Base.BaseObjects.aBaseRequest
    {
        public comdata_sendEmail() { }
        public object vSendSMS;
        public string email_to;
        public string msg_content;
    }
}
