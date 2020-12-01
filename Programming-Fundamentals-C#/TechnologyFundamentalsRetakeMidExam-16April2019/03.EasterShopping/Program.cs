using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.EasterShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shops = Console.ReadLine()
                                        .Split(" ")
                                        .ToList();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                                          .Split(" ")
                                          .ToArray();

                string cmdArg = command[0];

                switch (cmdArg)
                {
                    case "Include":

                        string shop = command[1];
                        shops.Add(shop);

                        break;
                    case "Visit":

                        string input = command[1];
                        int index = int.Parse(command[2]);

                        if (index < 0 || index >= shops.Count)
                        {
                            continue;
                        }
                        if (input == "first")
                        {
                            shops.RemoveRange(0, index);
                        }
                        else if (input == "last")
                        {
                            shops.RemoveRange(shops.Count - index, index);
                        }
                        break;
                    case "Prefer":

                        int indexOne = int.Parse(command[1]);
                        int indexTwo = int.Parse(command[2]);

                        if (indexOne < 0 || indexOne >= shops.Count
                         || indexTwo < 0 || indexTwo >= shops.Count)
                        {
                            continue;
                        }
                        else
                        {
                            string firstIndex = shops[indexOne];
                            shops[indexOne] = shops[indexTwo];
                            shops[indexTwo] = firstIndex;
                        }

                        break;
                    case "Place":
                        shop = command[1];
                        index = int.Parse(command[2]);
                        if (index < 0 || index + 1 >= shops.Count)
                        {
                            continue;
                        }
                        else
                        {
                            shops.Insert(index + 1,shop);
                        }
                        break;
                }                      
            }
            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ",shops));
        }
    }
}
