using System;

namespace _01.EasterLunch
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEasterCakes = int.Parse(Console.ReadLine());
            int numberOfPackegesEgs = int.Parse(Console.ReadLine());
            int kilogramsOfCookis = int.Parse(Console.ReadLine());
            double priceOfEasterCakes = numberOfEasterCakes * 3.2;
            double priceEgs = numberOfPackegesEgs * 4.35 ;
            double priceForPaintEgs = 0.15 * 12 * numberOfPackegesEgs;
            double priceCookis = kilogramsOfCookis * 5.40;
            double totalPrice = priceCookis + priceEgs + priceOfEasterCakes + priceForPaintEgs;
            Console.WriteLine($"{totalPrice:f2}");

        }
    }
}
