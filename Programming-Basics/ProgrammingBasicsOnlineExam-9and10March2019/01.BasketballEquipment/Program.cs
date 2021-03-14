using System;

namespace _01.BasketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int chargeForOneYear = int.Parse(Console.ReadLine());
            double shoesPrice = chargeForOneYear - (chargeForOneYear * 0.4);
            double clotesPrice = shoesPrice * 0.8;
            double ballPrice = clotesPrice / 4;
            double accessoriesPrice = ballPrice / 5;
            double totalPrice = shoesPrice + clotesPrice + ballPrice + accessoriesPrice + chargeForOneYear;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
