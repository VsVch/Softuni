using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ranges = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int start = ranges[0];
            int end = ranges[1];
            string criteria = Console.ReadLine();

            Func<int, int, List<int>> generateRangeOfNums =
            (s, e) =>
            {
                List<int> numbers = new List<int>();

                for (int i = s; i <= e; i++)
                {
                    numbers.Add(i);
                }
                return numbers;
            };

            List<int> numbers = generateRangeOfNums(start, end);

            Predicate<int> predicate = n => true;

            if (criteria == "odd")
            {
                predicate = n => n % 2 != 0;
            }
            else if (criteria == "even")
            {
                predicate = n => n % 2 == 0;
            }

           // numbers.Where(n => n % 2 == 0);

            List<int> filtrednumbers =MyWhere(numbers, predicate);

            Console.WriteLine(string.Join(" ", filtrednumbers));
        }

        static List<int> MyWhere(List<int> numbers, Predicate<int> predicate)         
        {
            List<int> newNumbers = new List<int>();

            foreach (var item in numbers)
            {
                if (predicate(item))
                {
                    newNumbers.Add(item);
                }
            }

            return newNumbers;
        }
    }
}
