using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Baby : Child
    {
        public override int Age 
        { 
            get 
            {
               return base.Age;
            }
            set
            {
                if (value > 2)
                {
                    throw new ArgumentException("Baby age must be less than 2 years");
                }

                base.Age = value;
            } 
        }
        public Baby(string name, int age) 
            : base(name, age)
        {
        }
    }
}
