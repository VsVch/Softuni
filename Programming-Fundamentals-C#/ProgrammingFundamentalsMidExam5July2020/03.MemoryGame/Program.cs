using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sequence = Console.ReadLine()
                                           .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                           .ToList();
            string input = Console.ReadLine();

            int count = 0;                     

            while (input != "end")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                int indexOne = int.Parse(command[0]);
                int indexTwo = int.Parse(command[1]);
                count++;
                
                if (indexOne == indexTwo || indexOne < 0 || indexOne >= sequence.Count || indexTwo < 0 || indexTwo >= sequence.Count )
                {
                    Console.WriteLine($"Invalid input! Adding additional elements to the board");
                    sequence.Insert(sequence.Count / 2, $"-{count}a");
                    sequence.Insert(sequence.Count / 2, $"-{count}a");
                    input = Console.ReadLine();
                    continue;
                }
                if (sequence[indexOne] == sequence[indexTwo])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {sequence[indexOne]}!");

                    if (indexOne < indexTwo)
                    {
                        sequence.RemoveAt(indexTwo);
                        sequence.RemoveAt(indexOne);
                    }
                    else
                    {
                        sequence.RemoveAt(indexOne);
                        sequence.RemoveAt(indexTwo);
                    }                                    
                }
                else
                {
                    Console.WriteLine("Try again!");
                }
                if (sequence.Count == 0)
                {
                    Console.WriteLine($"You have won in {count} turns!");
                    Environment.Exit(0);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ",sequence));
        }
    }
}
