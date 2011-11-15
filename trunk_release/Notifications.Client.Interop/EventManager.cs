using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Client.Interop
{
    public static class EventManager
    {

        private static Dictionary<string, List<Delegate>> EventList = new Dictionary<string, List<Delegate>>();
        private static Queue<QueuedEvent> ActionsQueuedPrePluginsLoaded = new Queue<QueuedEvent>();
        private static bool queueEvents = true;

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
                    EventList[key] = new List<Delegate>();
                    
                }
                if(!EventList[key].Contains(value))
                    EventList[key].Add(value);
                    
                //EventList[key] = Delegate.Combine(EventList[key], value);
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
                EventList[key].Remove(value);
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

        private static void raiseEvents(QueuedEvent qEvent)
        {
            try
            {
                if (EventList[qEvent.key] != null)
                {
                    Console.WriteLine("Raised Event: " + qEvent.key);
                    try
                    {
                        foreach (Delegate outDelegate in EventList[qEvent.key])
                            outDelegate.DynamicInvoke(qEvent.parameters);
                    }
                    catch (Exception ex)
                    {
                        string a = "lol";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed To Raise Event (Event does not have a handler): " + qEvent.key);
            }
        }
        
        public static void raiseEvents(string key, params object[] fields)
        {
            if (queueEvents && key != "Client.Executable.LoadedPlugins")
            {
                Console.WriteLine("Queued Event: " + key);
                ActionsQueuedPrePluginsLoaded.Enqueue(new QueuedEvent(key.ToLower(), fields));
            }
            else
            {
                
                key = key.ToLower();
                try
                {
                    if (EventList[key] != null)
                    {
                        Console.WriteLine("Raised Event: " + key);
                        try
                        {
                            foreach (Delegate outDelegate in EventList[key])
                                outDelegate.DynamicInvoke(fields);
                        }
                        catch (Exception ex)
                        {
                            string a = "lol";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed To Raise Event (Event does not have a handler): " + key);
                }
            }
        }

        [StaticEventMethod("Client.Executable.LoadedPlugins")]
        public static void PluginsAreLoaded()
        {
            while (ActionsQueuedPrePluginsLoaded.Count > 0)
            {
                raiseEvents(ActionsQueuedPrePluginsLoaded.Dequeue());
            }
            queueEvents = false;
        }

        private class QueuedEvent
        {
            public readonly string key;
            public readonly object[] parameters;

            public QueuedEvent(string key, object[] parameters)
            {
                this.key = key;
                this.parameters = parameters;
            }
        }
    }
}
