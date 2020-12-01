using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> neighborhood = Console.ReadLine()
                                            .Split("@", StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToList();

            string input = Console.ReadLine();

            int housesLenght = 0;

            while (input != "Love!")
            {
                string[] comand = input
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                string cmdArg = comand[0];
                int step = int.Parse(comand[1]);
                housesLenght += step;

               

                input = Console.ReadLine();
            }


             int fallIndex = neighborhood.Count(n => n > 0);
                      
                       
            Console.WriteLine($"Cupid's last position was {lastPosition}.");

            if (fallIndex != 0)
            {
                Console.WriteLine($"Cupid has failed {fallIndex} places.");
            }
            else
            {
               
                Console.WriteLine($"Mission was successful.");
            }
            


        }
    }
}
