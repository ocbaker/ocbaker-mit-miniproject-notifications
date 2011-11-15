using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Notifications.Global.Core.Communication.Base.BaseObjects;

namespace Notifications.Plugins.Administration.Global.ComObjects.Responses
{
    [Serializable]
    public class rp_getUserList : aBaseResponse 
    {

        public readonly Data.data_UserInfo[] userList;

        public rp_getUserList(aBaseRequest request, Data.data_UserInfo[] userList) : base(request) 
        {
            this.userList = userList;
        }

    }
}
