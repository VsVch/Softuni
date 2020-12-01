using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBakers = int.Parse(Console.ReadLine());
            int count = 0;
            int maxNumber = int.MinValue;
            string maxNumbersWiner = "";
            
            for (int j = 1; j <= numberOfBakers; j++)
            {
                string nameOfBeaker = Console.ReadLine();
                nameOfBeaker = Console.ReadLine();

                while (nameOfBeaker != "Stop")
                {
                    
                    count += pointForEasterCakes;
                    
                }
                if (count > maxNumber)
                {
                    maxNumber = count;
                    maxNumbersWiner = nameOfBeaker;
                }
                

                Console.WriteLine($"{nameOfBeaker} has {count:f0} points.");
                Console.WriteLine($"{maxNumbersWiner} is the new number 1!");
            }
           
            Console.WriteLine($"{maxNumbersWiner} won competition with {maxNumber:f0} points!");
        }
    }
}
