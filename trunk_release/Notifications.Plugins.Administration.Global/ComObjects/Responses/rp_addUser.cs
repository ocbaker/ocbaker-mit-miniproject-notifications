using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Notifications.Global.Core.Communication.Base.BaseObjects;

namespace Notifications.Plugins.Administration.Global.ComObjects.Responses
{
    class rp_addUser : aBaseResponse
    {
        public readonly bool success = false;
        public readonly Data.data_UserInfo userInfo;

        public rp_addUser(aBaseRequest request, bool success, Data.data_UserInfo userInfo) : base(request)
        {
            this.success = success;
            this.userInfo = userInfo;
        }

    }
}
