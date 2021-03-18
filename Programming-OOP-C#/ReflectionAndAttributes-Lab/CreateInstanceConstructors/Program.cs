using System;
using System.Reflection;

namespace CreateInstanceConstructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();

            Type studentType = typeof(Student);
            FieldInfo[] fields = studentType.GetFields
                (BindingFlags.Instance | BindingFlags.NonPublic
                | BindingFlags.Static | BindingFlags.Public);

            foreach (var item in fields)
            {
                Console.WriteLine($"{item.Name}");
                Console.WriteLine($"{item.FieldType}");
                Console.WriteLine($"{item.IsPublic}");

                var grade = item.GetValue(student);
                Console.WriteLine($"{item.Name } : {grade}");

                Console.WriteLine();
                Console.WriteLine();
            }
            
            //Student student
            //    = (Student)Activator.CreateInstance
            //     (studentType, new object[] {"Pesho studencheto"});

            //Console.WriteLine($"Name: {student.Name}");
        }
    }
}
