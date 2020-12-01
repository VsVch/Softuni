using System;

namespace _04.EasterEggsBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfeggsPlayer1 = int.Parse(Console.ReadLine());
            int numberOfeggsPlayer2 = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            
            bool sTop = false;
            while (text == "End of battle" || sTop != true)
            {
                if (text == "End of battle")
                {
                    Console.WriteLine($"Player one has {numberOfeggsPlayer1} eggs left.");
                    Console.WriteLine($"Player two has {numberOfeggsPlayer2} eggs left.");
                    Environment.Exit(0);
                }
                if (text == "one")
                {
                    numberOfeggsPlayer2--;                   
                    if (numberOfeggsPlayer2 == 0)
                    {
                        sTop = true;
                    }
                }
                else if (text == "two")
                {                    
                    numberOfeggsPlayer1--;
                    if (numberOfeggsPlayer1 == 0)
                    {
                        sTop = true;
                    }
                }
                text = Console.ReadLine();
            }
            double totallEggsLeft = Math.Abs(numberOfeggsPlayer1 - numberOfeggsPlayer2);
            if (numberOfeggsPlayer1 < numberOfeggsPlayer2)
            {
                Console.WriteLine($" Player one is out of eggs. Player two has {totallEggsLeft:f0} eggs left.");
            }
            else
            {
                Console.WriteLine($"Player two is out of eggs. Player one has {totallEggsLeft:f0} eggs left.");
            }
        }
    }
}
