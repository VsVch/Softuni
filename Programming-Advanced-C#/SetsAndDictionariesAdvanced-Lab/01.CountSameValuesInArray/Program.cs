using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();

            Dictionary<double, int> digitsCount = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!digitsCount.ContainsKey(input[i]))
                {
                    digitsCount.Add(input[i], 0);
                }
                digitsCount[input[i]] += 1;
            }

            foreach (var digitCount in digitsCount)
            {
                Console.WriteLine($"{digitCount.Key} - {digitCount.Value} times");
            }
        }
    }
}
