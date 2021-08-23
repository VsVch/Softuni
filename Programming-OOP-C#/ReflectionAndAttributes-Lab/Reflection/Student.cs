using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection
{
    public class Student : ICloneable, IComparable
    {
        public object Clone()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
