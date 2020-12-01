using System;

namespace _03.OscarsWeekInCinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfMovie = Console.ReadLine(); // ("A Star Is Born", "Bohemian Rhapsody","Green Book" или )
            string kindOfHall = Console.ReadLine(); // ("normal", "luxury" или "ultra luxury")
            int numberOfTickets = int.Parse(Console.ReadLine());
            double priceForticket = 0;
            switch (nameOfMovie)
            {
                case "A Star Is Born":
                    if (kindOfHall == "normal")
                    {
                        priceForticket = 7.5;
                    }
                    else if (kindOfHall == "luxury")
                    {
                        priceForticket = 10.5;
                    }
                    else if (kindOfHall == "ultra luxury")
                    {
                        priceForticket = 13.5;
                    }
                    break;
                case "Bohemian Rhapsody":
                    if (kindOfHall == "normal")
                    {
                        priceForticket = 7.35;
                    }
                    else if (kindOfHall == "luxury")
                    {
                        priceForticket = 9.45;
                    }
                    else if (kindOfHall == "ultra luxury")
                    {
                        priceForticket = 12.75;
                    }
                    break;
                case "Green Book":
                    if (kindOfHall == "normal")
                    {
                        priceForticket = 8.15;
                    }
                    else if (kindOfHall == "luxury")
                    {
                        priceForticket = 10.25;
                    }
                    else if (kindOfHall == "ultra luxury")
                    {
                        priceForticket = 13.25;
                    }
                    break;
                case "The Favourite":
                    if (kindOfHall == "normal")
                    {
                        priceForticket = 8.75;
                    }
                    else if (kindOfHall == "luxury")
                    {
                        priceForticket = 11.55;
                    }
                    else if (kindOfHall == "ultra luxury")
                    {
                        priceForticket = 13.95;
                    }
                    break;
            }
            double totalPrice = priceForticket * numberOfTickets;
            Console.WriteLine($"{nameOfMovie} -> {totalPrice:f2} lv.");

        }
    }
}
