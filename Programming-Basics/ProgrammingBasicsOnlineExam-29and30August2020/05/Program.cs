using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());
            int numberGold = 0;
            int numberSilver = 0;
            int numberBronze = 0;
            double minNumber = double.MaxValue;
            string winerName = "";
            int minMinutes = 0;
            int minSecondes = 0;
            bool sTop = false;
            while (sTop != true)
            {               
                double totaltime = (minutes * 60 * 1.0) + seconds;
                 
                if (minNumber > totaltime)
                {
                    minNumber = totaltime;
                    winerName = name;
                    minMinutes = minutes;
                    minSecondes = seconds;
                }
                if (totaltime < 55)
                {
                    numberGold++;                   
                }
                else if (totaltime >= 55 && totaltime <= 85)
                {
                    numberSilver++;
                }
                else if (totaltime > 85 && totaltime <= 120)
                {                    
                    numberBronze++;
                }
                name = Console.ReadLine();
                if (name == "Finish")
                {
                    sTop = true;
                    break;
                }
                minutes = int.Parse(Console.ReadLine());
                seconds = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"With {minMinutes} minutes and {minSecondes} seconds {winerName} is the winner of the day!");
            Console.WriteLine($"Today's prizes are {numberGold} Gold {numberSilver} Silver and {numberBronze} Bronze cards!");
        }
    }
}
