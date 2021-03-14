using System;

namespace _03PassedorFailed
{
    class Program
    {
        static void Main(string[] args)
        {
            double degre = double.Parse(Console.ReadLine());

            if (degre >= 3.00)
            {
                Console.WriteLine("Passed!");
            }
            else
            {
                Console.WriteLine("Failed!");    
            }

        }
    }
}
