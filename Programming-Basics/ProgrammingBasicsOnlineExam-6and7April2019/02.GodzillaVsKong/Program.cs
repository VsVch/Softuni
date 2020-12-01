using System;

namespace _02.GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double buget = double.Parse(Console.ReadLine());
            int numberOfStatists = int.Parse(Console.ReadLine());
            double priceForDresForStatist = double.Parse(Console.ReadLine());
            double priceOfDecor = buget * 0.1;
            double priseForDreses = priceForDresForStatist * numberOfStatists;
            if (numberOfStatists > 150)
            {
                priseForDreses *= 0.90;
            }
            double totalPrice = priseForDreses + priceOfDecor;
            double monye = Math.Abs(totalPrice - buget);
            if (buget >= totalPrice)
            {
                Console.WriteLine($"Action!");
                Console.WriteLine($"Wingard starts filming with {monye:f2} leva left.");
            }
            else if (buget < totalPrice)
            {
                Console.WriteLine($"Not enough money!");
                Console.WriteLine($"Wingard needs {monye:f2} leva more.");
            }
        }
    }
}
