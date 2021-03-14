using System;

namespace _08.NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                if (maxNumber < inputNumber)
                {
                    maxNumber = inputNumber;
                }
                if (minNumber > inputNumber)
                {
                    minNumber = inputNumber;
                }
            }
            Console.WriteLine($"Max number: {maxNumber:f0}");
            Console.WriteLine($"Min number: {minNumber:f0}");
        }
    }
}
