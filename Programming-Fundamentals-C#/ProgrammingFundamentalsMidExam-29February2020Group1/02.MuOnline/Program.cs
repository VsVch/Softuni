using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace _02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int health = 100;

            int currentHealth = 100;

            int tokens = 0;

            string monster = string.Empty;

            int bestRoomsCounter = 0;

            List<string> dungeonsRoom = Console.ReadLine()
                                              .Split("|")
                                              .ToList();
            bool IsDungeonsEnd = false;

            while (IsDungeonsEnd != true)
            {
                if (dungeonsRoom.Count == 0 || health == 0)
                {
                    IsDungeonsEnd = true;
                    break;
                }
                bestRoomsCounter++;
                string[] command = dungeonsRoom[0]
                                                .Split(" ")
                                                .ToArray();
                               
                 string cmdArg = command[0];

                 int points = int.Parse(command[1]);

                if (cmdArg == "potion")
                {
                    health += points;

                    if (health > 100)
                    {
                        health = 100;

                        Console.WriteLine($"You healed for {health - currentHealth} hp.");
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {points} hp.");                        
                    }
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (cmdArg == "chest")
                {
                    tokens += points;

                    Console.WriteLine($"You found {points} bitcoins.");
                }
                else
                {
                    monster = cmdArg;

                    health -= points;

                    currentHealth -= points;

                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {bestRoomsCounter}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {monster}.");
                    }
                }
                            
                dungeonsRoom.Remove(dungeonsRoom[0]);
                               

            }
            if (health > 0)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {tokens}");
                Console.WriteLine($"Health: {health}");
            }
            
        }
    }
}
