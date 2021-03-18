using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReflectingMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(MathSoftuni);

            MethodInfo[] methods = type.GetMethods
                (BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.Static);
            MathSoftuni mathSoftuni = new MathSoftuni();
            foreach (var item in methods)
            {
                var methodParams = item.GetParameters()
                    .Select(p => new KeyValuePair<string, string> 
                    (p.Name, p.ParameterType.Name));

                Console.WriteLine($"{item.Name} -> {string.Join(",", methodParams)}");

               int result = (int)item.Invoke(mathSoftuni, new object[] {5,6 });

               Console.WriteLine(result);
            }
        }    
    }
}
