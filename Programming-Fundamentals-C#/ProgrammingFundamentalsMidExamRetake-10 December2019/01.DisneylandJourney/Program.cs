using System;

namespace _01.DisneylandJourney
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripCost = double.Parse(Console.ReadLine());

            int mounths = int.Parse(Console.ReadLine());

            double mounthsMoneySave = 0; 

            for (int i = 1; i <= mounths; i++)
            {

                if (i != 1)
                {
                    if (i % 2 == 1)
                    {
                        mounthsMoneySave -= mounthsMoneySave * 16 / 100;
                    }

                }
                               
                                
                if (i % 4 == 0)
                {
                    mounthsMoneySave += mounthsMoneySave * 25 / 100;
                }
                mounthsMoneySave += tripCost * 25 / 100;
            }
            double money = Math.Abs(tripCost - mounthsMoneySave);
            if (tripCost > mounthsMoneySave)
            {
                
                Console.WriteLine($"Sorry. You need {money:f2}lv. more.");
            }
            else
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {money:f2}lv. for souvenirs.");
            }
            
        }
    }
}
