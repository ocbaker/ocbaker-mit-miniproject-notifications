using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Notifications.Client.Interop
{
    public static class UserInterface
    {
        private static bool setup = false;

        public delegate void del_addTab(Object key, Object value);
        public static del_addTab addTab;
        public delegate void del_addPage(Object key, Object value);
        public static del_addPage addPage;

        private static void setupClass()
        {
            
        }


        //public static void addTab(Object key, Object value)
        //{
        //    Assembly cAssembly = Assembly.GetEntryAssembly();
        //    Type tNetworkComms = cAssembly.GetType("Notifications.Client.Executable.MainWindow");
        //    MethodInfo mAddDataHandler = tNetworkComms.GetMethod("addTab");
        //    mAddDataHandler.Invoke(null, new object[] { key, value });
        //}

        //internal static object FInvoke()

    }
}
