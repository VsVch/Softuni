using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    abstract class Person : IPerson
    {

        protected Person(string name, int age )
        {
            this.Name = name;
            this.Age = age;            
        }

        public string Name { get; private set; }

        public int Age { get; private set; }
              
        public int Food { get; protected set; }


        public abstract void BuyFood();
        
    }
}
