using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Server.Interop
{
    public static class EventManager
    {

        private static Dictionary<string, Delegate> EventList = new Dictionary<string, Delegate>();

        public static void addEvent(string key)
        {
            key = key.ToLower();
            if (!EventList.ContainsKey(key))
                EventList.Add(key, null);
        }



        public static void handleEvent(string key, Delegate value)
        {
            key = key.ToLower();
            try
            {
                //EventList[key] += value;
                if (!EventList.ContainsKey(key))
                    addEvent(key);
                if (EventList[key] == null)
                {
                    EventList[key] = value;
                }
                else
                {
                    EventList[key] = Delegate.Combine(EventList[key], value);
                }
                //MulticastDelegate.
                //EventList[key].
            }
            catch (Exception ex)
            {

            }
        }
        public static void handleEvent(string key, Action value) { handleEvent(key, Delegate.Combine(value.GetInvocationList())); }
        public static void handleEvent(string key, Action<object> value) { handleEvent(key, Delegate.Combine(value.GetInvocationList())); }
        public static void handleEvent(string key, Action<object, object> value) { handleEvent(key, Delegate.Combine(value.GetInvocationList())); }
        public static void handleEvent(string key, Action<object, object, object> value) { handleEvent(key, Delegate.Combine(value.GetInvocationList())); }
        public static void handleEvent(string key, Action<object, object, object, object> value) { handleEvent(key, Delegate.Combine(value.GetInvocationList())); }
        public static void handleEvent(string key, Action<object, object, object, object, object> value) { handleEvent(key, Delegate.Combine(value.GetInvocationList())); }
        public static void handleEvent(string key, Action<object, object, object, object, object, object> value) { handleEvent(key, Delegate.Combine(value.GetInvocationList())); }
        public static void handleEvent(string key, Action<object, object, object, object, object, object, object> value) { handleEvent(key, Delegate.Combine(value.GetInvocationList())); }
        public static void handleEvent(string key, Action<object, object, object, object, object, object, object, object> value) { handleEvent(key, Delegate.Combine(value.GetInvocationList())); }
        public static void handleEvent(string key, Action<object, object, object, object, object, object, object, object, object> value) { handleEvent(key, Delegate.Combine(value.GetInvocationList())); }
        public static void handleEvent(string key, Action<object, object, object, object, object, object, object, object, object, object> value) { handleEvent(key, Delegate.Combine(value.GetInvocationList())); }
        public static void handleEvent(string key, Action<object, object, object, object, object, object, object, object, object, object, object> value) { handleEvent(key, Delegate.Combine(value.GetInvocationList())); }
        public static void handleEvent(string key, Action<object, object, object, object, object, object, object, object, object, object, object, object> value) { handleEvent(key, Delegate.Combine(value.GetInvocationList())); }
        public static void handleEvent(string key, Action<object, object, object, object, object, object, object, object, object, object, object, object, object> value) { handleEvent(key, Delegate.Combine(value.GetInvocationList())); }
        public static void handleEvent(string key, Action<object, object, object, object, object, object, object, object, object, object, object, object, object, object> value) { handleEvent(key, Delegate.Combine(value.GetInvocationList())); }
        public static void handleEvent(string key, Action<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> value) { handleEvent(key, Delegate.Combine(value.GetInvocationList())); }
        public static void handleEvent(string key, Action<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> value) { handleEvent(key, Delegate.Combine(value.GetInvocationList())); }

        public static void removeHandle(string key, Delegate value)
        {
            key = key.ToLower();
            try
            {
                //EventList[key] -= value;
                EventList[key] = Delegate.Remove(EventList[key], value);
            }
            catch (Exception ex)
            {

            }
        }
        public static void removeHandle(string key, Action value) { removeHandle(key, Delegate.Combine(value.GetInvocationList())); }
        public static void removeHandle(string key, Action<object> value) { removeHandle(key, Delegate.Combine(value.GetInvocationList())); }
        public static void removeHandle(string key, Action<object, object> value) { removeHandle(key, Delegate.Combine(value.GetInvocationList())); }
        public static void removeHandle(string key, Action<object, object, object> value) { removeHandle(key, Delegate.Combine(value.GetInvocationList())); }
        public static void removeHandle(string key, Action<object, object, object, object> value) { removeHandle(key, Delegate.Combine(value.GetInvocationList())); }
        public static void removeHandle(string key, Action<object, object, object, object, object> value) { removeHandle(key, Delegate.Combine(value.GetInvocationList())); }
        public static void removeHandle(string key, Action<object, object, object, object, object, object> value) { removeHandle(key, Delegate.Combine(value.GetInvocationList())); }
        public static void removeHandle(string key, Action<object, object, object, object, object, object, object> value) { removeHandle(key, Delegate.Combine(value.GetInvocationList())); }
        public static void removeHandle(string key, Action<object, object, object, object, object, object, object, object> value) { removeHandle(key, Delegate.Combine(value.GetInvocationList())); }
        public static void removeHandle(string key, Action<object, object, object, object, object, object, object, object, object> value) { removeHandle(key, Delegate.Combine(value.GetInvocationList())); }
        public static void removeHandle(string key, Action<object, object, object, object, object, object, object, object, object, object> value) { removeHandle(key, Delegate.Combine(value.GetInvocationList())); }
        public static void removeHandle(string key, Action<object, object, object, object, object, object, object, object, object, object, object> value) { removeHandle(key, Delegate.Combine(value.GetInvocationList())); }
        public static void removeHandle(string key, Action<object, object, object, object, object, object, object, object, object, object, object, object> value) { removeHandle(key, Delegate.Combine(value.GetInvocationList())); }
        public static void removeHandle(string key, Action<object, object, object, object, object, object, object, object, object, object, object, object, object> value) { removeHandle(key, Delegate.Combine(value.GetInvocationList())); }
        public static void removeHandle(string key, Action<object, object, object, object, object, object, object, object, object, object, object, object, object, object> value) { removeHandle(key, Delegate.Combine(value.GetInvocationList())); }
        public static void removeHandle(string key, Action<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> value) { removeHandle(key, Delegate.Combine(value.GetInvocationList())); }
        public static void removeHandle(string key, Action<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> value) { removeHandle(key, Delegate.Combine(value.GetInvocationList())); }

        public static void raiseEvents(string key, params object[] fields)
        {
            key = key.ToLower();
            if (EventList[key] != null)
                EventList[key].DynamicInvoke(fields);
        }
    }
}
