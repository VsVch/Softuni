using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> operationWhitNums = x=>x;

            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(Parser)
                .ToList();

            string command ;

            Action<List<int>> printNumbers = num => Console.WriteLine(string.Join(" ", num));

            while ((command = Console.ReadLine()) != "end")          
            {
                
                if (command == "add")
                {
                    numbers = operationWhitNums(AddToNumbers(numbers));
                }
                else if (command == "multiply")
                {
                    numbers = operationWhitNums(MultiplyNumbers(numbers));
                }
                else if (command == "subtract")
                {
                    numbers = operationWhitNums(SubtractToNumbers(numbers));
                }
                else if (command == "print")
                {
                    printNumbers(numbers);                  
                }
            }            
        }
        static List<int> SubtractToNumbers(List<int> numbers)
        {
            List<int> newNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                newNumbers.Add(numbers[i] - 1);
            }

            return newNumbers;

        }
        static List<int> AddToNumbers(List<int> numbers)
        {
            List<int> newNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                newNumbers.Add(numbers[i] + 1);
            }

            return newNumbers;
        
        }
        static List<int> MultiplyNumbers(List<int> numbers)
        {
            List<int> newNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                newNumbers.Add(numbers[i] * 2);
            }

            return newNumbers;

        }
        static int Parser(string n)
        {
            int num = int.Parse(n);

            return num;
        
        }
    }
}
