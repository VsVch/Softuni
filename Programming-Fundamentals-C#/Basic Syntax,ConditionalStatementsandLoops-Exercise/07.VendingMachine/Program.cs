using System;
using System.IO;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string moneyReceive = Console.ReadLine();
            double insertedAmount = 0;

            while (moneyReceive != "Start")
            {
                double currentCoin = double.Parse(moneyReceive);
                bool isValidMoney = currentCoin == 0.1 ||
                                    currentCoin == 0.2 ||
                                    currentCoin == 0.5 ||
                                    currentCoin == 1.0 ||
                                    currentCoin == 2.0;
                if (isValidMoney)
                {
                    insertedAmount += currentCoin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {currentCoin}");
                }
                moneyReceive = Console.ReadLine();
                
            }
            string product = Console.ReadLine();
            double productPrice = 0;
            while (product != "End")
            {
                switch (product) // “”, “Water”, “Crisps”, “Soda”, “Coke” 2.0, 0.7, 1.5, 0.8, 1.0 
                {
                    case "Nuts":
                        productPrice = 2.0;
                        break;
                    case "Water":
                        productPrice = 0.7;
                        break;
                    case "Crisps":
                        productPrice = 1.5;
                        break;
                    case "Soda":
                        productPrice = 0.8;
                        break;
                    case "Coke":
                        productPrice = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        product = Console.ReadLine();
                        continue;
                }
                
                if (productPrice <= insertedAmount)
                {
                    insertedAmount -= productPrice;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else
                {
                    Console.WriteLine($"Sorry, not enough money");
                }
                product = Console.ReadLine();
            }
            Console.WriteLine($"Change: {insertedAmount:f2}");
        }
    }
}
