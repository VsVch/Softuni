using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            string cupsInput = Console.ReadLine();
            string botlesInput = Console.ReadLine();

            int[] cupsArray = cupsInput
                                  .Split(" ")
                                  .Select(int.Parse)
                                  .ToArray();

            int[] botlesArray = botlesInput
                                  .Split(" ")
                                  .Select(int.Parse)
                                  .ToArray();

            Queue<int> cups = new Queue<int>(cupsArray);
            Stack<int> bottles = new Stack<int>(botlesArray);

            int wastedWater = 0;

            while (cups.Any() && bottles.Count > 0)
            {
                int cup = cups.Dequeue();
                int bottle = bottles.Pop();

                if (bottle > cup)
                {
                    wastedWater += bottle - cup;
                }
                else
                {
                    int cupQantityLeft = cup - bottle;
                    
                    while (cupQantityLeft > 0)
                    {
                        int currentBottle = bottles.Pop();
                        
                        if (cupQantityLeft - currentBottle < 0)
                        {
                            wastedWater += currentBottle - cupQantityLeft;
                            break;
                        }
                        else
                        {
                            cupQantityLeft -= currentBottle;
                        }

                    }
                }

            }
            if (bottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ",bottles)}");
            }
            if (cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");

        }
    }
}
