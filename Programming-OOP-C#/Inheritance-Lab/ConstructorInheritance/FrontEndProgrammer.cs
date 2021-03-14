using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructorInheritance
{
    public class FrontEndProgrammer : Programmer
    {
        public FrontEndProgrammer(string name, int salary)
            : base (name,salary,new List<string>() { "Javascript", "React"})
        {
            Console.WriteLine("In frontEnd");
        }
    }
}
