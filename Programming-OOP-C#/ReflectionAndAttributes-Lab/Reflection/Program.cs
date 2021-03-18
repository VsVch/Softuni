using System;
using System.Reflection;
using System.Text;

namespace Reflection
{
    public class Program
    {
        static void Main(string[] args)
        {
            Type studentType = typeof(Student);

            var interfaces = studentType.GetInterfaces();

            foreach (var item in interfaces)
            {
                Console.WriteLine(item.Name);
            }

            MethodInfo[] methods = studentType.GetMethods();

            foreach (var item in methods)
            {
                Console.WriteLine(item.Name);
            }

            //Console.WriteLine("Which class do you want to ispect");
            //string className = Console.ReadLine();            
            //Type stringBuilder = Type.GetType(className);
            //Console.WriteLine(stringBuilder.AssemblyQualifiedName);
            //Console.WriteLine(stringBuilder.FullName);
            //Console.WriteLine(stringBuilder.Name);
            //Console.WriteLine(stringBuilder.BaseType);



        }
    }
}
