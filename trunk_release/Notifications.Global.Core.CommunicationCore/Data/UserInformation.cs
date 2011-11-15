using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Global.Core.Communication.Core.Data
{
    [Serializable]
    public class UserInformation
    {

        public readonly string username;
        public readonly string FirstName;
        public readonly string LastName;
        public readonly int UserLevel;

        public UserInformation(string username, string FirstName, string LastName, int UserLevel)
        {
            this.username = username;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserLevel = UserLevel;
        }

    }
}
