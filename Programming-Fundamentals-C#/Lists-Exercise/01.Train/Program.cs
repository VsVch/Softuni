using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            string[] command = Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0].ToLower() != "end")
            {
                if (command[0].ToLower() == "add")
                {
                    wagons.Add(int.Parse(command[1]));
                }
                else
                {
                    int passengers = int.Parse(command[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {

                        if (wagons[i] + passengers <= maxCapacity)
                        {
                            wagons[i] += passengers;
                            break;
                        }                    
                        
                    }
                }
                command = Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            }
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
