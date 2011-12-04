using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Plugins.SMS.Global.ComObjects.Requests
{
    [Serializable]
    public class comdata_rqDefaultTemplates : Notifications.Global.Core.Communication.Base.BaseObjects.aBaseRequest
    {
        public comdata_rqDefaultTemplates() { }

       public string templateName;
       public string templateText;
       public bool newTemplate;
       public bool getALL;
    }
}
