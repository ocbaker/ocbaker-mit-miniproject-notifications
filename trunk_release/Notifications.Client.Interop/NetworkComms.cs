using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Notifications.Client.Interop
{
    public static class NetworkComms
    {
        public delegate void del_addDataHandler(object key,Func<object,object> value);
        public static del_addDataHandler addDataHandler;

        //public static void addDataHandler(object key, Func<object, object> value)
        //{
        //    Assembly cAssembly = Assembly.GetEntryAssembly();
        //    Type tNetworkComms = cAssembly.GetType("Notifications.Client.Executable.NetworkComms");
        //    MethodInfo mAddDataHandler = tNetworkComms.GetMethod("addDataHandler");
        //    mAddDataHandler.Invoke(null, new object[] { key, value });
        //}

        public static void sendMessage(object message)
        {
            Assembly cAssembly = Assembly.GetEntryAssembly();
            Type tNetworkComms = cAssembly.GetType("Notifications.Client.Executable.NetworkComms");
            MethodInfo mAddDataHandler = tNetworkComms.GetMethod("writeMessage");
            mAddDataHandler.Invoke(null, new object[] { message });
        }

        public static void removeDataHandler(object key)
        {
            Assembly cAssembly = Assembly.GetEntryAssembly();
            Type tNetworkComms = cAssembly.GetType("Notifications.Client.Executable.NetworkComms");
            MethodInfo mAddDataHandler = tNetworkComms.GetMethod("removeDataHandler");
            mAddDataHandler.Invoke(null, new object[] { key });
        }
    }
}
