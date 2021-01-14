using System;
using System.Collections.Generic;
using System.Linq;

namespace RevercePolishNotation
{
    class Program
    {
        static void Main(string[] args)
        {
            //3 3 - 5 -

            string[] input = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Reverse()
                                    .ToArray();

            Stack<string> calculator = new Stack<string>(input); 

            while (calculator.Count > 1)
            {
                int firstNumber = int.Parse(calculator.Pop());
                int secondNumber = int.Parse(calculator.Pop());
                string sign = calculator.Pop();

                int sum = 0;

                switch (sign)
                {
                    case "+":
                        sum = firstNumber + secondNumber;
                        break;
                    case "-":
                        sum = firstNumber - secondNumber;
                        break;
                    case "*":
                        if (firstNumber == 0 || secondNumber == 0)
                        {
                            sum = 0;
                        }
                        else
                        {
                            sum = firstNumber * secondNumber;
                        }
                        break;
                    case "/":
                        if (firstNumber == 0 || secondNumber == 0)
                        {
                            sum = 0;
                        }
                        else
                        {
                            sum = firstNumber / secondNumber;
                        }
                        
                        break;
                    default:
                        break;
                }
                calculator.Push(sum.ToString());
            }

            Console.WriteLine(calculator.Pop());
        }
    }
}
