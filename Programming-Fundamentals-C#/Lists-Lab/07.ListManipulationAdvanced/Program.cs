using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();

            string[] command = Console.ReadLine()
                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            while (command[0].ToLower() != "end")
            {

                switch (command[0].ToLower())
                {
                    
                    case "contains":
                        Console.WriteLine(numbers.Contains(int.Parse(command[1])) ? "Yes" : "No such number");           
                        break;                        
                    case "printeven":
                        Console.WriteLine(string.Join(' ', numbers
                               .Where(n => n % 2 == 0)));
                        break;
                    case "printodd":
                        Console.WriteLine(string.Join(' ',numbers
                            .Where(n => n % 2 != 0)));
                        break;
                    case "getsum":
                        Console.WriteLine(numbers.Sum());
                        break;
                    case "filter":

                        string result = string.Empty;

                        switch (command[1])
                        {
                            case "<":
                                result = string.Join(" ", numbers
                                               .Where(n => n < int.Parse(command[2])));
                                break;
                            case ">":
                                result = string.Join(" ", numbers
                                               .Where(n => n > int.Parse(command[2])));
                                break;
                            case ">=":
                                result = string.Join(" ", numbers
                                               .Where(n => n >= int.Parse(command[2])));
                                break;
                            case "<=":
                                result = string.Join(" ", numbers
                                    .Where(n => n <= int.Parse(command[2])));
                                break;
                            default:
                                break;                                
                        }
                        Console.WriteLine(result);
                        break;                                                               
                }
                command = Console.ReadLine()
                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }        

        }
    }
}
