using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Notifications.Global.Core.Communication.Base.BaseObjects;

namespace Notifications.Plugins.Administration.Global.ComObjects.Requests
{
    class rq_addUser : aBaseRequest
    {

        public readonly Data.data_UserInfo userInfo;

        public rq_addUser(Data.data_UserInfo userInfo) 
        {
            this.userInfo = userInfo;
        }
    }
}
