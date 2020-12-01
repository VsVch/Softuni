using System;
using System.ComponentModel.DataAnnotations;

namespace _01.SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int maxNumber = 0;
            int middleNumber = 0;
            int minNumber = 0;
            
            if (firstNum > secondNum && firstNum > thirdNum)
            {
                maxNumber = firstNum;
            }
            if (secondNum > firstNum && secondNum > thirdNum)
            {
                maxNumber = secondNum;
            }
            if (thirdNum > firstNum && thirdNum > secondNum)
            {
                maxNumber = thirdNum;
            }
            if (firstNum < secondNum && firstNum < thirdNum)
            {
                minNumber = firstNum;
            }
            if (secondNum < firstNum && secondNum < thirdNum)
            {
                minNumber = secondNum;
            }
            if (thirdNum < firstNum && thirdNum < secondNum)
            {
                minNumber = thirdNum;
            }
            if (firstNum > secondNum && firstNum < thirdNum || firstNum < secondNum && firstNum >thirdNum)
            {
                middleNumber = firstNum;
            }
            if (secondNum > firstNum && secondNum < thirdNum || secondNum < firstNum && secondNum > thirdNum)
            {
                middleNumber = secondNum;
            }
            if (thirdNum > firstNum && thirdNum < secondNum || thirdNum < firstNum && thirdNum > secondNum)
            {
                middleNumber = thirdNum;
            }
            Console.WriteLine(maxNumber);
            Console.WriteLine(middleNumber);
            Console.WriteLine(minNumber);

        }
    }
}
