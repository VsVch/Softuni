using System;

namespace ValueTypesAndRefferenceTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 5;
            Plus(x);
            Console.WriteLine("After method");
            Console.WriteLine(x);
        }

        static void Plus(int x) 
        {
            x += 5;
            Console.WriteLine("In method");
            Console.WriteLine(x);
        
        }
    }
}
