using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Client.Interop
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class EventMethod : System.Attribute
    {

        public EventMethod(string EventName)
        {
            this.EventName = EventName;
        }
        public readonly string EventName;
    }
}
