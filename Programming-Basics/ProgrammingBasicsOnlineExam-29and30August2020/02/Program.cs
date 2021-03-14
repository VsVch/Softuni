using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            int numTickets = int.Parse(Console.ReadLine());
            double buget = double.Parse(Console.ReadLine());
            double priceForOneTicket = double.Parse(Console.ReadLine());
            double priceForAllTicket = numTickets * priceForOneTicket;
            if (priceForAllTicket > buget)
            {
                Console.WriteLine($"The budget of {buget:f0}$ is not enough. Your client can't buy {numTickets:f0} tickets with this budget!");
                
            }
            else if (buget >= priceForAllTicket)
            {
                double change = buget - priceForAllTicket;
                Console.WriteLine($"You can sell your client {numTickets:f0} tickets for the price of {priceForAllTicket:f0}$!");
                Console.WriteLine($"Your client should become a change of {change:f0}$!");
            }
        }
    }
}
