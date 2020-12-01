using System;
using System.Transactions;

namespace _07.FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //	Магнолии – 3.25 лева
            //  Зюмбюли – 4 лева
            //  Рози – 3.50 лева
            //  Кактуси – 8 лева
            double magnolias = double.Parse(Console.ReadLine());
            double hyacinths = double.Parse(Console.ReadLine());
            double roses = double.Parse(Console.ReadLine());
            double cactus = double.Parse(Console.ReadLine());
            double praceForGift = double.Parse(Console.ReadLine());
            double praceForMagnolias = magnolias * 3.25;
            double praceForHyacinths = hyacinths * 4;
            double priceForRoses = roses * 3.5;
            double priceForCactus = cactus * 8;
            double totalPrice = (praceForHyacinths + praceForMagnolias + priceForCactus + priceForRoses) * 0.95;
                      
            if (totalPrice >= praceForGift)
            {
                double leftMoney = totalPrice - praceForGift;
                Console.WriteLine($"She is left with {Math.Floor(leftMoney)} leva.");
            }
            else if (totalPrice < praceForGift)
            {
                double borrowMoney = praceForGift - totalPrice; 
                Console.WriteLine($"She will have to borrow {Math.Ceiling(borrowMoney)} leva.");
            }
            
        }
    }
}
