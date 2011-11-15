using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Global.Core.Communication.Base.BaseObjects
{
    [Serializable]
    public abstract class aBaseRequest : IRequest
    {

        private Guid _messageID;
        public object _userInformation;

        public aBaseRequest()
        {
            _messageID = Guid.NewGuid();
        }

        public Guid messageID
        {
            get { return _messageID; }
        }
    }
}