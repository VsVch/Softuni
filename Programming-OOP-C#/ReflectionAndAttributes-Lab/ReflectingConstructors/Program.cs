using System;
using System.Reflection;

namespace ReflectingConstructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Student);

            ConstructorInfo concreteConst = type.GetConstructor
                (new Type[] {typeof(string), typeof(int)});
            ConstructorInfo[] constructors =
                type.GetConstructors();

            foreach (var item in constructors)
            {
                ParameterInfo[] paramInfos =
                    item.GetParameters();
            }

        }
    }
}
