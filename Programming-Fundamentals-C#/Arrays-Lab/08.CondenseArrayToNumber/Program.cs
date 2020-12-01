using System;
using System.Linq;

namespace _08.CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] aarNumbers = Console.ReadLine()             
                .Split()
                .Select(int.Parse)
                .ToArray();

            
        }
    }
}
