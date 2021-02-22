using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            

        }
        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            int result = 1;

            if (other != null)
            {
               result = other.Name.CompareTo(this.Name);

                if (result == 0)
                {
                    result = other.Age.CompareTo(this.Age);
                }
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj != null &&obj is Person other)
            {
                return this.Name == other.Name && this.Age == other.Age;

            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }

    }
}
