using System;
using System.Collections.Generic;
using System.Text;

namespace AccessModifiers
{
    public class Base
    {
        private int privateField;
        protected int protectedField;
        internal int internalField;
        public int publicField;

        

        public Base()
        {

        }

        public virtual void BaseMethod() 
        {
            Console.WriteLine("Im the base");
        
        }
    }
}
