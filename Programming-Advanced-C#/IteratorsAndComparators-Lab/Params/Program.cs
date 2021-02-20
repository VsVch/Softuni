using System;

namespace Params
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintNames("Lubcho", "Misho", "Mariq", "Sasho");
        }
        static void PrintNames(params string[] names) 
        {           

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }       
        
        }
    }
}
