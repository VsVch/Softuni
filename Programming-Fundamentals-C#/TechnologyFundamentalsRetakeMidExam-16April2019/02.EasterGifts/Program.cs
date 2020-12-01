using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.EasterGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> gifts = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();
            string input;

            while ((input = Console.ReadLine()) != "No Money")
            {
                string[] command = input
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();
                string cmdArg = command[0];
                string gift = command[1];

                switch (cmdArg)
                {
                    case "OutOfStock":

                        for (int i = 0; i < gifts.Count; i++)
                        {
                            if (gift == gifts[i])
                            {
                                gifts[i] = "None";
                                
                            }
                        }

                        break;
                    case "Required":

                        int index = int.Parse(command[2]);

                        if (index < 0 || index >= gifts.Count)
                        {
                            continue;
                        }
                        for (int i = 0; i < gifts.Count; i++)
                        {
                            if (index == i)
                            {
                                gifts[i] = gift;
                            }
                        }

                        break;
                    case "JustInCase":

                        gifts[gifts.Count - 1] = gift;

                        break;
                }
            }
            gifts.RemoveAll(n => n == "None");

            Console.WriteLine(string.Join(" ", gifts));
        }
    }
}
