using System;

namespace _08TownInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string townName = Console.ReadLine();
            int townPopolation = int.Parse(Console.ReadLine());
            int cityArea = int.Parse(Console.ReadLine());

            Console.WriteLine($"Town {townName} has population of {townPopolation} and area {cityArea} square km.");
        }
    }
}
