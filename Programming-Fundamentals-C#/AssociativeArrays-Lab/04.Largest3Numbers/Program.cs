using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine()
                 .Split(" ")
                 .Select(int.Parse)
                 .ToList();

            int[] sorted = numbers.OrderByDescending(n => n).ToArray();

            for (int i = 0; i < sorted.Length; i++)
            {
                if (i == sorted.Length || i == 3)
                {
                    break;
                }
                Console.Write(sorted[i] + " ");
            }
            
        }
         
    }
}
