using System;
using System.Collections.Generic;
using System.Text;

namespace Constructors
{
    class Student
    {
        private int averageGrade;
        public Student(string name) 
        {
            this.Name = name;
            averageGrade = 2;
            Console.WriteLine("Constructor called!");
        
        }

        public Student(string name, int age) 
        {
            this.Name = name;
            this.Age = age;
        
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
