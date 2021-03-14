using System;

namespace _02.FamilyTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            double buget = double.Parse(Console.ReadLine());
            int numberOfnights = int.Parse(Console.ReadLine());
            double priceForOneNights = double.Parse(Console.ReadLine());
            double percentAnotherExpences = double.Parse(Console.ReadLine());
            double priceForAllNights = priceForOneNights * numberOfnights;
            double anotherExpences = buget * percentAnotherExpences / 100;
            if (numberOfnights > 7)
            {
                priceForAllNights *= 0.95;
            }
            double expences = anotherExpences + priceForAllNights;
            double money = Math.Abs(buget - expences);
            if (buget >= expences)
            {
                Console.WriteLine($"Ivanovi will be left with {money:f2} leva after vacation.");
            }
            else if (buget < expences)
            {
                Console.WriteLine($"{money:f2} leva needed.");
            }
        }
    }
}
