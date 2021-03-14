using System;

namespace _06.HighJump
{
    class Program
    {
        static void Main(string[] args)
        {
            int wantedHight = int.Parse(Console.ReadLine());
            int startHight = wantedHight - 30;
            int countJump = 0;            
            bool sTop = false;
            for (int i = startHight; i <= wantedHight; i +=5)
            {
                int tryscounter = 0;
                int jumpedHight = int.Parse(Console.ReadLine());
                if (sTop == true)
                {
                     break;
                }                
                for (int j = 1; j <= 3; j++)
                {                    
                    countJump++;
                    if (i < jumpedHight)
                    {
                        if (jumpedHight > wantedHight)
                        {
                            Console.WriteLine($"Tihomir succeeded, he jumped over {wantedHight:f0}cm after {countJump:f0} jumps.");
                        }
                        break;
                    }
                    else
                    {
                        tryscounter++;
                        if (tryscounter >= 3)
                        {
                            sTop = true;
                            break;
                        }                        
                    }                    
                    jumpedHight = int.Parse(Console.ReadLine());
                }
                if (sTop == true)
                {                    
                    Console.WriteLine($"Tihomir failed at {i:f0}cm after {countJump:f0} jumps.");
                    break;
                }
            }
            
        }
    }
}
