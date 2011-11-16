using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Global.Core.Communication.Core.Requests
{
    [Serializable]
    public class comdata_rqsendCsv : Global.Core.Communication.Base.BaseObjects.aBaseRequest
    {
        public List<String[]> parsedPatients;
    }
}
