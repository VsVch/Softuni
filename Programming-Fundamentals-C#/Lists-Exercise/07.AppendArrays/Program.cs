using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split("|")
                .ToList();

            items.Reverse();

            List<string> result = new List<string>();

            foreach (string currentItems in items)
            {
                string[] numbers = currentItems
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

                foreach (string numberToAdd in numbers)
                {
                    result.Add(numberToAdd);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
