using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();
            int[] bombProp = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            int bomb = bombProp[0];
            int power = bombProp[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentnumber = numbers[i];

                if (currentnumber == bomb)
                {
                    int startIndex = i - power;
                    int endInex = i + power;

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if (endInex > numbers.Count - 1)
                    {
                        endInex = numbers.Count - 1;
                    }

                    int endIndexToRemove = endInex - startIndex + 1;
                    numbers.RemoveRange(startIndex, endIndexToRemove);

                    i = startIndex - 1;
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
