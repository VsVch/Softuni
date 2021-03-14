using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopsFood 
                = new Dictionary<string, Dictionary<string, double>>();

            string input;

            while ((input = Console.ReadLine()) != "Revision") //{shop}, {product}, {price}
            {
                string[] command = input.Split(", ");

                string shop = command[0];
                string product = command[1];
                double price = double.Parse(command[2]);

                if (!shopsFood.ContainsKey(shop))
                {
                    shopsFood.Add(shop, new Dictionary<string, double>());
                }
                if (!shopsFood[shop].ContainsKey(product))
                {
                    shopsFood[shop].Add(product, 0.0);
                }
                shopsFood[shop][product] = price;
            }

            foreach (var shop in shopsFood.OrderBy(k => k.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
