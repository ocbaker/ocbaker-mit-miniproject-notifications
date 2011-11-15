using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Plugins.Administration.Global.ComObjects.Data
{
    [Serializable]
    public class data_UserInfo
    {

        public readonly string username = null;
        public readonly string FirstName = null;
        public readonly string LastName = null;
        public readonly int UserLevel = -1;
        public readonly string password = null;

        public data_UserInfo(string username, string FirstName, string LastName, int UserLevel, string password)
        {
            this.username = username;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserLevel = UserLevel;
            this.password = password;
        }
    }
}
