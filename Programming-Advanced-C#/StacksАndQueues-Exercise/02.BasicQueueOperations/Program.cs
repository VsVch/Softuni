using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] command = input.Split(" ");

            int n = int.Parse(command[0]);
            int s = int.Parse(command[1]);
            int x = int.Parse(command[2]);

            int[] inputNumbers = Console.ReadLine()
                                    .Split(" ")
                                    .Select(int.Parse)
                                    .ToArray();

            Queue<int> numbers = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                numbers.Enqueue(inputNumbers[i]);
            }

            if (n > s)
            {
                for (int i = 0; i < s; i++)
                {
                    numbers.Dequeue();
                }

            }
            else
            {
                numbers.Clear();
                Console.WriteLine("0");
                Environment.Exit(0);
            }

            if (numbers.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine($"{numbers.Min()}");
            }
        }
    }
}
