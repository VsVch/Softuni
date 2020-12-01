using System;

namespace _01.SpringVacationТrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int tripDays = int.Parse(Console.ReadLine());
            double buget = double.Parse(Console.ReadLine());
            int numberOfPeoples = int.Parse(Console.ReadLine());
            double priceOfTheFuelPerKm = double.Parse(Console.ReadLine());
            double foodForPersonForDay = double.Parse(Console.ReadLine());
            double priceOfTheRoomPerDayPerPerson = double.Parse(Console.ReadLine());
           

            double foodExpences = numberOfPeoples * tripDays * foodForPersonForDay;

            double hotelsExpences = tripDays * numberOfPeoples * priceOfTheRoomPerDayPerPerson;

            if (numberOfPeoples >  10)
            {
                hotelsExpences *= 0.75;
            }

            double foodHotelsExpences = foodExpences + hotelsExpences;

            buget -= foodHotelsExpences;

            double currentExpences = foodHotelsExpences ;

            bool isOutOfBuget = false;

            for (int i = 1; i <= tripDays; i++)
            {
                int travelledDistanceInDay = int.Parse(Console.ReadLine());

                double fuelExpences = priceOfTheFuelPerKm * travelledDistanceInDay;

                buget -= fuelExpences;

                currentExpences += fuelExpences;
                               

                if (i % 3 == 0 || i % 5 == 0)
                {
                    buget -= (0.4 * currentExpences);
                    currentExpences += 0.4 * currentExpences;

                }
                if (i % 7 == 0)
                {
                    buget += currentExpences / numberOfPeoples;
                    currentExpences -= currentExpences / numberOfPeoples;
                }
                if (buget < 0)
                {
                    
                    isOutOfBuget = true;
                    break;
                }            
            }
            if (isOutOfBuget == false)
            {
                Console.WriteLine($"You have reached the destination. You have {buget:f2}$ budget left.");
            }
            else
            {
                double neededMoney = Math.Abs(buget);
                Console.WriteLine($"Not enough money to continue the trip. You need {neededMoney:f2}$ more.");
            }

            

        }
    }
}
