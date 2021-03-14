using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());


            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int wreathsCount = 0;
            int flowersCount = 0;

            while (roses.Count != 0 && lilies.Count != 0)
            {
                int rose = roses.Dequeue();
                int lilie = lilies.Pop();

                int flowers = rose + lilie;

                if (flowers == 15)
                {
                    wreathsCount++;
                }

                if (flowers > 15)
                {
                    if (flowers % 2 == 0)
                    {
                        flowersCount += 14;
                    }
                    else
                    {
                        wreathsCount++;
                    }
                }
                else if (flowers < 15)
                {
                    flowersCount += flowers;
                }         
            }
            wreathsCount += flowersCount / 15;

            if (wreathsCount < 5)
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathsCount} wreaths more!");
            }
            else
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCount} wreaths!");
            }
        }
    }
}
