using System;
using System.Collections.Generic;

namespace Enumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] array = Console.ReadLine().Split(' ');

            //ringEnumerator enumerator = new StringEnumerator(array);
            
            List<int> numbers = new List<int>();
           
            var enumerator = numbers.GetEnumerator();
           
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator);
            }


        }
    }
}
