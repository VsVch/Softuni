using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] command = input
                                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                  .ToArray();

                string cmdArg = command[0];

                int index = int.Parse(command[1]);

                int indexValue = int.Parse(command[2]);

                if (index < 0 || index >= targets.Count)
                {
                    if (cmdArg == "Add")
                    {
                        Console.WriteLine($"Invalid placement!");
                    }
                    input = Console.ReadLine();                    
                    continue;
                }

                switch (cmdArg)
                {
                    case "Shoot":

                        targets[index] -= indexValue;

                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                        break;
                    case "Add":

                        targets.Insert(index, indexValue);

                        break;
                    case "Strike":

                        if ((index - indexValue) > 0 || (index + indexValue) < targets.Count - 1)
                        {
                            targets.RemoveRange(index - indexValue, index + indexValue);
                        }
                        else
                        {

                            Console.WriteLine($"Strike missed!");
                        }                     
                                               
                        break;
                   
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join("|", targets));
        }
    }
}
