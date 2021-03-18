using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectingMethods
{
    public class MathSoftuni
    {
        public int Add(int a, int b) 
        {
            return a + b;
        }

        public int AddTwo(int a, int c)
        {
            return a + c;
        }

        public static int Multiple(int a, int b)
        {
            return a * b;
        }
        private int Divide(int a, int b)
        {
            return a / b;
        }

        public virtual double Procentige(int a, int b)
        {
            return a / b * 100;
        }
    }
}
