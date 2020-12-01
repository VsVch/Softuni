using System;

namespace _03.WorldSnookerChampionship
{
    class Program
    {
        static void Main(string[] args)
        {
            string championshipStage = Console.ReadLine();
            string tipeOfTickets = Console.ReadLine();
            int numberOfTickets = int.Parse(Console.ReadLine());
            char pictureWhitTrophy = Console.ReadLine()[0];
            double priceForATicket = 0;
            switch (tipeOfTickets) // “Standard”, “Premium” или “VIP” “Quarter final ”, “Semi final” или “Final”
            {
                case "Standard":
                    if (championshipStage == "Quarter final")
                    {
                        priceForATicket = 55.5;
                    }
                    else if (championshipStage == "Semi final")
                    {
                        priceForATicket = 75.88;
                    }
                    else if (championshipStage == "Final")
                    {
                        priceForATicket = 110.10;
                    }
                    break;
                case "Premium":
                    if (championshipStage == "Quarter final")
                    {
                        priceForATicket = 105.2;
                    }
                    else if (championshipStage == "Semi final")
                    {
                        priceForATicket = 125.22;
                    }
                    else if (championshipStage == "Final")
                    {
                        priceForATicket = 160.66;
                    }
                    break;
                case "VIP":
                    if (championshipStage == "Quarter final")
                    {
                        priceForATicket = 180.9;
                    }
                    else if (championshipStage == "Semi final")
                    {
                        priceForATicket = 300.4;
                    }
                    else if (championshipStage == "Final")
                    {
                        priceForATicket = 400;
                    }
                    break;
            }
            double priceForAllTickets = priceForATicket * numberOfTickets;
            if (priceForAllTickets > 4000)
            {
                priceForAllTickets *= 0.75;
                

            }
            else if (priceForAllTickets > 2500 && priceForAllTickets <= 4000)
            {
                priceForAllTickets *= 0.90;
                if (pictureWhitTrophy == 'Y')
                {
                    priceForAllTickets += 40 * numberOfTickets;
                }

            }
            else if (priceForAllTickets <= 2500)
            {
                
                if (pictureWhitTrophy == 'Y')
                {
                    priceForAllTickets += 40 * numberOfTickets;
                }
            } 
            
            Console.WriteLine($"{priceForAllTickets:f2}");
        }
    }
}
