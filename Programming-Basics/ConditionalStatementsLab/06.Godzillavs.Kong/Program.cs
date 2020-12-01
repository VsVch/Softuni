using System;

namespace _06.Godzillavs.Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double founds = double.Parse(Console.ReadLine());
            int numberOfStatist = int.Parse(Console.ReadLine());
            double priseForClote = double.Parse(Console.ReadLine());
            
            double decor = founds * 0.100;

            if (numberOfStatist >= 150)
            {
                priseForClote *= 0.90;
            }

            double finalePraceForClotes = priseForClote * numberOfStatist;
            double finaleExpances = decor + finalePraceForClotes;

            if (finaleExpances <= founds)
            {
                double moneyLeft = founds - finaleExpances;
                Console.WriteLine($"Action!");
                Console.WriteLine($"Wingard starts filming with {moneyLeft:f2} leva left.");
            }
            else
            {
                double neededMoney = finaleExpances - founds;
                Console.WriteLine($"Not enough money!");
                Console.WriteLine($"Wingard needs {neededMoney:f2} leva more.");
            }

        }
    }
}