using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> number = Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToList();

            string[] command = Console.ReadLine()
                                      .Split(" ",StringSplitOptions.RemoveEmptyEntries);

            while (command[0].ToLower() != "end")
            {
                switch (command[0].ToLower())
                {
                    case "add":
                        number.Add(int.Parse(command[1]));
                        break;
                    case "remove":
                        number.Remove(int.Parse(command[1]));
                        break;
                    case "removeat":
                        number.RemoveAt(int.Parse(command[1]));
                        break;
                    case "insert":                       
                        number.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;                   
                    default:
                        break;                      
                }
                command = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine(string.Join(" ", number));

        }
    }
}
