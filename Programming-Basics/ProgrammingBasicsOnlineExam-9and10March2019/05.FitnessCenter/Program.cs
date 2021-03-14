using System;

namespace _05.FitnessCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfClients = int.Parse(Console.ReadLine());
            int countTreningPeoples = 0;
            int backTreningPeoples = 0;
            int chestTreningPeoples = 0;
            int legsTreningPeoples = 0;
            int absTreningPeoples = 0;
            int countVisitors = 0;
            int peoplesBuyedProteinShake = 0;
            int peoplesBuyedProteinBar = 0;
            
            for (int i = 1; i <= numberOfClients; i++) // ("Back", "Chest", 'Legs", "Abs") ("Protein shake", "Protein bar")
            {
                string jymVisitors = Console.ReadLine();
                if (jymVisitors == "Back" || jymVisitors == "Chest" || jymVisitors == "Legs" || jymVisitors == "Abs")
                {
                    countTreningPeoples++;
                    if (jymVisitors == "Back")
                    {
                        backTreningPeoples++;

                    }
                    else if (jymVisitors == "Chest")
                    {
                        chestTreningPeoples++;
                    }
                    else if (jymVisitors == "Legs")
                    {
                        legsTreningPeoples++;
                    }
                    else if (jymVisitors == "Abs")
                    {
                        absTreningPeoples++;
                    }
                }
                if (jymVisitors == "Protein shake" || jymVisitors == "Protein bar")
                {
                    countVisitors++;
                    if (jymVisitors == "Protein shake")
                    {
                        peoplesBuyedProteinShake++;
                    }
                    else if (jymVisitors == "Protein bar")
                    {
                        peoplesBuyedProteinBar++;
                    }
                }
            }
            double percentTreningPeoples = 1.0 * countTreningPeoples * 100 / numberOfClients;
            double percentPeoplesToBuyProtein = 1.0 * countVisitors * 100 / numberOfClients;
            Console.WriteLine($"{backTreningPeoples:f0} - back");
            Console.WriteLine($"{chestTreningPeoples:f0} - chest");
            Console.WriteLine($"{legsTreningPeoples:f0} - legs");
            Console.WriteLine($"{absTreningPeoples:f0} - abs");
            Console.WriteLine($"{peoplesBuyedProteinShake:f0} - protein shake");
            Console.WriteLine($"{peoplesBuyedProteinBar:f0} - protein bar");
            Console.WriteLine($"{percentTreningPeoples:f2}% - work out");
            Console.WriteLine($"{percentPeoplesToBuyProtein:f2}% - protein");

        }
    }
}
