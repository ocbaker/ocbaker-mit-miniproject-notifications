using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Notifications.Server.Interop
{
    public class NetworkComms
    {
        public static void addDataHandler(object key, Func<object, object> value)
        {
            
            Assembly cAssembly = Assembly.LoadFile(Environment.CurrentDirectory + @"\Notifications.Server.Server.dll");
            Type aType = cAssembly.GetType();
            //cAssembly = Assembly.GetAssembly();
            Type tNetworkComms = cAssembly.GetType("Notifications.Server.Server.NetworkComms");
            MethodInfo mAddDataHandler = tNetworkComms.GetMethod("addDataHandler");
            mAddDataHandler.Invoke(null, new object[] { key, value });
        }

        public static void sendMessage(object message)
        {
            Assembly cAssembly = Assembly.LoadFile(Environment.CurrentDirectory + @"\Notifications.Server.Server.dll");
            Type tNetworkComms = cAssembly.GetType("Notifications.Server.Server.NetworkComms");
            MethodInfo mAddDataHandler = tNetworkComms.GetMethod("writeMessage");
            mAddDataHandler.Invoke(null, new object[] { message });
        }

        public static void removeDataHandler(object key)
        {
            Assembly cAssembly = Assembly.LoadFile(Environment.CurrentDirectory + @"\Notifications.Server.Server.dll");
            Type tNetworkComms = cAssembly.GetType("Notification.Server.Server.NetworkComms");
            MethodInfo mAddDataHandler = tNetworkComms.GetMethod("removeDataHandler");
            mAddDataHandler.Invoke(null, new object[] { key });
        }
    }
}
