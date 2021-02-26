using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private List<Person> family;

        private string name;

        private int age;

        public Person(string name, int age)
        {
            family = new List<Person>();
            this.Name = name;
            this.Age = age;
        }


        public string Name 
        {
            get  
            {
               return this.name;
            }
            set  
            {
                this.name = value;
            } 
        }

        public virtual int Age 
        {
            get 
            {
                return this.age;
            }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be positive value");
                }
                this.age = value;
            } 
        }
        public void MyFamilyAdd(Person person) 
        {
            this.family.Add(person);
        }

        public override string ToString()
        {
            StringBuilder persininfo = new StringBuilder();

            persininfo.Append(String.Format($"Name: {this.Name}, Age: {this.Age}"));

            return persininfo.ToString();
        }
    }
}
