using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics_DictionarySolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Func<int, int>> arithmethicsFunc = 
                new Dictionary<string, Func<int, int>>() 
                {
                    {"add", x => x + 1 },
                    {"multiply", x=> x * 2 },
                    {"subtract", x=> x - 1 }
                };         
            
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            string command;

            Action<List<int>> printNumbers = num => Console.WriteLine(string.Join(" ", num));

            while ((command = Console.ReadLine()) != "end")
            {

                if (arithmethicsFunc.ContainsKey(command))
                {
                    Func<int, int> funk = arithmethicsFunc[command];

                    numbers = numbers.Select(arithmethicsFunc[command]).ToList();

                }
                else if (command == "print")
                {
                    printNumbers(numbers);
                }
            }
        }
    }
}
