using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Plugins.SMS.Global.ComObjects.Response
{
[Serializable]
    public class comdata_rpSMSGlobal : Notifications.Global.Core.Communication.Base.BaseObjects.aBaseResponse
    {

            public comdata_rpSMSGlobal(Notifications.Global.Core.Communication.Base.BaseObjects.aBaseRequest request) : base(request) { }
            public bool SaveSucessful;
            public bool dataRetrieved;
            public string username;
            public string password;
    }
}
