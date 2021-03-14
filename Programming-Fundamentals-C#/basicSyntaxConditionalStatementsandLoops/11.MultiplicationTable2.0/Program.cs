using System;

namespace _11.MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var multiplier = int.Parse(Console.ReadLine());

            if (multiplier > 10)
            {
                var bigerMultiplier = num * multiplier;
                Console.WriteLine($"{num} X {multiplier} = {bigerMultiplier}");
            }
            else
            {
                for (var i = multiplier; i <= 10; i++)
                {
                    int totallMultiplier = num * i;
                    Console.WriteLine($"{num} X {i} = {totallMultiplier}");
                }
            }
            
        }
    }
}
