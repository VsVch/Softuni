using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> chemicalElements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");

                for (int j = 0; j <= input.Length - 1; j++)
                {
                    string element = input[j];

                    chemicalElements.Add(element);
                }
            }
            foreach (var element in chemicalElements)
            {
                Console.Write(element + " ");
            }
        }
    }
}
