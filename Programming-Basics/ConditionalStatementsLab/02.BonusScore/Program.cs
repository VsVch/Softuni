using System;
using System.Reflection.Metadata;

namespace _02.BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double bonoses = 0.0;
            if (num <= 100)
            {
                bonoses = 5;
            }
            else if (num > 1000)
            {
                bonoses = num * 0.10;
            }
            else
            {
                bonoses = num * 0.20;
            }
            
            if (num % 2 == 0)
            {
                bonoses = bonoses + 1;
            }
            else if (num % 10 == 5)
            {
                bonoses += 2;
            }
            Console.WriteLine(bonoses);
            Console.WriteLine(num + bonoses);
        }
    }
}
