using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.HelloFrance
{
    class Program
    {
        static void Main(string[] args)
        {
          
            List<string> itemPrice = Console.ReadLine().Replace("->", "|").Split('|').ToList();                            
             
            double buget = double.Parse(Console.ReadLine());

            bool isOutOfbuget = false;

            double sumBayedItem = 0;
                                  
            List<double> priceOfBayedItems = new List<double>();

            while (isOutOfbuget != true)
            {                
                string item = itemPrice[0];
                double price = double.Parse(itemPrice[1]);
                itemPrice.RemoveRange(0, 2);               

                if (item == "Clothes" && price > 50.00 ||
                    item == "Shoes" && price > 35.00 ||
                    item == "Accessories" && price > 20.50)
                {                   
                    continue;
                }
                else
                {
                    if (price > buget)
                    {
                        if (itemPrice.Count == 0)
                        {
                            isOutOfbuget = true;
                            continue;
                        }
                       
                        continue;                    
                    }

                    buget -= price;
                    sumBayedItem += price;
                                       
                    priceOfBayedItems.Add(Math.Round(price * 1.4, 2));
                }              
            }

            double totalSum = buget + priceOfBayedItems.Sum();

            Console.WriteLine(string.Join(" ", priceOfBayedItems));
            Console.WriteLine($"Profit: {(priceOfBayedItems.Sum() - sumBayedItem):f2}");

            if (totalSum >= 150)
            {
                Console.WriteLine($"Hello, France!");
            }
            else
            {
                Console.WriteLine($"Time to go.");
            }
        }
    }
}
