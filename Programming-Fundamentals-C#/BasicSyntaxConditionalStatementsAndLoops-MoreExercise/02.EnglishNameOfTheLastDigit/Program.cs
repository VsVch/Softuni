using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace _02.EnglishNameOfTheLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string firstNumber = string.Empty;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                int number = int.Parse(input[i].ToString());
                if (number == 0)
                {
                    firstNumber = "null";
                    break;
                }
                else if (number == 1)
                {
                    firstNumber = "one";
                    break;
                }
                else if (number == 2)
                {
                    firstNumber = "two";
                    break;
                }
                else if (number == 3)
                {
                    firstNumber = "three";
                    break;
                }
                else if (number == 4)
                {
                    firstNumber = "four";
                    break;
                }
                else if (number == 5)
                {
                    firstNumber = "five";
                    break;
                }
                else if (number == 6)
                {
                    firstNumber = "six";
                    break;
                }
                else if (number == 7)
                {
                    firstNumber = "seven";
                    break;
                }
                else if (number == 8)
                {
                    firstNumber = "eight";
                    break;
                }
                else if (number == 9)
                {
                    firstNumber = "nine";
                    break;
                }                               

            }
            Console.WriteLine(firstNumber);
        }
    }
}
