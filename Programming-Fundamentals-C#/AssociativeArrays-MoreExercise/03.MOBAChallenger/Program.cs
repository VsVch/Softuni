using System;
using System.Collections.Generic;
using System.Linq;
 
namespace MOBAChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            var palyerPoll = new SortedDictionary<string, Dictionary<string, int>>(); 
            while (true)
            {
                string input = Console.ReadLine();

                if (input.Equals("Season end"))
                {
                    break;
                }

                if (input.Contains(" -> "))
                {
                    string[] command = input.Split(" -> ");
                    string player = command[0];
                    string position = command[1];
                    int skill = int.Parse(command[2]);

                    if (!palyerPoll.ContainsKey(player))
                    {
                        palyerPoll.Add(player, new Dictionary<string, int>());
                    }

                    if (!palyerPoll[player].ContainsKey(position))
                    {
                        palyerPoll[player].Add(position, 0);
                    }

                    if (palyerPoll[player][position] <= skill)
                    {
                        palyerPoll[player][position] = skill;
                    }
                }
                else
                {
                    string[] PlayerVSplayer = input.Split(" vs ");

                    string firstPlayer = PlayerVSplayer[0];
                    string secondPlayer = PlayerVSplayer[1];

=======
            var palyerPoll = new SortedDictionary<string, Dictionary<string, int>>();
 
            while (true)
            {
                string input = Console.ReadLine();
 
                if (input.Equals("Season end"))
                {
                    break;
                }
 
                if (input.Contains(" -> "))
                {
                    string[] command = input.Split(" -> ");
                    string player = command[0];
                    string position = command[1];
                    int skill = int.Parse(command[2]);
 
                    if (!palyerPoll.ContainsKey(player))
                    {
                        palyerPoll.Add(player, new Dictionary<string, int>());
                    }
 
                    if (!palyerPoll[player].ContainsKey(position))
                    {
                        palyerPoll[player].Add(position, 0);
                    }
 
                    if (palyerPoll[player][position] <= skill)
                    {
                        palyerPoll[player][position] = skill;
                    }
                }
                else
                {
                    string[] PlayerVSplayer = input.Split(" vs ");
 
                    string firstPlayer = PlayerVSplayer[0];
                    string secondPlayer = PlayerVSplayer[1];
 
>>>>>>> f254f4277b3e88e9aadef7a6d4e8f82a0208f53b
                    if (!palyerPoll.ContainsKey(firstPlayer) || !palyerPoll.ContainsKey(secondPlayer))
                    {
                        continue;
                    }
<<<<<<< HEAD

                    bool commonPosition = false;

=======
 
                    bool commonPosition = false;
 
>>>>>>> f254f4277b3e88e9aadef7a6d4e8f82a0208f53b
                    foreach (var item in palyerPoll[firstPlayer])
                    {
                        if (palyerPoll[secondPlayer].ContainsKey(item.Key))
                        {
                            commonPosition = true;
                        }
                    }
<<<<<<< HEAD

                    int totalSkills1 = 0;
                    int totalSkills2 = 0;

=======
 
                    int totalSkills1 = 0;
                    int totalSkills2 = 0;
 
>>>>>>> f254f4277b3e88e9aadef7a6d4e8f82a0208f53b
                    if (commonPosition)
                    {
                        totalSkills1 = palyerPoll[firstPlayer].Values.Sum();
                        totalSkills2 = palyerPoll[secondPlayer].Values.Sum();
<<<<<<< HEAD

=======
 
>>>>>>> f254f4277b3e88e9aadef7a6d4e8f82a0208f53b
                        if (totalSkills1 > totalSkills2)
                        {
                            palyerPoll.Remove(secondPlayer);
                        }
                        else if (totalSkills2 > totalSkills1)
                        {
                            palyerPoll.Remove(firstPlayer);
                        }
                    }
                }
            }
<<<<<<< HEAD

            foreach (var item in palyerPoll.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(c => c.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Values.Sum()} skill");

=======
 
            foreach (var item in palyerPoll.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(c => c.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Values.Sum()} skill");
 
>>>>>>> f254f4277b3e88e9aadef7a6d4e8f82a0208f53b
                foreach (var men in item.Value.OrderByDescending(x => x.Value).ThenBy(c => c.Key))
                {
                    Console.WriteLine($"- {men.Key} <::> {men.Value}");
                }
            }
        }
    }
}