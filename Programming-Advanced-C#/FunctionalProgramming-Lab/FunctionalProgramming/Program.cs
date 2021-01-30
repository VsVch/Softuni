using System;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "5, 2, 7, 9, 8" ;

            int[] array = input
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                //.Select(x => int.Parse(x))
                .Select(Parser)
                .ToArray();


           array =  array.OrderBy(n => n).ToArray();
           array =  array.OrderBy(Sort).ToArray();

            Console.WriteLine(string.Join(" ", array));


        }
        static int Parser(string n) 
        {
            return int.Parse(n);
        
        }



        static int Sort(int n) 
        {
            return n;
        
        }
    }
}
