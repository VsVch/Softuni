using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int sumFirstTwoNubers = SumFirstAndSeondNums(firstNum, secondNum); 
            int substractThirdNumFromSum = SubstractThirdNumFromSum(sumFirstTwoNubers, thirdNum);

            Console.WriteLine(substractThirdNumFromSum);
        }

        private static int SubstractThirdNumFromSum(int sumFirstTwoNubers, int thirdNum)
        {
            int substractNumber = sumFirstTwoNubers - thirdNum;

            return substractNumber;
        }

        private static int SumFirstAndSeondNums(int firstNum, int secondNum)
        {
            int sumOfNumbers = firstNum + secondNum;

            return sumOfNumbers;
        }
    }
}
