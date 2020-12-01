using System;

namespace _04.EasterShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialNumberOfEggs = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            int numberOfSoldedEggs = 0;
            bool sTop = false;            
            while (sTop != true)
            {
                if (text == "Close")
                {
                    Console.WriteLine($"Store is closed!");
                    Console.WriteLine($"{numberOfSoldedEggs:f0} eggs sold.");
                    sTop = true;
                    Environment.Exit(0);
                }
                int numberOfEggs = int.Parse(Console.ReadLine());
                if (initialNumberOfEggs - numberOfEggs <= 0 && text != "Fill")
                {
                    Console.WriteLine($"Not enough eggs in store!");
                    Console.WriteLine($"You can buy only {initialNumberOfEggs:f0}.");
                    sTop = true;
                    Environment.Exit(0);
                }
                
                
                if (text == "Buy")
                {
                    initialNumberOfEggs -= numberOfEggs;
                    numberOfSoldedEggs += numberOfEggs;
                }
                if (text == "Fill")
                {
                    initialNumberOfEggs += numberOfEggs;
                }
                text = Console.ReadLine();
            }
        }
    }
}
