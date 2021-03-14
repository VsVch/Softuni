using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Telephony
{
    public class Smartphone : Phone, IBrowsable
    {
         public string Brows(string url)
        {
            if (url.Any(x=>char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {url}!";
        }

        public override string Call(string number)
        {
            Validator.ThrowIfNumberIsInvalide(number);

            return $"Calling... {number}";
        }      
        
    }
}
