using System;
using System.Security.Cryptography.X509Certificates;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());
            double thirdNum = double.Parse(Console.ReadLine());
            PrintSmallesNum(firstNum, secondNum, thirdNum);
        }
        public static void PrintSmallesNum(double firstNum, double secondNum, double thirdNum)
        {

            if (firstNum < secondNum && firstNum < thirdNum)
            {
                Console.WriteLine(firstNum);
            }
            else if (secondNum < firstNum && secondNum < thirdNum)
            {
                Console.WriteLine(secondNum);
            }
            else
            {
                Console.WriteLine(thirdNum);
            }
        }
    }
}
