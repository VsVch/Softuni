using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public abstract class Phone : ICallable
    {
        public abstract string Call(string number);
        
        
    }
}
