using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Client.Interop
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class StaticEventMethod : System.Attribute
    {

        public StaticEventMethod(string EventName)
        {
            this.EventName = EventName;
            //tDelegate = Delegate.CreateDelegate(this.GetType().
        }
        
        public StaticEventMethod(string EventName, Action value)
        {
            this.EventName = EventName;
            tDelegate = Delegate.Combine(value.GetInvocationList());
        }
        public readonly string EventName;
        public readonly Delegate tDelegate;
        //public static void handleEvent(string key, Action value) { handleEvent(key, Delegate.Combine(value.GetInvocationList())); }
        //public StaticEventMethod(string EventName, Action<object> value) { this.EventName = EventName;  tDelegate = Delegate.Combine(value.GetInvocationList()); }
        //public StaticEventMethod(string EventName, Action<object, object> value) { this.EventName = EventName; tDelegate = Delegate.Combine(value.GetInvocationList()); }
        //public StaticEventMethod(string EventName, Action<object, object, object> value) { this.EventName = EventName; tDelegate = Delegate.Combine(value.GetInvocationList()); }
        //public StaticEventMethod(string EventName, Action<object, object, object, object> value) { this.EventName = EventName; tDelegate = Delegate.Combine(value.GetInvocationList()); }
        //public StaticEventMethod(string EventName, Action<object, object, object, object, object> value) { this.EventName = EventName; tDelegate = Delegate.Combine(value.GetInvocationList()); }
        //public StaticEventMethod(string EventName, Action<object, object, object, object, object, object> value) { this.EventName = EventName; tDelegate = Delegate.Combine(value.GetInvocationList()); }
        //public StaticEventMethod(string EventName, Action<object, object, object, object, object, object, object> value) { this.EventName = EventName; tDelegate = Delegate.Combine(value.GetInvocationList()); }
        //public StaticEventMethod(string EventName, Action<object, object, object, object, object, object, object, object> value) { this.EventName = EventName; tDelegate = Delegate.Combine(value.GetInvocationList()); }
        //public StaticEventMethod(string EventName, Action<object, object, object, object, object, object, object, object, object> value) { this.EventName = EventName; tDelegate = Delegate.Combine(value.GetInvocationList()); }
        //public StaticEventMethod(string EventName, Action<object, object, object, object, object, object, object, object, object, object> value) { this.EventName = EventName; tDelegate = Delegate.Combine(value.GetInvocationList()); }
        //public StaticEventMethod(string EventName, Action<object, object, object, object, object, object, object, object, object, object, object> value) { this.EventName = EventName; tDelegate = Delegate.Combine(value.GetInvocationList()); }
        //public StaticEventMethod(string EventName, Action<object, object, object, object, object, object, object, object, object, object, object, object> value) { this.EventName = EventName; tDelegate = Delegate.Combine(value.GetInvocationList()); }
        //public StaticEventMethod(string EventName, Action<object, object, object, object, object, object, object, object, object, object, object, object, object> value) { this.EventName = EventName; tDelegate = Delegate.Combine(value.GetInvocationList()); }
        //public StaticEventMethod(string EventName, Action<object, object, object, object, object, object, object, object, object, object, object, object, object, object> value) { this.EventName = EventName; tDelegate = Delegate.Combine(value.GetInvocationList()); }
        //public StaticEventMethod(string EventName, Action<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> value) { this.EventName = EventName; tDelegate = Delegate.Combine(value.GetInvocationList()); }
        //public StaticEventMethod(string EventName, Action<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> value) { this.EventName = EventName; tDelegate = Delegate.Combine(value.GetInvocationList()); }
    }
}
