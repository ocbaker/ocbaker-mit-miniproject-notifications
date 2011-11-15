using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Server.Interop
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple = false)]
    public class RequestHandlerMethod : Attribute
    {

        public readonly Type handledRequest;

        public RequestHandlerMethod(Type handledRequest)
        {
            this.handledRequest = handledRequest;
        }
    }
}
