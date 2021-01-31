using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics_BetterSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> operationWhitNums = x => x;

            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            string command;

            Action<List<int>> printNumbers = num => Console.WriteLine(string.Join(" ", num));

            while ((command = Console.ReadLine()) != "end")
            {

                if (command == "add")
                {
                    operationWhitNums = num => num + 1;
                    numbers = numbers.Select(operationWhitNums).ToList();
                }
                else if (command == "multiply")
                {
                    operationWhitNums = num => num * 2;
                    numbers = numbers.Select(operationWhitNums).ToList();
                }
                else if (command == "subtract")
                {
                    operationWhitNums = num => num - 1;
                    numbers = numbers.Select(operationWhitNums).ToList();
                }
                else if (command == "print")
                {
                    printNumbers(numbers);
                }
            }
        }
    }
}
