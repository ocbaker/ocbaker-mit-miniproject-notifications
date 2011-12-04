using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Notifications.Plugins.SMS.Global.ComObjects.Response
{
    [Serializable]
    public class comdata_rpCustomerSearch : Notifications.Global.Core.Communication.Base.BaseObjects.aBaseResponse
    {
        public comdata_rpCustomerSearch(Notifications.Global.Core.Communication.Base.BaseObjects.aBaseRequest request) : base(request) { }
        public DataSet ds;
        public List<Data.data_PatientInformation> d;
        public string work;
    }
}
