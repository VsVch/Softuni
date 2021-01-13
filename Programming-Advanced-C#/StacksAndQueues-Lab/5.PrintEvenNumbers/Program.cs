using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine()  
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();          // 1 2 3 4 5 6

            Queue<int> evenIntegers = new Queue<int>();

            List<int> evenNumbers = new List<int>();

            for (int i = 0; i < integers.Length; i++)
            {
                evenIntegers.Enqueue(integers[i]);
            }

            while (evenIntegers.Count > 0)
            {
                int num = evenIntegers.Peek();

                if (num % 2 == 0)
                {
                    evenNumbers.Add(num);
                }

                evenIntegers.Dequeue();
            }
            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
