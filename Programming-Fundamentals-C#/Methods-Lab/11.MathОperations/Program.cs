using System;
using System.IO;

namespace _11.MathОperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());

            string operation = Console.ReadLine(); //   / * + -

            int secondNum = int.Parse(Console.ReadLine());

            double function = PrintOperation(firstNum, operation, secondNum);

            Console.WriteLine(function);
        }

        private static double PrintOperation(int firstNum, string operation, int secondNum)
        {
            double function = 0;
            switch (operation)
            {
                case "+":
                    function = firstNum + secondNum;
                    break;
                case "-":
                    function = firstNum = secondNum;
                    break;
                case "/":
                    function = firstNum / secondNum;
                    break;
                case "*":
                    function = firstNum * secondNum;
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
            return function;
        }
    }
}
