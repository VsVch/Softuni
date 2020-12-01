using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.WarShips
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> piratShip = Console.ReadLine()
                                         .Split(">")
                                         .Select(int.Parse)
                                         .ToList();

            List<int> warShip = Console.ReadLine()
                                       .Split(">")
                                       .Select(int.Parse)
                                       .ToList();

            int maximumHealthCapacity = int.Parse(Console.ReadLine());
                       
            string input;

            int count = 0;

            int deadSells = 0;            

            while ((input = Console.ReadLine()) != "Retire") 
            {
                string[] command = input.Split().ToArray();

                string cmdArg = command[0];

                switch (cmdArg)
                {
                    case "Fire":
                        int index = int.Parse(command[1]);
                        int damage = int.Parse(command[2]);
                        int currentDamage = damage;

                        if (index < 0 || index >= warShip.Count)
                        {
                            continue;
                        }
                        else
                        {
                            for (int i = 0; i < warShip.Count; i++)
                            {
                                if (i == index)
                                {
                                    warShip[i] = warShip[i] - damage;
                                   
                                    if (warShip[i] <= 0)
                                    {                                        
                                        warShip.RemoveAt(i);
                                        Console.WriteLine($"You won! The enemy ship has sunken.");
                                        Environment.Exit(0);
                                    }
                                    break;
                                }
                                
                            }
                            
                        }
                        break;
                    case "Defend":
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);
                        int damageDefence = int.Parse(command[3]);

                        if (startIndex + endIndex < 0 || startIndex + endIndex >= warShip.Count - 1)
                        {
                            continue;
                        }
                        else
                        {
                            for (int i = 0; i < piratShip.Count; i++)
                            {
                                if (i == startIndex)
                                {
                                    for (int j = startIndex; j <= endIndex; j++)
                                    {
                                        piratShip[j] -= damageDefence;

                                        if (piratShip[i] <= 0)
                                        {
                                            Console.WriteLine($"You lost! The pirate ship has sunken.");
                                            Environment.Exit(0);
                                        }
                                    }
                                    break;
                                }
                                
                            }
                        }
                        break;
                    case "Repair":
                        int indexHealt = int.Parse(command[1]);
                        int healt = int.Parse(command[2]);

                        if (indexHealt < 0 || indexHealt >= piratShip.Count || healt  > 15)
                        {
                            continue;                            
                        }
                        else
                        {
                            for (int i = 0; i < piratShip.Count; i++)
                            {
                                if (piratShip[i] == piratShip[indexHealt])
                                {
                                    if (piratShip[i] + healt > 15)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        piratShip[i] += healt;
                                    }
                                    break;
                                }
                                
                            }
                        }
                        break;
                }
                if (cmdArg == "Status")
                {
                    

                    for (int i = 0; i < piratShip.Count; i++)
                    {
                        if (piratShip[i] < maximumHealthCapacity * 20/100 )
                        {
                            count++;                           
                        }
                    }
                    if (count > 0)
                    {
                        Console.WriteLine($"{count} sections need repair.");
                    }
                }
            }         
                       
               Console.WriteLine($"Pirate ship status: {piratShip.Sum()}");
               Console.WriteLine($"Warship status: {warShip.Sum()}");
            
           
        }
    }
}
