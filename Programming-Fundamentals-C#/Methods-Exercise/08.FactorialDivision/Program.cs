using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            int factorielNumOne = FactorielFirstNumber(firstNum);
            int factorielNumSecond = FactorielSecondNumber(secondNum);

            int factorielNum = factorielNumOne / factorielNumSecond;

            Console.WriteLine($"{factorielNum:f2}");
        }

        private static int FactorielSecondNumber(int secondNum)
        {            
            int multippleDigits = 1;

            for (int i = 1; i <= secondNum; i++)
            {
                multippleDigits *= i;
            }
            return multippleDigits;
        }
        private static int FactorielFirstNumber(int firstNum)
        {
            int multippleDigits = 1;

            for (int i = 1; i <= firstNum; i++)
            {
                multippleDigits *= i;
            }
            return multippleDigits ;
        }       
    }
}
