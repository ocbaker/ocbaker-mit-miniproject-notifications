using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Global.Core.Communication.Base.BaseObjects
{
    [Serializable]
    public abstract class aBaseResponse
    {

        private Guid _messageID;

        public aBaseResponse(aBaseRequest request)
        {
            _messageID = request.messageID;
        }

        public Guid responseID
        {
            get { return _messageID; }
        }
    }
}
