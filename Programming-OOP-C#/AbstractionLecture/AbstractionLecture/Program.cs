using System;

namespace AbstractionLecture
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Waiter
            Kitchen kitchen = new Kitchen();
            Waiter waiter = new Waiter();
            waiter.Kitchen = kitchen;
            Console.WriteLine("Order a meal:");
            var mealname = Console.ReadLine();

            // Techinician
            Technishian technishian = new Technishian();

            // CEO
            CEO ceo = new CEO();
            ceo.Kitchen.CalculateCost();



        }
    }
}
