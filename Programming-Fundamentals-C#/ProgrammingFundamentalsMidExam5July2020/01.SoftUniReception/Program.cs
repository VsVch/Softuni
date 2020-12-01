using System;

namespace _01.SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double partPrisWhitoutDiscount = 0;

            string tipeOfCostumer = string.Empty;

            bool isBuyTime = false;

            while (isBuyTime != true)
            {
                if (input == "special" || input == "regular")
                {
                    tipeOfCostumer = input;
                    isBuyTime = true;
                    break;
                }
                double partsPrice = double.Parse(input);

                if (partsPrice < 0)
                {
                    Console.WriteLine($"Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }

                partPrisWhitoutDiscount += partsPrice;

                input = Console.ReadLine();

               
            }

            double charge = partPrisWhitoutDiscount * 20 / 100;

            double totallPrice = partPrisWhitoutDiscount + charge;
	

            if (tipeOfCostumer == "special")
            {
                totallPrice *= 0.9;
            }
            if (totallPrice <= 0)
            {
                Console.WriteLine($"Invalid order!");
                
            }
            else
            {
                Console.WriteLine($"Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {partPrisWhitoutDiscount:f2}$");
                Console.WriteLine($"Taxes: {charge:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totallPrice:f2}$");
            }
        }
    }
}
