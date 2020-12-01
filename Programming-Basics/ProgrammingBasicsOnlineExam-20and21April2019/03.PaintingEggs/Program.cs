using System;

namespace _03.PaintingEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            string weightOfEggs = Console.ReadLine();
            string colorOfEggs = Console.ReadLine();
            int numberOfPartides = int.Parse(Console.ReadLine());
            double price = 0;
            switch (weightOfEggs) //"Large", "Medium" или "Small" "Red", "Green" или "Yellow"
            {
                case "Large":
                    if (colorOfEggs == "Red")
                    {
                        price = numberOfPartides * 16;
                    }
                    else if (colorOfEggs == "Green")
                    {
                        price = numberOfPartides * 12;
                    }
                    else if (colorOfEggs == "Yellow")
                    {
                        price = numberOfPartides * 9;
                    }
                    break;
                case "Medium":
                    if (colorOfEggs == "Red")
                    {
                        price = numberOfPartides * 13;
                    }
                    else if (colorOfEggs == "Green")
                    {
                        price = numberOfPartides * 9;
                    }
                    else if (colorOfEggs == "Yellow")
                    {
                        price = numberOfPartides * 7;
                    }
                    break;
                case "Small":
                    if (colorOfEggs == "Red")
                    {
                        price = numberOfPartides * 9;
                    }
                    else if (colorOfEggs == "Green")
                    {
                        price = numberOfPartides * 8;
                    }
                    else if (colorOfEggs == "Yellow")
                    {
                        price = numberOfPartides * 5;
                    }
                    break;

            }
            double totalPrice = price * 0.65;
            Console.WriteLine($"{totalPrice:f2} leva.");
        }
    }
}
