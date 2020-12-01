using System;

namespace _03.Aquapark
{
    class Program
    {
        static void Main(string[] args)
        {
            string mounts = Console.ReadLine();
            int numberHours = int.Parse(Console.ReadLine());
            int numberPeoples = int.Parse(Console.ReadLine());
            string dayNight = Console.ReadLine();
            double pricePersonPerHour = 0;
            double totalPrice = 0;
            double totalPriceFirsDiscount = 0;
            double totalPriceTwoDiscount = 0;
            // ("march", "april", "may", "june", "july", "august ")
            switch (mounts)
            {
                case"march":
                case "april":
                case "may":
                    if (dayNight == "day")
                    {
                        pricePersonPerHour = 10.50;
                        totalPrice = numberHours * 1.0 * numberPeoples * 10.50;
                    }
                    else if(dayNight == "night")
                    {
                        pricePersonPerHour = 8.40;
                        totalPrice = numberHours * 1.0 * numberPeoples * 8.4;
                    }
                    break;
                case "june":
                case "july":
                case "august":
                    if (dayNight == "day")
                    {
                        pricePersonPerHour = 12.60;
                        totalPrice = numberHours * 1.0 * numberPeoples * 12.60;
                    }
                    else if (dayNight == "night")
                    {
                        pricePersonPerHour = 10.20;
                        totalPrice = numberHours * 1.0 * numberPeoples * 10.20;
                    }
                    break;
                    
            }
            if (numberPeoples >= 4)
            {
                totalPriceFirsDiscount = totalPrice * 0.9;
                double pricePersonPerHourFirstDiscount = pricePersonPerHour * 0.9;
                if (numberHours >= 5)
                {
                    totalPriceTwoDiscount = totalPriceFirsDiscount * 0.5;
                    double pricePersonPerHourDiscount = pricePersonPerHourFirstDiscount * 0.5;
                    Console.WriteLine($"Price per person for one hour: {pricePersonPerHourDiscount:f2}");
                    Console.WriteLine($"Total cost of the visit: {totalPriceTwoDiscount:f2}");
                    Environment.Exit(0);

                }
                Console.WriteLine($"Price per person for one hour: {pricePersonPerHour:f2}");
                Console.WriteLine($"Total cost of the visit: {totalPriceFirsDiscount:f2}");
                
            }
            else
            {
                if (numberHours >= 5)
                {
                    totalPriceTwoDiscount = totalPrice * 0.5;
                    double pricePersonPerHourDiscount = pricePersonPerHour * 0.5;
                    Console.WriteLine($"Price per person for one hour: {pricePersonPerHour:f2}");
                    Console.WriteLine($"Total cost of the visit: {totalPriceTwoDiscount:f2}");
                    Environment.Exit(0);

                }
                Console.WriteLine($"Price per person for one hour: {pricePersonPerHour:f2}");
                Console.WriteLine($"Total cost of the visit: {totalPrice:f2}");
            }
        }
    }
}
