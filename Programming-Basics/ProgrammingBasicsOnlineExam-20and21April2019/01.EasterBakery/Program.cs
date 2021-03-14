using System;

namespace _01.EasterBakery
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceOfFlourPerKilogram = double.Parse(Console.ReadLine());
            double kilogramFlour = double.Parse(Console.ReadLine());
            double kilogramSugar = double.Parse(Console.ReadLine());
            double numberOfPackegesEgs = double.Parse(Console.ReadLine());
            double packagesOfYeast = double.Parse(Console.ReadLine());
            double priceOfSugar = priceOfFlourPerKilogram * 0.75;
            double priceOfPackegesEgs = priceOfFlourPerKilogram * 1.1;
            double priceOfPackegesYeast = priceOfSugar * 0.2;
            double flourPrice = kilogramFlour * priceOfFlourPerKilogram;
            double sugarPrice = kilogramSugar * priceOfSugar;
            double egesPrice = numberOfPackegesEgs * priceOfPackegesEgs;
            double yeastPrice = priceOfPackegesYeast * packagesOfYeast;
            double totalPrice = flourPrice + sugarPrice + egesPrice + yeastPrice;
            Console.WriteLine($"{totalPrice:f2}");

        }
    }
}
