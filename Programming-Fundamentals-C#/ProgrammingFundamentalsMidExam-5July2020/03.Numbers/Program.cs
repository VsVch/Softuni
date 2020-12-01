using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split(" ")
                                       .Select(int.Parse)
                                       .ToList();

            if (numbers.Count <= 1)
            {
                Console.WriteLine("No");
                Environment.Exit(0);
            }

            int sum = 0;

            int count = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
                count++;
            }

            double averegeSum = 1.0 * sum / count;
            List<int> maxNums = numbers.Where(n => n > averegeSum).OrderByDescending(n => n).ToList();

            int maxNumbersCount = 0;

            List<int> maxNumberByOrder = new List<int>();

            for (int i = 0; i < maxNums.Count; i++)
            {
                maxNumbersCount++;

                if (maxNumbersCount <= 5)
                {
                    maxNumberByOrder.Add(maxNums[i]);
                }

            }            
            Console.WriteLine(string.Join(" ", maxNumberByOrder));
            
        }
    }
}
