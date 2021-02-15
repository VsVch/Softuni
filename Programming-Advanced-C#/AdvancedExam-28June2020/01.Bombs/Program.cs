using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> efects = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Stack<int> casings = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Dictionary<string, Dictionary<int,int>> bombs = new Dictionary<string, Dictionary<int, int>>()
            {
                {"Datura Bombs", new Dictionary<int, int>(){ { 40, 0} } },
                {"Cherry Bombs" , new Dictionary<int, int>(){ { 60, 0} } },
                {"Smoke Decoy Bombs" , new Dictionary<int, int>(){ { 120,0} } },              
            };

            while (efects.Count != 0 && casings.Count != 0)
            {
                int bombEfect = efects.Dequeue();
                int bombCasing = casings.Pop();
                int bomb = bombEfect + bombCasing;

                if (bombs["Datura Bombs"].ContainsKey(bomb))
                {
                    bombs["Datura Bombs"][bomb]++;
                }
                else if (bombs["Cherry Bombs"].ContainsKey(bomb))
                {
                    bombs["Cherry Bombs"][bomb]++;
                }
                else if (bombs["Smoke Decoy Bombs"].ContainsKey(bomb))
                {
                    bombs["Smoke Decoy Bombs"][bomb]++;
                }
                else 
                {
                    while (true)
                    {

                        bomb -= 5;                        

                        if (bomb == 120)
                        {
                            bombs["Smoke Decoy Bombs"][bomb]++;
                            break;
                        }
                        else if (bomb == 60)
                        {
                            bombs["Cherry Bombs"][bomb]++;
                            break;
                        }
                        else if (bomb == 40)
                        {
                            bombs["Datura Bombs"][bomb]++;
                            break;
                        }
                        
                    }
                }

                if (bombs["Smoke Decoy Bombs"][120] >= 3 
                    && bombs["Cherry Bombs"][60] >=3 
                    && bombs["Datura Bombs"][40] >= 3)
                {
                    break;
                }               
               
            }

            bool isEnoughtBombsCount = true;

            foreach (var bomb in bombs)
            {
                foreach (var item in bomb.Value)
                {
                    if (item.Value < 3)
                    {
                        isEnoughtBombsCount = false;
                        break;
                    }
                }
            }

            if (isEnoughtBombsCount)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (efects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", efects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            if (casings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in bombs.OrderBy(x=> x.Key))
            {
                foreach (var item in bomb.Value)
                {
                    Console.WriteLine($"{bomb.Key}: {item.Value}");
                }
            }
        }
    }
}
