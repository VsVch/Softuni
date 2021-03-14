using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int pasengers = int.Parse(Console.ReadLine());

            List<int> waggons = Console.ReadLine()
                                     .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToList();
           

            for (int i = 0; i < waggons.Count; i++)
            {
                if (waggons[i] == 4)
                {
                    continue;
                }
               
                for (int j = 0; j < 4; j++)
                {
                    waggons[i] += 1;
                    pasengers -= 1;
                                      
                    if(pasengers == 0)
                    {
                        if (waggons.Count - 1 == i && j == 3)
                        {
                            Console.WriteLine($"{string.Join(" ", waggons)}");
                            Environment.Exit(0);
                        }
                        Console.WriteLine("The lift has empty spots!");
                        Console.WriteLine($"{string.Join(" ", waggons)}");
                        Environment.Exit(0);
                    }
                    if (waggons[i] == 4)
                    {
                        break;
                    }
                }
                if (i == waggons.Count - 1 && pasengers > 0)
                {
                    Console.WriteLine($"There isn't enough space! {pasengers} people in a queue!");
                    Console.WriteLine($"{string.Join(" ", waggons)}");
                    break;
                }
                
            }
        }
    }
}
