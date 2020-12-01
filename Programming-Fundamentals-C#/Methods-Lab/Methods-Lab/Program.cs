using System;

namespace Methods_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();

            int numberOfProducts = int.Parse(Console.ReadLine());

            ProductsPrice(product, numberOfProducts);
        }
        private static void ProductsPrice(string products, int productNums) 
        {
            double totallPrice = 0;

            switch (products) // coffee, coke, water, snacks;
            {
                case "coffee":
                    totallPrice = productNums * 1.0 * 1.5;                    
                    break;
                case "coke":
                    totallPrice = productNums * 1.0* 1.4;
                    break;
                case "water":
                    totallPrice = productNums * 1.0 * 1.0;
                    break;
                case "snacks":
                    totallPrice = productNums * 1.0 * 2.0;
                    break;

            }
            Console.WriteLine($"{totallPrice:f2}");

        }
    }
}
