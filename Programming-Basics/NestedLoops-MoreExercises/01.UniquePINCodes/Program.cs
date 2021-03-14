using System;

namespace _01.UniquePINCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int topLimitNumberOne = int.Parse(Console.ReadLine());
            int topLimitNumberTwo = int.Parse(Console.ReadLine());
            int topLimitNumberThree = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= topLimitNumberOne; i++)
            {                              
                for (int j = 1; j <= topLimitNumberTwo; j++)
                {
                    for (int k = 1; k <= topLimitNumberThree; k++)
                    {
                        if (i % 2 == 0)
                        {
                            if (j == 2 || j == 3 || j == 5 || j == 7)
                            {
                                if (k % 2 == 0)
                                {
                                    Console.WriteLine($"{i} {j} {k}");
                                }
                            }
                        }
                    }                       
                }                
            }            
        }
    }
}
