using System;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>([A-Za-z]+)<<([0-9]+\.?\d+)!(\d+)";

            string input;

            Regex regex = new Regex(pattern);

            Console.WriteLine("Bought furniture: ");

            double totallPrice = 0;

            while ((input = Console.ReadLine()) != "Purchase")
            {
               Match match = regex.Match(input);

                if (match.Success) // >>{furniture name}<<{price}!{quantity}
                {
                    string name = match.Groups[1].Value;

                    double price = double.Parse(match.Groups[2].Value);

                    int quantity = int.Parse(match.Groups[3].Value);

                    totallPrice += price * quantity;

                    Console.WriteLine(name);
                }
                
            }

            Console.WriteLine($"Total money spend: {totallPrice:f2}");
        }
    }
}
