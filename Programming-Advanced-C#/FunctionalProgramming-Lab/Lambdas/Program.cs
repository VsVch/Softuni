using System;
using System.Collections.Generic;
using System.Linq;

namespace Lambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] evenNum = array
               // .Where(n => n % 2 == 0)
               //.Where(IsIven)
                .Where(n => 
                {
                    Console.WriteLine($"Checking {n} % 2 == 0 -> {n % 2 == 0}");

                    return n % 2 == 0;
                })            
                .ToArray();

            //no Linq

            List<int> evenNumCustom = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 ==0)
                {
                    evenNumCustom.Add(array[i]);
                }
            }

            Console.WriteLine(string.Join(" ", evenNum));
            Console.WriteLine(string.Join(" ", evenNumCustom));

        }
        static bool IsIven(int n)         
        {
            return n % 2 == 0;
        }
    }
}
