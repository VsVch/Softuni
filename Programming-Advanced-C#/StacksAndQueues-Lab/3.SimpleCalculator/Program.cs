using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Reverse()
                                    .ToArray();

            Stack<string> calcolator = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                calcolator.Push(input[i]);
            }

            while (calcolator.Count > 1)
            {
                int furstNumber = int.Parse(calcolator.Pop());
                string sign = calcolator.Pop();
                int secondNumber = int.Parse(calcolator.Pop());
                int number = 0;

                if (sign == "+")
                {
                    number = furstNumber + secondNumber;
                }
                else if (sign == "-")
                {
                    number = furstNumber - secondNumber;
                }

                calcolator.Push(number.ToString());
            }

            Console.WriteLine(calcolator.Pop());
        }
    }
}
