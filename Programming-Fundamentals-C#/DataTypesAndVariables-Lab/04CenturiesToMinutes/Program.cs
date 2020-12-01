using Microsoft.VisualBasic.CompilerServices;
using System;

namespace _04CenturiesToMinutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int centeries = int.Parse(Console.ReadLine());
            int years = centeries * 100;
            int days = (int)(centeries * 36524.22);
            long hours = centeries * 876576;
            long minutes = centeries * 52594560;
            Console.WriteLine(years);
            Console.WriteLine(days);
            Console.WriteLine(hours);
            Console.WriteLine(minutes);


        }
    }
}
