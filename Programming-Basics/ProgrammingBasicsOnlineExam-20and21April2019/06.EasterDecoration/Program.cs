using System;
using System.Diagnostics.Tracing;

namespace _06.EasterDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfclients = int.Parse(Console.ReadLine());
            
            double allPrice = 0;
            for (int i = 1; i <= numberOfclients; i++)
            {
                double price = 0;
                int count = 0;
                string products = Console.ReadLine();
                while (products != "Finish") 
                {
                    count++;
                    
                    if (products == "basket")
                    {
                        price += 1.5;
                    }
                    if (products == "wreath")
                    {
                        price += 3.8;
                    }
                    if (products == "chocolate bunny")
                    {
                        price += 7;
                    }
                    
                    
                    products = Console.ReadLine();
                }
                if (count % 2 == 0)
                {
                    price *= 0.8;
                }
                allPrice += price;
                Console.WriteLine($"You purchased {count} items for {price:f2} leva.");
            }
            double totalCount = allPrice / numberOfclients;
            Console.WriteLine($"Average bill per client is: {totalCount:f2} leva.");
        }
    }
}
