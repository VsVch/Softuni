using System;

namespace _02.HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int maxNumber =  int.MinValue;
            
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;
                int sumLowNumbers = number - maxNumber;
                if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }   
            int sumWhitoutMax = sum - maxNumber;
            
            if (sumWhitoutMax == maxNumber)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {maxNumber}");
            }
            else
            {
                int diference = sumWhitoutMax - maxNumber;
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(diference)}");
            }
        }
    }
}
