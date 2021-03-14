using System;


namespace _10.MultiplyEvensБyOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int numberWhitoutIndex = MathAbsolutMethod(number); 
            numberWhitoutIndex = GetMultipleOfEvenAndOdds(numberWhitoutIndex);
            Console.WriteLine(numberWhitoutIndex);

        }

        static int MathAbsolutMethod(int number) 
        {
            int numberWhitoutIndex = Math.Abs(number);
            return numberWhitoutIndex;
        }

        static int GetSumOfEvenDigits(int num)
        {
                       
            int evenNumberSum = 0;

            while (num > 0)
            {
               int numberCycle = num % 10;
                num /= 10;

                if (numberCycle % 2 == 0)
                {
                    evenNumberSum += numberCycle;
                }            
            }          
             return evenNumberSum;
        }
        private static int GetSumOfOddDigits(int num)
        {
            
            int oddNumberSum = 0;            
            
            while (num > 0)
            {
                int numberCycle = num % 10;
                num /= 10;
                                
                if (numberCycle % 2 != 0)
                {
                    oddNumberSum += numberCycle;
                }                
            }
            return oddNumberSum;
        }
        static int GetMultipleOfEvenAndOdds(int numberWhitoutIndex) 
        {
            int totalSum = GetSumOfOddDigits(numberWhitoutIndex) * GetSumOfEvenDigits(numberWhitoutIndex);
            return totalSum;
        }
    }
}
