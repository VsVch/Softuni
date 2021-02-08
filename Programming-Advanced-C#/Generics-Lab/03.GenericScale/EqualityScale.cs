using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
   public class EqualityScale<T1, T2>
    where T1 : IComparable where T2 : IComparable
    {      
        
        public bool AreEqual(T1 left, T2 right)         
        {

            int result = left.CompareTo(right);

            if (result == 0)
            {
                return true;
            }            
            else
            {
                return false;
            }           
        
        
        }
    }
}
