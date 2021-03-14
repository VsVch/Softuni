using System;

namespace _04.EvenPowersof2
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            for (double i = 0; i <= n; i += 2)
            {
                double result = Math.Pow(2, i);
                Console.WriteLine(Math.Pow(2, i));
            }
        }
    }
}
