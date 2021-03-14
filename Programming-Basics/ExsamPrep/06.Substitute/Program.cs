using System;

namespace _06.Substitute
{
    class Program
    {
        static void Main(string[] args)
        {
            int K = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            
            for (int i = K; i <= 8; i++)
            {
                for (int j = 9; j >= L; j--)
                {
                    for (int o = M; o <= 8; o++)
                    {
                        for (int p = 9; p >= N; p--)
                        {

                            if (i % 2 == 0 && j % 2 != 0 && o % 2 == 0 && p % 2 != 0)
                            {
                                
                                if (i + j == o + p)
                                {
                                    Console.WriteLine($"Cannot change the same player.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"{i}{j} - {o}{p}");
                                }                             
                                
                            }
                            
                        }
                        
                    }
                    
                }
            }
          

        }
    }
}
