using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Plugins.Administration.Server.RequestHandlers
{
    public static class UserListing
    {

        private static readonly List<Global.ComObjects.Data.data_UserInfo> users;

        static UserListing()
        {
            users = new List<Global.ComObjects.Data.data_UserInfo>();
            users.Add(new Global.ComObjects.Data.data_UserInfo("bake266","Oliver","Baker",0,"lol"));
            users.Add(new Global.ComObjects.Data.data_UserInfo("burf9", "Shane", "Burfiled-Mills", 1, "lol"));
        }

        [Notifications.Server.Interop.RequestHandlerMethod(typeof(Global.ComObjects.Requests.rq_getUserList))]
        public static object HandleGetUserList(object rawRequest)
        {
            Global.ComObjects.Requests.rq_getUserList request = (Global.ComObjects.Requests.rq_getUserList)rawRequest;
            Global.ComObjects.Data.data_UserInfo[] usersArray = users.ToArray();
            return new Notifications.Plugins.Administration.Global.ComObjects.Responses.rp_getUserList(request, usersArray);
        }
    }
}
