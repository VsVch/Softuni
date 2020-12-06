using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> hpList = new Dictionary<string, int>();

            Dictionary<string, int> mpList = new Dictionary<string, int>();

            int maxHp = 100;

            int maxMp = 200;

            for (int i = 0; i < n; i++) // {hero name} {HP} {MP} 
            {
                string hero = Console.ReadLine();

                string[] heroSkills = hero
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string heroName = heroSkills[0];

                int hp = int.Parse(heroSkills[1]);

                int mp = int.Parse(heroSkills[2]);

                if (!hpList.ContainsKey(heroName))
                {
                    hpList.Add(heroName, hp);
                    mpList.Add(heroName, mp);
                }

            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input
                    .Split(" - ",StringSplitOptions.RemoveEmptyEntries);

                string cmdArg = command[0];
                string heroName = command[1];

                if (cmdArg == "CastSpell") // {MP needed} – {spell name}
                {

                    int mpSpell = int.Parse(command[2]);
                    string spellName = command[3];


                    if (mpSpell > mpList[heroName])
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                    else
                    {
                        mpList[heroName] -= mpSpell;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {mpList[heroName]} MP!");
                    }
                }
                else if (cmdArg == "TakeDamage") // {damage} – {attacker}
                {
                    int damage = int.Parse(command[2]);
                    string attacker = command[3];

                    if (damage < hpList[heroName])
                    {
                        hpList[heroName] -= damage;

                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {hpList[heroName]} HP left!");
                    }
                    else
                    {
                        hpList.Remove(heroName);
                        mpList.Remove(heroName);

                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                }
                else if (cmdArg == "Recharge") // {amount}
                {
                    int amountMp= int.Parse(command[2]);
                    int currendAmountMp = mpList[heroName];

                    mpList[heroName] += amountMp;

                    if (mpList[heroName] > maxMp)
                    {
                        mpList[heroName] = maxMp;

                        Console.WriteLine($"{heroName} recharged for {maxMp - currendAmountMp} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} recharged for {amountMp} MP!");
                    }                

                }
                else if (cmdArg == "Heal") // {amount}
                {
                    int amountHp = int.Parse(command[2]);
                    int currentAmountHp = hpList[heroName];

                    hpList[heroName] += amountHp;

                    if (hpList[heroName] > maxHp)
                    {
                        hpList[heroName] = maxHp;

                        Console.WriteLine($"{heroName} healed for {maxHp - currentAmountHp} HP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} healed for {amountHp} HP!");    
                    }
                }
            }
            foreach (var hero in hpList.OrderByDescending(v =>v.Value).ThenBy(k =>k.Key))
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"HP: {hero.Value}");
                Console.WriteLine($"MP: {mpList[hero.Key]}");
                
            }
                       
        }
    }
}
