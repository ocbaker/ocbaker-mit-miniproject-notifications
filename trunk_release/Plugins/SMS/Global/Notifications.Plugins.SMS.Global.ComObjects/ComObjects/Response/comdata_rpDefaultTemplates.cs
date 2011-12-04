using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Notifications.Plugins.SMS.Global.ComObjects.Response
{
    [Serializable]
    public class comdata_rpDefaultTemplates : Notifications.Global.Core.Communication.Base.BaseObjects.aBaseResponse
    {
        public comdata_rpDefaultTemplates(Notifications.Global.Core.Communication.Base.BaseObjects.aBaseRequest request) : base(request) { }

        public DataSet retrievedData;
        public bool dataresponse;
       public string templateName;
       public string templateText;

    }
}
