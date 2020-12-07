using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MOBAChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] separator = new string[] {"->","vs"," "};

            string input;

            Dictionary<string, Dictionary<string, int>> playersInfo 
                = new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine())!= "Season end")
            {
                List<string> playerInfo = input
                    .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (playerInfo.Count > 2)
                {
                    string name = playerInfo[0];
                    string position = playerInfo[1];
                    int skills = int.Parse(playerInfo[2]);                     
                                       
                    if (!playersInfo.ContainsKey(position))
                    {
                        playersInfo[position] = new Dictionary<string, int>();                       
                        playersInfo[position][name] = skills;
                    }
                    else
                    {
                        if (!playersInfo[position].ContainsKey(name))
                        {
                            playersInfo[position][name] = skills;
                            playersInfo[position][] += skills;
                            
                        }
                        else
                        {
                            int currentSkills = playersInfo[position][name];

                            if (currentSkills < skills)
                            {
                                playersInfo[position][name] = skills;
                            }
                        }
                    }
                    
                }                
                else 
                {

                }         
            }

            //"{player}: {totalSkill} skill"
            //"- {position} <::> {skill}"

            foreach (var item in playersInfo)
            {
                foreach (var kvp in item.Value.OrderByDescending(v =>v.Value).ThenBy(k=>k.Key))
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value} skill");

                    foreach (var lvp in playersInfo.OrderByDescending(k=>k.Key).ThenBy(v=>v.Value))
                    {
                        Console.WriteLine($"- {lvp.Key} <::> {kvp.Value}");
                    }
                    
                }   
                
            }
        }
    }
}
