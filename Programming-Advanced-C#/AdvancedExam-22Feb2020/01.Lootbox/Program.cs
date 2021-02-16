using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstLootBoxes = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Stack<int> secondLootBoxes = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int evenItems = 0;

            while (firstLootBoxes.Count != 0 && secondLootBoxes.Count != 0)
            {
                int firstItem = firstLootBoxes.Peek();
                int secondItem = secondLootBoxes.Pop();
                int item = firstItem + secondItem;

                if (item % 2 == 0)
                {
                    evenItems += item;
                    firstItem = firstLootBoxes.Dequeue();

                }
                else
                {
                    firstLootBoxes.Enqueue(secondItem);
                }
            }
            if (firstLootBoxes.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondLootBoxes.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (evenItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {evenItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {evenItems}");
            }
        }
    }
}
