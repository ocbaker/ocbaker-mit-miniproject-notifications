using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Notifications.Global.Base.Plugin.Server;
using Interop = Notifications.Server.Interop;
using System.Linq.Expressions;

namespace Notifications.Server.Core.Manager
{
    public class PluginManager
    {
        public static void start()
        {

            //var plugins = System.IO.Directory.EnumerateFiles(Environment.CurrentDirectory + @"\Plugins\", "*.dll", System.IO.SearchOption.TopDirectoryOnly);
            //foreach (string item in plugins)
            //{
            //    Console.WriteLine("Plugin Setup: {0}",item.Substring(item.LastIndexOf("\\") + 1));
            //    try
            //    {
            //        var instances = from t in Assembly.LoadFile(item).GetTypes()
            //                        where t.GetInterfaces().Contains(typeof(IRequestHandler))
            //                                 && t.GetConstructor(Type.EmptyTypes) != null
            //                        select Activator.CreateInstance(t) as IRequestHandler;
            //        foreach (var instance in instances)
            //        {
            //            try
            //            {
            //                if (!instance.GetType().FullName.StartsWith("Notificationsa"))
            //                {
            //                    Console.WriteLine("   - Plugin Namespace: " + instance.GetType().FullName);
            //                    instance.setupHandlers();
            //                    Console.WriteLine("    - SUCCEEDED");
            //                }
            //                else
            //                {

            //                    Console.WriteLine("    - FAILED");
            //                    Console.WriteLine("    - Reason: Not allowed to use the base namespace Notifications.");
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                Console.WriteLine("    - FAILED");
            //                Console.WriteLine("    - Reason: Plugin Threw an unhandled exception.");
            //            }
            //        }   
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine("   - Failed Loading Assembly");
            //    }

                
            //}
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);

            if (!System.IO.Directory.Exists(Environment.CurrentDirectory + @"\Plugins\"))
                System.IO.Directory.CreateDirectory(Environment.CurrentDirectory + @"\Plugins\");
            var plugins = System.IO.Directory.EnumerateFiles(Environment.CurrentDirectory + @"\Plugins\", "*.dll", System.IO.SearchOption.TopDirectoryOnly);
            foreach (string item in plugins)
            {
                Console.WriteLine("Plugin Setup: {0}", item.Substring(item.LastIndexOf("\\") + 1));
                try
                {
                    var instances = from t in Assembly.LoadFile(item).GetTypes()
                                    where t.GetInterfaces().Contains(typeof(IRequestHandler))
                                             && t.GetConstructor(Type.EmptyTypes) != null
                                    select Activator.CreateInstance(t) as IRequestHandler;
                    //AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(item));
                    foreach (var instance in instances)
                    {
                        try
                        {
                            if (!instance.GetType().FullName.StartsWith("Notificationsa"))
                            {
                                Console.WriteLine("   - Plugin Namespace: " + instance.GetType().FullName);
                                instance.setupHandlers();
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

            //Attach ALL EventHandlers
            Console.WriteLine("Attaching Static Events");
            foreach (Assembly assem in AppDomain.CurrentDomain.GetAssemblies())
            {
                //Console.WriteLine("Finding Static Events in:" +);
                foreach (var t in assem.GetTypes())
                {
                    foreach (MethodInfo method in t.GetMethods())
                    {

                        if (Attribute.IsDefined(method, typeof(Interop.StaticEventMethod)))
                        {
                            Console.WriteLine("Adding Static Event: " + method.ReflectedType.FullName + "." + method.Name);
                            Interop.StaticEventMethod EventMethodAttrib = (Interop.StaticEventMethod)Attribute.GetCustomAttribute(method, typeof(Interop.StaticEventMethod));
                            List<Type> args = new List<Type>(
                                method.GetParameters().Select(p => p.ParameterType));
                            Type delegateType;
                            //if (method.ReturnType == typeof(void)) //{
                            delegateType = Expression.GetActionType(args.ToArray());
                            //} else {
                            //args.Add(method.ReturnType);
                            //delegateType = Expression.GetFuncType(args.ToArray());
                            //}
                            //Delegate d = ;
                            Interop.EventManager.handleEvent(EventMethodAttrib.EventName, Delegate.CreateDelegate(delegateType, null, method));

                        }

                    }
                }
            }
        }

        private static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            //This handler is called only when the common language runtime tries to bind to the assembly and fails.
            //Load the assembly from the specified path. 
            try
            {
                return Assembly.LoadFrom(Environment.CurrentDirectory + "\\Plugins\\" + args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll");
            }
            catch (Exception ex)
            {
                return Assembly.LoadFrom("");
            }
        }
    }
}
