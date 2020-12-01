using System;

namespace _01.PoolDay
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberofPeoples = int.Parse(Console.ReadLine());
            double charge = double.Parse(Console.ReadLine());            
            double priceForOneSunBed = double.Parse(Console.ReadLine());
            double priceForOneUnbrela = double.Parse(Console.ReadLine());
            double enterChargeForAllPeoples = charge * numberofPeoples;
            double numbersOfSunbad = Math.Ceiling(numberofPeoples * 0.75 );
            double priceForSunBad = numbersOfSunbad * priceForOneSunBed;
            double numbersOfUnbrela = Math.Ceiling(numberofPeoples * 0.5);
            double priceForUnbrela = numbersOfUnbrela * priceForOneUnbrela;
            double totalPrice = enterChargeForAllPeoples + priceForSunBad + priceForUnbrela;
            Console.WriteLine($"{totalPrice:f2} lv.");

        }
    }
}
