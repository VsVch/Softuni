using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Crafting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> parts = Console.ReadLine().Split("|").ToList();

            List<string> everParts = new List<string>();
            List<string> oddParts = new List<string>();

            string input ;

            while ((input = Console.ReadLine()) != "Done")
            {
                string[] command = input.Split(" ").ToArray();

                string cmdArg = command[0];
                string cmdCommand = command[1]; 
                
                if (cmdArg == "Move" && cmdCommand == "Left") // Move Left {index} <-
                {
                    int index = int.Parse(command[2]);

                    string firstString = string.Empty;

                    if (index < 1 || index > parts.Count)
                    {
                        continue;
                    }
                    else
                    {
                        for (int i = parts.Count - 1; i >= 0; i--)
                        {
                            firstString = parts[index - 1];

                            if (index == i)
                            {
                                
                                parts[i - 1] = parts[i];
                                parts[i] = firstString;
                                break;
                            }
                        }
                    }
                }
                else if (cmdArg == "Move" && cmdCommand == "Right") // Move Right {index} ->
                {
                    int index = int.Parse(command[2]);

                    string lastString = string.Empty;

                    if (index < 0 || index + 1 >= parts.Count)
                    {
                        continue;
                    }
                    else
                    {
                        for (int i = parts.Count - 1; i >= 0; i--)
                        {
                            

                            if (index == i) 
                            {
                                lastString = parts[i + 1];
                                parts[i + 1] = parts[i];
                                parts[i] = lastString;
                                break;

                            }
                        }
                    }
                }
                else if (cmdArg == "Check" && cmdCommand == "Even") // Check Even
                {
                    for (int i = 0; i < parts.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            everParts.Add(parts[i]);
                        }
                    }
                    Console.WriteLine(string.Join(" ", everParts));
                }
                else if (cmdArg == "Check" && cmdCommand == "Odd") // Check Odd
                {
                    for (int i = 1; i < parts.Count; i++)
                    {
                        if (i % 2 != 0)
                        {
                            oddParts.Add(parts[i]);
                        }
                    }
                    Console.WriteLine(string.Join(" ", oddParts));
                }
            }          
            Console.WriteLine($"You crafted { string.Join("", parts)}!");
        }
    }
}
