using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                                 .Split(" ")
                                 .Select(int.Parse)
                                 .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            int inUseRackCapacity = rackCapacity;

            Stack<int> clotes = new Stack<int>(input);

            int racksCounter = 1;

            for (int i = 0; i < input.Length; i++)
            {
                int clote = clotes.Peek();
                inUseRackCapacity -= clote;

                if (inUseRackCapacity < 0)
                {                    
                    inUseRackCapacity = rackCapacity;
                    racksCounter++;
                    inUseRackCapacity -= clote;
                }

                clotes.Pop();
            }
            Console.WriteLine(racksCounter);

        }
    }
}
