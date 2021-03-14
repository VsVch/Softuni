using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (input.Length > 1)
                {
                    string[] command = input.Split(" ");
                    numbers.Push(int.Parse(command[1]));
                }
                else
                {
                    if (numbers.Count > 0)
                    {
                        if (input == "2")
                        {
                            numbers.Pop();
                        }
                        else if (input == "3")
                        {
                            Console.WriteLine($"{numbers.Max()}");
                        }
                        else if (input == "4")
                        {
                            Console.WriteLine($"{numbers.Min()}");
                        }

                    }
                    else
                    {
                        continue;
                    }
                }

            }
            if (numbers.Any())
            {
                Console.WriteLine(string.Join(", ", numbers));

            }
            else
            {

            }

        }
    }
}
