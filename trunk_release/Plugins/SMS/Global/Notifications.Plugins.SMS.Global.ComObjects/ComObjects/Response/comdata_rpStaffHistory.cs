using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Notifications.Plugins.SMS.Global.ComObjects.Response
{
    [Serializable]
    public class comdata_rpStaffHistory : Notifications.Global.Core.Communication.Base.BaseObjects.aBaseResponse
    {
        public comdata_rpStaffHistory(Notifications.Global.Core.Communication.Base.BaseObjects.aBaseRequest request) : base(request) { }
        public List<Data.data_PatientInformation> d;
        public DataSet ds;

    }
}
