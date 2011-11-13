using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Notifications.Global.Base.Plugin.Server;

namespace Notifications.Server.Core.Manager
{
    public class PluginManager
    {
        public static void start()
        {
            var instances = from t in Assembly.LoadFile(Environment.CurrentDirectory + @"\PluginTest.dll").GetTypes()
                            where t.GetInterfaces().Contains(typeof(IRequestHandler))
                                     && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t) as IRequestHandler;

            foreach (var instance in instances)
            {
                try
                {
                    instance.setupHandlers(); // where Foo is a method of ISomething
                    string nm = instance.GetType().FullName;
                    Console.WriteLine("Setup Plugin: " + nm);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Setup Plugin FALIED: Test Plugin");
                }
            }
            Nito.Async.ActionDispatcher.Current.QueueAction(new Action(action));
        }

        private static void action()
        {
            Console.WriteLine("Action Done");
        }
    }
}
