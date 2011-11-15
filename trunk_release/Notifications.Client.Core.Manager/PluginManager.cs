using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Notifications.Global.Base.Plugin.Client;
using System.Linq.Expressions;

namespace Notifications.Client.Core.Manager
{
    public class PluginManager
    {
        
        public static void start()
        {
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
                                    where t.GetInterfaces().Contains(typeof(ISetupHandler))
                                             && t.GetConstructor(Type.EmptyTypes) != null
                                    select Activator.CreateInstance(t) as ISetupHandler;
                    //AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(item));
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

            //Attach ALL EventHandlers
            Console.WriteLine("Attaching Static Events");
            var assemblies = from assemb in AppDomain.CurrentDomain.GetAssemblies()
                             where assemb.Location.StartsWith(Environment.CurrentDirectory)
                             select assemb as Assembly;
            foreach (Assembly assem in assemblies)
            {
                //Console.WriteLine("Finding Static Events in:" +);
                foreach (var t in assem.GetTypes())
                {

                    var SEMs = from mth in t.GetMethods()
                               where Attribute.IsDefined(mth, typeof(Interop.StaticEventMethod))
                               select mth;
                    foreach (MethodInfo method in SEMs)
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
                    //var RHMs = from mtha in t.GetMethods()
                    //           where Attribute.IsDefined((MethodInfo)mtha, typeof(Interop.RequestHandlerMethod))
                    //           select mtha as MethodInfo;
                    //foreach (MethodInfo method in RHMs)
                    //{
                    //    Console.WriteLine("Adding Static Object Handler: " + method.ReflectedType.FullName + "." + method.Name);
                    //    Interop.RequestHandlerMethod EventMethodAttrib = (Interop.RequestHandlerMethod)Attribute.GetCustomAttribute(method, typeof(Interop.RequestHandlerMethod));
                    //    List<Type> args = new List<Type>(
                    //        method.GetParameters().Select(p => p.ParameterType));
                    //    Type delegateType;
                    //    //if (method.ReturnType == typeof(void)) //{
                    //    //delegateType = Expression.GetActionType(args.ToArray());
                    //    //} else {
                    //    args.Add(method.ReturnType);
                    //    delegateType = Expression.GetFuncType(args.ToArray());
                    //    //}
                    //    //Server.Interop.NetworkComms.addDataHandler(EventMethodAttrib.handledRequest, new Func<object, object>( Delegate.CreateDelegate(delegateType, method).DynamicInvoke));
                    //    Server.Interop.NetworkComms.addDataHandler(EventMethodAttrib.handledRequest, (Func<object, object>)Delegate.CreateDelegate(typeof(Func<object, object>), method));
                    //    //Interop.EventManager.handleEvent(EventMethodAttrib.EventName, Delegate.CreateDelegate(delegateType, null, method));

                    //}
                }
            }

            Interop.EventManager.raiseEvents("Client.Executable.LoadedPlugins");
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
