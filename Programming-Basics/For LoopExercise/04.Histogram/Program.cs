using System;

namespace _04.Histogram
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
            int p4 = 0;
            int p5 = 0;
                      

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 200)
                {
                     p1++;

                }
                else if (number >= 200 && number < 400)
                {
                    p2++;
                }
                else if (number < 600)
                {
                    p3++;
                }
                else if (number < 800)
                {
                    p4++;
                }
                else if (number >= 800)
                {
                    p5++;
                }

            }
            double pp1 = doubleConverter * p1 * 100 / n;
            double pp2 = doubleConverter * p2 * 100 / n;
            double pp3 = doubleConverter * p3 * 100 / n;
            double pp4 = doubleConverter * p4 * 100 / n;
            double pp5 = doubleConverter * p5 * 100 / n;
            Console.WriteLine($"{pp1:f2}%");
            Console.WriteLine($"{pp2:f2}%");
            Console.WriteLine($"{pp3:f2}%");
            Console.WriteLine($"{pp4:f2}%");
            Console.WriteLine($"{pp5:f2}%");
        }
    }
}
