using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectingConstructors
{
    public class Student
    {

        private int AveregeGrade = 2;
        private int age = 15;
        internal string fullName = "pesho peshov";
        internal string nickName = "gotiniq";

        public Student()
        {

        }

        public Student(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
