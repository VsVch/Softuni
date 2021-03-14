using System;

namespace _10MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                int sum = i * number;
                Console.WriteLine($"{number} X {i} = {sum}");
            }
        }
    }
}
