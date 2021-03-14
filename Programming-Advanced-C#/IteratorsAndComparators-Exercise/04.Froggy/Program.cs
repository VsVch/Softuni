using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Froggy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] stones = Console.ReadLine()?
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake lake = new Lake(stones);

            List<int> OrderedList = new List<int>();

            foreach (var stone in lake)
            {
                OrderedList.Add(stone);
            }

            Console.Write(string.Join(", ",OrderedList));
        }
    }
}
