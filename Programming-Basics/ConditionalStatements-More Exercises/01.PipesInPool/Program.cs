using System;

namespace _01.PipesInPool
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int numV = int.Parse(Console.ReadLine());
            int numP1 = int.Parse(Console.ReadLine());
            int numP2 = int.Parse(Console.ReadLine());
            double numH = double.Parse(Console.ReadLine());
            double fwolPipe1 = numP1 * numH;
            double fwolPipe2 = numP2 * numH;
            double twopipes = fwolPipe1 + fwolPipe2;
            if (numV > twopipes)
            {
                double poolVolume = (twopipes * 100) / numV;
                double fwolPipe1Percenteg = (fwolPipe1 * 100 / twopipes);
                double fwolPipe2Percenteg = (fwolPipe2 * 100 / twopipes);

                Console.WriteLine($"The pool is {poolVolume:f2} % full.Pipe 1: {fwolPipe1Percenteg:f2} %.Pipe 2: {fwolPipe2Percenteg:f2}");
                
            }
            else if (numV < twopipes)
            {
                double pollvolume = twopipes - numV;
                Console.WriteLine($"For {numH:f2} hours the pool overflows with {pollvolume:f2} liters.");
            }
                            
        }
        
    }

}



