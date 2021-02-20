using System;
using System.Collections;
using System.Collections.Generic;

namespace YieldReturn
{
    class Program
    {
        public static void Main(string[] args)
        {
            //foreach (var name in GetNames())
            //{
            //    Console.WriteLine(name);
            //    Console.WriteLine("In the foreach");
            //}
            IEnumerator enumerator = GetNames().GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
        public static IEnumerable<string> GetNames() 
        {
            yield return "Goshka";
            yield return "Gogi";
            Console.WriteLine("Sled Gogi sum");
            yield return "Dimitrichko";
        }
    }
}
