using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree_DictionarySoluton
{
    public static class Validator
    {
        public static void ThtowIfStringIsNullOrEmpty(string value, string exeptionMassege) 
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

        }

        public static void ThrowIfValueIsLessThanNull(decimal value, string exeptionMassege) 
        {

            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            
        }
    }
}
