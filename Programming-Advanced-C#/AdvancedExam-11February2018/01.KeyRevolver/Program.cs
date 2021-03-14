using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeOfTheGunBarrel = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToList());
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToList());
            int valueOfTheIntelligence = int.Parse(Console.ReadLine());

            
            int buletsInThebegining = bullets.Count;
            int bulletCounter = sizeOfTheGunBarrel;
            while (bullets.Count != 0 && locks.Count != 0)
            {              
                                
                int bullet = bullets.Pop();
                int curLock = locks.Peek();
                bulletCounter--;

                if (bullet <= curLock )
                {
                    Console.WriteLine("Bang!");
                    curLock = locks.Dequeue();

                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (bulletCounter == 0)
                {
                    if (bullets.Count != 0)// >= sizeOfTheGunBarrel ???
                    {
                        Console.WriteLine("Reloading!");
                    }
                    bulletCounter = sizeOfTheGunBarrel;
                }

            }
           
            if (locks.Count == 0)
            {
                int moneyForBullets = (buletsInThebegining - bullets.Count) * bulletPrice;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOfTheIntelligence - moneyForBullets}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
