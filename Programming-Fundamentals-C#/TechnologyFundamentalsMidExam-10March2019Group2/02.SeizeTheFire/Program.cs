using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SeizeTheFire
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Replace("#","=")
                .Split("=", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int water = int.Parse(Console.ReadLine());

            List<int> result = new List<int>();

            double totalFire = 0;

            while (input.Count != 0)
            {
                List<string> fire = input.ToList();
                string firePower = fire[0];
                int neededWater = int.Parse(fire[1]);

                if (water < neededWater)
                {
                    fire.RemoveRange(0, 2);
                    input.RemoveRange(0, 2);

                    continue;
                }

                if (firePower == "High " && neededWater >= 81 && neededWater <= 125)
                {
                    water -= neededWater;
                    totalFire += neededWater;
                    result.Add(neededWater);
                }
                else if (firePower == "Medium " && neededWater >= 51 && neededWater <= 80)
                {
                    water -= neededWater;
                    totalFire += neededWater;
                    result.Add(neededWater);
                }
                else if (firePower == "Low " && neededWater >= 1 && neededWater <= 50)
                {
                    water -= neededWater;
                    totalFire += neededWater;
                    result.Add(neededWater);
                }
                else
                {
                    fire.RemoveRange(0, 2);
                    input.RemoveRange(0, 2);
                    fire = input.ToList();
                    continue;
                }
                fire.RemoveRange(0, 2);
                input.RemoveRange(0, 2);


                fire = input.ToList();
            }
            Console.WriteLine("Cells:");
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine($" - {result[i]}");
            }

            double effort = totalFire * 0.25;
            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }
    }
}
