using System;

namespace Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            Print(10);
            Print("String");
        }
        public static dynamic Print(dynamic element) 
        {
            Console.WriteLine(element);

            return 5;
        
        }
    }
}
