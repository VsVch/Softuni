using System;

namespace _04.SumofTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int counter = 0;
            bool cOunter = false;
            for (int i = n; i <= m; i++)
            {
                for (int j = n; j <= m; j++)
                {
                    counter++;
                    if (i + j == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {j} = {magicNumber})");
                        cOunter = true;
                        Environment.Exit(0);
                    }
                    
                }
            
            }
            if (cOunter == false)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
            }


        }
    }
}
