using System;

namespace _05.ChallengТheWedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int mans = int.Parse(Console.ReadLine());
            int womans = int.Parse(Console.ReadLine());
            int numOfTables = int.Parse(Console.ReadLine());
            int table = 0;
        
            for (int i = 1; i <= mans; i++)
            {
                for (int j = 1; j <= womans; j++)
                {
                    table++;
                    
                        if (table > numOfTables)
                        {
                            Environment.Exit(0);

                        }


                    Console.Write($"({i} <-> {j}) ");
                }
                
            }
            
             
        }
    }
}
