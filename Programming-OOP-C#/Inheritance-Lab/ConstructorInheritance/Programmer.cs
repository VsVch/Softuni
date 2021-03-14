using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructorInheritance
{
    public class Programmer : Employee
    {
        public Programmer(string name, int salary, List<string> languages)
            : base (name, salary)
        {
            Languages = new List<string>();
            Console.WriteLine("In Programmer");
        }
        public List<string> Languages { get; set; }
    }
}
