using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\%([A-Z][a-z]+)%[^|$%.]*<(\w+)>[^|$%.]*\|(\d+)\|[^|$%.]*?(\d+\.*\d+)\$";

            Regex regex = new Regex(pattern);

            string input;

            double tottalPrice = 0;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match match = regex.Match(input);

                double priceOfPersone = 0;

                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    int quantity = int.Parse(match.Groups[3].Value);
                    double price = double.Parse(match.Groups[4].Value);

                    priceOfPersone = quantity * price;

                    tottalPrice += priceOfPersone;

                    Console.WriteLine($"{name}: {product} - {priceOfPersone:f2}");

                }
            }
            Console.WriteLine($"Total income: {tottalPrice:f2}");
        }
    }
}
