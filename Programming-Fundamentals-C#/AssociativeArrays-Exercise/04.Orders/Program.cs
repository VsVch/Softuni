using System;
using System.Collections.Generic;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            Dictionary<string, List<double>> productInfo = new Dictionary<string, List<double>>();

            while ((input = Console.ReadLine()) != "buy")
            {
                string[] products = input.Split(" ");

                string product = products[0];

                double productPrice = double.Parse(products[1]);

                double quantlity = double.Parse(products[2]);

                if (!productInfo.ContainsKey(product))
                {
                    List<double> priceAndQuantity = new List<double> {productPrice, quantlity };

                    productInfo.Add(product, priceAndQuantity);

                    //  productInfo.Add(product, new List<double> {productPrice, quantlity });
                }
                else
                {
                    productInfo[product][0] = productPrice;
                    productInfo[product][1] = productInfo[product][1] + quantlity;
                }

            }
            foreach (var item in productInfo)
            {
                double totalPrice = item.Value[0] * item.Value[1];
                Console.WriteLine($"{item.Key} -> {totalPrice:f2}");
            }
        }
    }
}
