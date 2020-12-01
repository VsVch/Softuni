using System;
using System.Security.Cryptography;

namespace _07.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            //string moveyName = Console.ReadLine();
            //int freePlaces = int.Parse(Console.ReadLine());
            //int student = 0;
            //int standard = 0;
            //int kid = 0;
            //int allTipeTickets = 0;
            //bool tIcketCounter = false;


            //while (moveyName != "Finish")
            //{
            //    moveyName = Console.ReadLine();
            //    freePlaces = int.Parse(Console.ReadLine());
            //    string ticketTipe = Console.ReadLine();

            //    while (tIcketCounter == false)               
            //    {

            //        if (ticketTipe == "student")
            //        {
            //            student++;
            //            allTipeTickets++;
            //        }
            //        else if (ticketTipe == "standard")
            //        {
            //            standard++;
            //            allTipeTickets++;
            //        }
            //        else if (ticketTipe == "kid")
            //        {
            //            allTipeTickets++;
            //            kid++;
            //        }
            //        else if(ticketTipe == "End")
            //        {
            //            break;

            //        }
            //        ticketTipe = Console.ReadLine();

            //    }

            //}
            //double filledPlace = allTipeTickets * 100 * 1.0 / freePlaces;
            //double studentTicketCount = student * 1.0 * 100 / allTipeTickets;
            //double standardTicketCount = standard * 1.0 * 100 / allTipeTickets;
            //double kidTicketCount = kid * 1.0 * 100 / allTipeTickets;
            //Console.WriteLine($"{moveyName} - {filledPlace}% ");
            //Console.WriteLine($"Total tickets: {allTipeTickets}");
            //Console.WriteLine($"{studentTicketCount:f2}% student tickets.");
            //Console.WriteLine($"{standardTicketCount:f2}% student tickets.");
            //Console.WriteLine($"{kidTicketCount:f2}% student tickets.");
            int totalStandarTickets = 0;
            int totalStudentTickets = 0;
            int totalKitTickets = 0;
            while (true)
            {
                string movie = Console.ReadLine();
                if (movie == "Finish")
                {
                    break;
                }
                int freeSpots = int.Parse(Console.ReadLine());
                int totalFreeSpots = freeSpots;
                int ticketsForMovei = 0;
                while (freeSpots > 0)
                {
                    string currentTicket = Console.ReadLine();
                    if (currentTicket == "End")
                    {
                        break;
                    }
                    switch (currentTicket)
                    {
                        case "standard":
                            totalStandarTickets++;
                            break;
                        case "student":
                            totalStudentTickets++;
                                break;
                        case "kid":
                            totalKitTickets++;
                                break;
                    }
                    ticketsForMovei++;
                    freeSpots--;
                }
                double capacity = ticketsForMovei * 1.0 * 100 / totalFreeSpots;
                Console.WriteLine($"{movie} - {capacity:f2}% full.");

            }
            int totalTickets = totalKitTickets + totalStandarTickets + totalStudentTickets;
            double averageStudentTickets = totalStudentTickets * 1.0 * 100 / totalTickets;
            double averageStandardTickets = totalStandarTickets * 1.0 * 100 / totalTickets;
            double averageKidsTickets = totalKitTickets * 1.0 * 100 / totalTickets;
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{averageStudentTickets:f2}% student tickets.");
            Console.WriteLine($"{averageStandardTickets:f2}% standard tickets.");
            Console.WriteLine($"{averageKidsTickets:f2}% kids tickets.");

        }
    }
}
