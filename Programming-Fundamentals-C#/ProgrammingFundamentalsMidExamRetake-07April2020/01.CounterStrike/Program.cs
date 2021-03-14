using System;

namespace _01.CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int batals = 0;

            int wins = 0;

            bool isWinBattles = true;


            while (input != "End of battle")
            {
                
                int distance = int.Parse(input);
                                
                batals++;

                if (energy < distance)
                {                    
                    Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {energy} energy");
                    isWinBattles = false;
                    break;
                }

                wins++;               
                energy -= distance;

                if (batals % 3 == 0)
                {
                    energy += batals;
                    
                }

                input = Console.ReadLine();
            }
            if (isWinBattles == true)
            {
                Console.WriteLine($"Won battles: {wins}. Energy left: {energy}");
            }
        }
    }
}
