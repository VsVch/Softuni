using System;

namespace _09SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;
            for (int i = 1; i <= n; i++)
            {
                
                Console.WriteLine($"{i + i - 1}");
                sum += i + i - 1;            
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
