using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] command = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(command[0]);
            int s = int.Parse(command[1]);
            int x = int.Parse(command[2]);

            string[] elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                numbers.Push(int.Parse(elements[i]));
            }                    

            if (n <= s)
            {
                numbers.Clear();
                Console.WriteLine("0");
                Environment.Exit(0);
            }
            else
            {
                for (int i = 0; i < s; i++) // ? proverka za povche pop ot po mlko push ?
                {
                    numbers.Pop();
                }
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
