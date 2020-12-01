using System;
using System.Xml.Schema;

namespace _05.DivideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            const double doubleConverter = 1.0;
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number % 2 == 0)
                {
                    p1++;
                }
                if (number % 3 == 0)
                {
                    p2++;
                }
                if (number % 4 == 0)
                {
                    p3++;
                }

            }
            double pp1 = p1 * doubleConverter * 100 / n;
            double pp2 = p2 * doubleConverter * 100 / n;
            double pp3 = p3 * doubleConverter * 100 / n;
            Console.WriteLine($"{pp1:f2}%");
            Console.WriteLine($"{pp2:f2}%");
            Console.WriteLine($"{pp3:f2}%");
                
        }
    }
}
