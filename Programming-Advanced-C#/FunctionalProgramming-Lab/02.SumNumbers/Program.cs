using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

           //Func<string, int> parser = x=> int.Parse(x);

            PintSumAndCount(int.Parse, a => a.Length,
                
                Array => Array.Sum());



        }
        static void PintSumAndCount(Func<string, int> parser,
        Func<int[], int> countGetter,
        Func<int[], int> sumCalculator)
        {
            int[] array = Console.ReadLine()
                    .Split(", ")
                    .Select(parser)
                    .ToArray();

            Console.WriteLine(countGetter(array));
            Console.WriteLine(sumCalculator(array));
        }
    }         
}
