using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace _01.SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();

            string input = Console.ReadLine();

            while (input != "end") 
            {
                string[] commands = input
                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                       .ToArray();
                string cmdArg = commands[0];


                switch (cmdArg)
                {
                    case "swap":
                        int indexOne = int.Parse(commands[1]);
                        int indexTwo = int.Parse(commands[2]);

                        int firstNumber = numbers[indexOne];
                        int secondNumber = numbers[indexTwo];
                        int saveNumber = firstNumber;
                        numbers[indexOne] = secondNumber;
                        numbers[indexTwo] = saveNumber;
                        break;
                    case "multiply":

                        int secondMultiplayer = numbers[int.Parse(commands[2])];
                       
                        numbers[int.Parse(commands[1])] *= secondMultiplayer;
                        break;
                    case "decrease":

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            numbers[i] -= 1;
                        }
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
