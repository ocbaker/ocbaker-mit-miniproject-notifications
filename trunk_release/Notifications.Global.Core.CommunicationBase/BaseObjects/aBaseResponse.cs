using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Global.Core.Communication.Base.BaseObjects
{
    [Serializable]
    public abstract class aBaseResponse : IResponse
    {

        private Guid _messageID;
        public readonly object _userInformation;
        private Object _exception;

        public aBaseResponse(aBaseRequest request)
        {
            _messageID = request.messageID;
            _userInformation = request._userInformation;
        }
        public aBaseResponse(aBaseRequest request, Object exception)
        {
            _messageID = request.messageID;
            
            try
            {
                var testconversion = (Exception)exception;
            }
            catch(Exception ex)
            {
                _exception = new Exception("Server threw a badly format exception creating the response");
            }
        }

        public Guid responseID
        {
            get { return _messageID; }
        }

        public Object exception
        {
            get { return _exception; }
        }
    }
}
