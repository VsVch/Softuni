using System;

namespace _01.PCStore
{
    class Program
    {
        static void Main(string[] args)
        {
            const double oneDolars = 1.57;
            double priceInDolarsProcesor = double.Parse(Console.ReadLine());
            double priceInDolarsVideoCart = double.Parse(Console.ReadLine());
            double priceInDolarsRamPlate = double.Parse(Console.ReadLine());
            double numRamPlate = double.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());
            double priseOfProcesorInLevs = priceInDolarsProcesor * oneDolars;
            double priceVideoCartInLevs = priceInDolarsVideoCart * oneDolars;
            double priceRamPlateInLevs = priceInDolarsRamPlate * oneDolars;
            double totalPriceOfPlates = priceRamPlateInLevs * numRamPlate;
            double priceOfProcesorWhitDiscount = priseOfProcesorInLevs - (priseOfProcesorInLevs * discount) ;
            double priceOfVideoCardWhitDiscount = priceVideoCartInLevs - (priceVideoCartInLevs * discount) ;
            double totalPrice = totalPriceOfPlates + priceOfProcesorWhitDiscount + priceOfVideoCardWhitDiscount;

            Console.WriteLine($"Money needed - {totalPrice:f2} leva.");

        }
    }
}
