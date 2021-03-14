using System;

namespace _01.TheHuntingGames
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfAdvanture = int.Parse(Console.ReadLine());
            int numberOFPeoples = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterPerDayPerPerson = double.Parse(Console.ReadLine());
            double foodPerDayPerPerson = double.Parse(Console.ReadLine());


            double totalWater = daysOfAdvanture * numberOFPeoples * waterPerDayPerPerson;

            double totalFood = daysOfAdvanture * numberOFPeoples * foodPerDayPerPerson;

            for (int i = 1; i <= daysOfAdvanture; i++)
            {
                
                double energyLose = double.Parse(Console.ReadLine());

                groupEnergy -= energyLose;

                if (i % 2 == 0)
                {
                    groupEnergy *= 1.05;

                    totalWater *= 0.70;
                }

                if (i % 3 == 0)
                {
                    groupEnergy *= 1.10;

                    totalFood -= totalFood / numberOFPeoples;

                }
                if (groupEnergy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
                    break;
                }
                
            }
            if (groupEnergy > 0)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");
            }

            

        }
    }
}
