using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine()
                                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            string input;

            Stack<int> numbers = new Stack<int>();

            foreach (var item in integers)
            {
                numbers.Push(item);
            }

            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] command = input
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdArg = command[0];

                if (cmdArg == "add")
                {
                    int firstNumber = int.Parse(command[1]);
                    int secondNumber = int.Parse(command[2]);

                    numbers.Push(firstNumber);
                    numbers.Push(secondNumber);
                }
                else if (cmdArg == "remove")
                {
                    int index = int.Parse(command[1]);

                    if (index > numbers.Count)
                    {
                        continue;
                    }
                    else
                    {
                        for (int i = 1; i <= index; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }
            }
            Console.WriteLine("Sum: " + numbers.Sum());
        }
    }
}
