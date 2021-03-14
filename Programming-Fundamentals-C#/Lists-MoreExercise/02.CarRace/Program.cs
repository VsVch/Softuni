using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToArray();
            
            double leftCarTime = 0;
            double rightCarTime = 0;
            bool isRaceOver = false;
            while (isRaceOver != true)
            {
                for (int i = 0; i < numbers.Length /2; i++)
                {
                    leftCarTime += numbers[i];

                    if (numbers[i] == 0)
                    {
                        leftCarTime *= 0.8;
                    }                    
                }

                for (int i = numbers.Length - 1; i > numbers.Length / 2; i--)
                {
                    rightCarTime += numbers[i];

                    if (numbers[i] == 0)
                    {
                        rightCarTime *= 0.8;
                    }                    
                }
                isRaceOver = true;
            }

            
            if (leftCarTime < rightCarTime)
            {
                Console.WriteLine($"The winner is left with total time: {leftCarTime}");
            }
            else if (rightCarTime < leftCarTime)
            {
                Console.WriteLine($"The winner is right with total time: {rightCarTime}");
            }

        }
    }
}
