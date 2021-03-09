using System;
using System.Collections.Generic;
using System.Text;

namespace AccessModifiers
{
    public class Child : Base
    {
        public Child()
        {
            this.protectedField = 5;
            
        }

        public double Weight { get; set; }

        public override void BaseMethod() 
        { 
            Console.WriteLine("Im the child");        
        }
    }
}
