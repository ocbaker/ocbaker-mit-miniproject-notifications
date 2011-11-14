using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Notifications.Global.Base.Plugin.Client;

namespace Notifications.Client.Core.Manager
{
    public class PluginManager
    {
        public static void start()
        {
            var plugins = System.IO.Directory.EnumerateFiles(Environment.CurrentDirectory + @"\Plugins\", "*.dll", System.IO.SearchOption.TopDirectoryOnly);
            foreach (string item in plugins)
            {
                Console.WriteLine("Plugin Setup: {0}", item.Substring(item.LastIndexOf("\\") + 1));
                try
                {
                    var instances = from t in Assembly.LoadFile(item).GetTypes()
                                    where t.GetInterfaces().Contains(typeof(ISetupHandler))
                                             && t.GetConstructor(Type.EmptyTypes) != null
                                    select Activator.CreateInstance(t) as ISetupHandler;
                    foreach (var instance in instances)
                    {
                        try
                        {
                            if (!instance.GetType().FullName.StartsWith("Notificationsa"))
                            {
                                Console.WriteLine("   - Plugin Namespace: " + instance.GetType().FullName);
                                instance.setup();
                                Console.WriteLine("    - SUCCEEDED");
                            }
                            else
                            {

                                Console.WriteLine("        - FAILED");
                                Console.WriteLine("        - Reason: Not allowed to use the base namespace Notifications.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("        - FAILED");
                            Console.WriteLine("        - Reason: Plugin Threw an unhandled exception.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("   - Failed Loading Assembly");
                }


            }
        }
    }
}
