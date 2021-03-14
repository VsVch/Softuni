using System;

namespace _03.TravelAgency
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfCity = Console.ReadLine();
            string tipeOfPackege = Console.ReadLine();
            string vipDiscount = Console.ReadLine();
            int numberOfDays = int.Parse(Console.ReadLine());
            double price = 0;
            if (numberOfDays <= 0)
            {
                Console.WriteLine($"Days must be positive number!");
                Environment.Exit(0);
            }
            switch (nameOfCity) //  "noEquipment",  "withEquipment", "noBreakfast" или "withBreakfast"
            {
                case "Bansko":               
                case "Borovets":
                    if (tipeOfPackege == "noEquipment")
                    {
                        price = 80;
                    }
                    else if (tipeOfPackege == "withEquipment")
                    {
                        price = 100;
                    }
                    break;
                case "Varna":                    
                case "Burgas":
                    if (tipeOfPackege == "noBreakfast")
                    {
                        price = 100;
                    }
                    else if (tipeOfPackege == "withBreakfast")
                    {
                        price = 130;
                    }                    
                    break;
                default:
                    Console.WriteLine($"Invalid input!");
                    Environment.Exit(0);
                    break;

            }
            double priceForAllDays = price * numberOfDays;
            if (numberOfDays > 7)
            {
                priceForAllDays = price * (numberOfDays - 1);
            }
            if (vipDiscount == "yes"&& tipeOfPackege == "noEquipment")
            {
                priceForAllDays *= 0.95;
            }
            else if (vipDiscount == "yes" && tipeOfPackege == "withEquipment")
            {
                priceForAllDays *= 0.9;
            }
            else if (vipDiscount == "yes" && tipeOfPackege == "noBreakfast")
            {
                priceForAllDays *= 0.93;
            }
            else if (vipDiscount == "yes" && tipeOfPackege == "withBreakfast")
            {
                priceForAllDays *= 0.88;
            }            
            Console.WriteLine($"The price is {priceForAllDays:f2}lv! Have a nice time!");                       
        }
    }
}
