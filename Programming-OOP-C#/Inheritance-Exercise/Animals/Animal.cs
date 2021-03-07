using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private int age;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get; set; }

        public int Age 
        {
            get 
            {
               return this.age;
            } 
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;

            } 
        }

        public string Gender { get; set; }
        public virtual string ProduceSound() 
        {
            return "Animal sound!";        
        }
        public override string ToString()
        {
            return $"{Name} {Age} {Gender}";
        }
    }
}
