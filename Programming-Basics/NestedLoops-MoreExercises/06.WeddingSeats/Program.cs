using System;

namespace _06.WeddingSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            char sector = Console.ReadLine()[0];
            int rowsFirstSector = int.Parse(Console.ReadLine());
            int rowsOddRow = int.Parse(Console.ReadLine());
            for (int i = 'A'; i <= sector; i++)
            {
                for (int j = 1; j <= rowsFirstSector + 1; j++)
                {
                    for (int k = 'a'; k <= 'z'; k++)
                    {
                        if (rowsFirstSector % 2 == 0)
                        {
                            rowsFirstSector += 2;
                            Console.Write($"{i}{j}{k}; ");
                        }
                        Console.ReadLine();
                        
                    }
                }
            }
        }
    }
}
