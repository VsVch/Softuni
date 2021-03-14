using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> funk;

            Predicate<List<int>> predicate = true;

            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(n => int.Parse(n))
                .Reverse()
                .ToList();

            int n = int.Parse(Console.ReadLine());
        }

        static List<int> IsDivideByTwo ()
    }
}
