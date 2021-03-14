using System;

namespace _07.HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            const double studioPriceMayOctober = 50;
            const double apartmentPriceMayOctober = 65;
            const double studioPriceJuneSeptember = 75.20;
            const double apartmentPriceJuneSeptember = 68.70;
            const double studioPriceJulyAugust = 76;
            const double apartmentPriceJulyAugust = 77;                        
            // May, June, July, August, September или October
            string season = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double totalMoneyStudio = 0;
            double totalMoneyApartment = 0;
            switch (season)
            {
                case "May":
                    totalMoneyStudio = nights * studioPriceMayOctober;
                    totalMoneyApartment = nights * apartmentPriceMayOctober;
                    if (nights > 7 && nights < 14)
                    {
                        totalMoneyStudio -= totalMoneyStudio * 0.05;
                    }
                    else if (nights > 14)
                    {
                        totalMoneyStudio -= totalMoneyStudio * 0.3;
                    }
                    break;
                case "October":
                    totalMoneyStudio = nights * studioPriceMayOctober;
                    totalMoneyApartment = nights * apartmentPriceMayOctober;
                    if (nights > 7 && nights < 14)
                    {
                        totalMoneyStudio -= totalMoneyStudio * 0.05;
                    }
                    else if (nights > 14)
                    {
                        totalMoneyStudio -= totalMoneyStudio * 0.3;
                    }
                    break;
                case "June":
                    totalMoneyStudio = nights * studioPriceJuneSeptember;
                    totalMoneyApartment = nights * apartmentPriceJuneSeptember;
                    if (nights > 14)
                    {
                        totalMoneyStudio -= totalMoneyStudio * 0.2;
                    }
                    break;
                case "September":
                    totalMoneyStudio = nights * studioPriceJuneSeptember;
                    totalMoneyApartment = nights * apartmentPriceJuneSeptember;
                    if (nights > 14)
                    {
                        totalMoneyStudio -= totalMoneyStudio * 0.2;
                    }
                    break;
                case "July":
                    totalMoneyStudio = nights * studioPriceJulyAugust;
                    totalMoneyApartment = nights * apartmentPriceJulyAugust;
                    break;
                case "August":
                    totalMoneyStudio = nights * studioPriceJulyAugust;
                    totalMoneyApartment = nights * apartmentPriceJulyAugust;
                    break;
                
            }
            if (nights > 14)
            {
                totalMoneyApartment -= totalMoneyApartment * 0.1;
            }
            Console.WriteLine($" Apartment: {totalMoneyApartment:f2} lv.");
            Console.WriteLine($" Studio: {totalMoneyStudio:f2} lv.");
        }
    }
}
