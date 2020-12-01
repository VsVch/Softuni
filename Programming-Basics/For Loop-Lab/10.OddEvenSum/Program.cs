using System;

namespace _10.OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int evenSum = 0;
            int oddSum = 0;
            for (int i = 0; i < n; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += inputNumber;
                    
                }
                else
                {
                     oddSum += inputNumber;
                    
                }
                
            }
            
            if (evenSum == oddSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {evenSum}");
            }
            else
            {
                int totallSum = evenSum - oddSum;
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(totallSum)}");
            }
            
        }
    }
}
