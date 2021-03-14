using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(" ")
                .ToList();

            List<string> newNames = names
                .Select(x => $"Sir {x}")
                .ToList();

            Action<List<string>> printNames =
                name => Console.WriteLine(string.Join(Environment.NewLine, newNames));

            printNames(newNames);
        }
    }
}
