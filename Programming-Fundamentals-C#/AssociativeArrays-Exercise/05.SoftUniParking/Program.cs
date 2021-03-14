using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> registers = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ")
                    .ToArray();

                string cmdArg = command[0];

                string userName = command[1];

                if (cmdArg == "register")
                {
                    string carNumber = command[2];

                    if (!registers.ContainsKey(userName))
                    {
                        registers.Add(userName, carNumber);
                        Console.WriteLine($"{userName} registered {carNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {carNumber}");
                    }
                }
                else if (cmdArg == "unregister")
                {
                    if (!registers.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");

                    }
                    else
                    {
                        Console.WriteLine($"{userName} unregistered successfully");
                        registers.Remove(userName);
                    }
                }
            }
            foreach (var item in registers)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }

        }
    }
}
