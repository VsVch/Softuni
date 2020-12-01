using System;
using System.Linq;

namespace _05.SumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int evenSum = 0; 
            int oddSum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                int curentSum = number[i];
                if (curentSum % 2 == 0)
                {
                    evenSum += curentSum;
                }
                else if (curentSum % 2 != 0)
                {
                    oddSum += curentSum;
                }
            }
            int defference = evenSum - oddSum ;
            Console.WriteLine(defference);
                         
        }
    }
}
