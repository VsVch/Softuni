using System;
using System.Collections.Generic;

namespace _03.Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string name = Console.ReadLine();
                    string heroType = Console.ReadLine();

                    BaseHero hero = heroConstructor(name, heroType);
                    heroes.Add(hero);
                }
                catch (ArgumentException ex)
                {
                    i--;
                    Console.WriteLine(ex.Message);
                }               
            }

            int raidBoss = int.Parse(Console.ReadLine());

            foreach (var item in heroes)
            {
                Console.WriteLine(item.CastAbility());
                raidBoss -= item.Power;
            }

            if (raidBoss > 0)
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine("Victory!");
            }
        }

        private static BaseHero heroConstructor(string name, string heroType)
        {
            BaseHero hero = null;

            if (heroType == nameof(Druid))
            {
                hero = new Druid(name);
            }
            else if (heroType == nameof(Paladin))
            {
                hero = new Paladin(name);
            }
            else if (heroType == nameof(Rogue))
            {
                hero = new Rogue(name);
            }
            else if (heroType == nameof(Warrior))
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new ArgumentException("Invalid hero!");
            }
            return hero;
        }
    }
}
