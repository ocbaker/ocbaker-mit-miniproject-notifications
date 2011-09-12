using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace TestOnDemandLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
            {
                Assembly MyAssembly = AppDomain.CurrentDomain.Load("SMS_API.dll");
                Console.WriteLine("Embeeded Extensions Assembly");
                return MyAssembly;
            };
            Console.WriteLine(Extensions.GuidGenerator.GenerateTimeBasedGuid(DateTime.Now));
            Console.ReadLine();
        }
    }
}
