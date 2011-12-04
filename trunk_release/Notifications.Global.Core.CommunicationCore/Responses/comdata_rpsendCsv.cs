using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Notifications.Global.Core.Communication.Core.Responses
{
    [Serializable]
    public class comdata_rpsendCsv : Base.BaseObjects.aBaseResponse
    {

        public comdata_rpsendCsv(Global.Core.Communication.Base.BaseObjects.aBaseRequest request) : base(request) { }

        public bool sucessfullSend;
        public DataSet returnedPatients;

    }
}
