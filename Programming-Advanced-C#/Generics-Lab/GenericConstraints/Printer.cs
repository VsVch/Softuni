using System;
using System.Collections.Generic;
using System.Text;

namespace GenericConstraints
{
    public class Printer<T> 
    {
        public static void Print<T>(T page)
            where T : IDisposable
        {
            page.Dispose();        
        }
    }
}
