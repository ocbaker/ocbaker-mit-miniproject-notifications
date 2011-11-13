using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Notifications.Client.Interop
{
    internal static class ClientObject
    {
        private static bool setup = false;
        
        private static void setupClass()
        {
            
        }


        public static void addTab(Object key, Object value)
        {
            Assembly cAssembly = Assembly.GetEntryAssembly();
            Type tNetworkComms = cAssembly.GetType("Notifications.Client.Executable.MainWindow");
            MethodInfo mAddDataHandler = tNetworkComms.GetMethod("addTab");
            mAddDataHandler.Invoke(null, new object[] { key, value });
        }

        //internal static object FInvoke()

    }
}
