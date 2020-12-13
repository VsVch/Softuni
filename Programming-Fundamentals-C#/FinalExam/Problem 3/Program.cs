using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            Dictionary<string, int> heroHealt = new Dictionary<string, int>();
            Dictionary<string, int> heroEnergy = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "Results")
            {
                string[] command = input.Split(":",StringSplitOptions.RemoveEmptyEntries);

                string cmdArd = command[0];

                if (cmdArd == "Add")
                {
                    string name = command[1];
                    int healt = int.Parse(command[2]);
                    int energy = int.Parse(command[3]);           


                    if (!heroHealt.ContainsKey(name))
                    {
                        heroHealt.Add(name, healt);
                        heroEnergy.Add(name, energy);
                       
                    }
                    else 
                    {
                        heroHealt[name] += healt;
                    }
                }
                else if(cmdArd == "Attack")
                {
                    string attackName = command[1];
                    string defendName = command[2];
                    int damange = int.Parse(command[3]);

                    if (heroEnergy.ContainsKey(attackName) && heroEnergy.ContainsKey(defendName))
                    {
                        heroHealt[defendName] -= damange;
                        heroEnergy[attackName] -= 1;

                        if (heroHealt[defendName] <= 0)
                        {
                            Console.WriteLine($"{defendName} was disqualified!");
                            heroHealt.Remove(defendName);
                            heroEnergy.Remove(defendName);
                        }
                        if (heroEnergy[attackName] <= 0)
                        {
                            Console.WriteLine($"{attackName} was disqualified!");
                            heroHealt.Remove(attackName);
                            heroEnergy.Remove(attackName);
                        }
                    }
                    else
                    {
                        
                    }

                }
                else if (cmdArd == "Delete")
                {
                    string userName = command[1];

                    if (userName == "All")
                    {
                        heroEnergy.Clear();
                        heroHealt.Clear();
                    }
                    if (heroEnergy.ContainsKey(userName))
                    {
                        heroHealt.Remove(userName);
                        heroEnergy.Remove(userName);
                    }
                }
            }

            Console.WriteLine($"People count: {heroHealt.Count}");

            foreach (var hero in heroHealt.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{hero.Key} - {hero.Value} - {heroEnergy[hero.Key]}");
            }
        }
    }    
}
