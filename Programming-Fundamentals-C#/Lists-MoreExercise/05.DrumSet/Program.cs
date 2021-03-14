using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double saveMoney = double.Parse(Console.ReadLine());

            List<int> powerInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> drumQuality = powerInput                
                .ToList();

            double money = saveMoney;

            string input;

            while ((input = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(input);

                for (int i = 0; i < drumQuality.Count; i++)
                {
                    int currentQuality = drumQuality[i] - hitPower;
                    drumQuality[i] = currentQuality;

                    if (drumQuality[i] <= 0)
                    {
                        drumQuality[i] = 0;
                        money -= powerInput[i] * 3;

                        if (money < 0)
                        {
                            money += powerInput[i] * 3;
                            drumQuality[i] = 0;
                            powerInput[i] = 0;
                        }
                        else
                        {
                            drumQuality[i] = powerInput[i];
                        }                    
                    }
                }                            
            }
            List<int> drumsLeft = new List<int>();

            for (int i = 0; i < drumQuality.Count; i++)
            {
                if ( drumQuality[i] > 0)
                {
                    drumsLeft.Add(drumQuality[i]);
                }
            }         
                        
            Console.WriteLine(string.Join(" ", drumsLeft));
            Console.WriteLine($"Gabsy has {money:f2}lv.");
        }
    }
}
