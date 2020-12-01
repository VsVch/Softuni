using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            Dictionary<string, int> resurceQuantity = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "stop")
            {
                string command = input;

                int quantity = int.Parse(Console.ReadLine());

                if (!resurceQuantity.ContainsKey(command))
                {
                    resurceQuantity.Add(command, quantity);
                }
                else
                {
                    resurceQuantity[command] += quantity;
                }
            }
            foreach (var item in resurceQuantity)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
