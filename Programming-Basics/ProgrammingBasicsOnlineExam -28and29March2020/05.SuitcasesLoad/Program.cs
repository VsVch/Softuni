using System;
using System.Threading;

namespace _05.SuitcasesLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacityOfTrunk = double.Parse(Console.ReadLine());
            bool sTop = false;
            double suitcases = 0;
            double count = 0;
            while (sTop != true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {                   
                    sTop = true;
                    break;
                }
                if (capacityOfTrunk < suitcases)
                {
                    Console.WriteLine("No more space!");
                    sTop = true;
                    count = count - 1;
                    break;
                }
                double volumOfSuitcases = double.Parse(input);
                count++;
                if (count % 3 == 0)
                {
                    suitcases += volumOfSuitcases * 1.1;                                      
                }
                else
                {
                    suitcases += volumOfSuitcases;
                }
                             
            }
            if (capacityOfTrunk >= suitcases)
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
                
            }           
            Console.WriteLine($"Statistic: {count} suitcases loaded.");
        }
    }
}
