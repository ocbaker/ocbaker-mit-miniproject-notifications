using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Plugins.SMS.Server
{
    public class apiValidateLogin
    {
        private string username;
        private string password;
        private DateTime _lastcheck;

        public apiValidateLogin(string _username, string _password)
        {
            APIusername = _username;
            APIpassword = _password;
        }
        public apiValidateLogin()
        {
        }
        public string APIusername
        {
            get { return username; }
            set { username = value; }
        }
        public string APIpassword
        {
            get { return password; }
            set { password = value; }
        }
        public DateTime LastCheck
        {
            get { return _lastcheck; }
            set { _lastcheck = value; }
        }
    }
}
