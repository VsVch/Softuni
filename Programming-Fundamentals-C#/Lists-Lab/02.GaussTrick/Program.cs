using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> number = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxNumber = number.Count / 2;

            for (int i = 0; i < maxNumber; i++)
            {

                number[i] += number[number.Count - 1];
                number.Remove(number[number.Count - 1]);
                
            }
            Console.WriteLine(string.Join(" ", number));
        }
    }
}
