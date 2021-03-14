using System;

namespace _01.OscarsCeremony
{
    class Program
    {
        static void Main(string[] args)
        {
            double rentForHall = double.Parse(Console.ReadLine());
            double statuetsPrice = rentForHall * 0.7;
            double cateringPrice = statuetsPrice * 0.85;
            double soundPrice = cateringPrice / 2;
            double totalPrice = rentForHall + statuetsPrice + cateringPrice + soundPrice;
            Console.WriteLine($"{totalPrice:f2}");


        }
    }
}
