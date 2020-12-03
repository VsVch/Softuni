using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            Dictionary<string, string> contestsPaswords = new Dictionary<string, string>();

            Dictionary<string, Dictionary<string, int>> scoreTable
                = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, int> bestUser = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "end of contests") // {contest}:{password for contest}
            {
                string[] array = input.Split(":");

                string contest = array[0];
                string password = array[1];

                if (!contestsPaswords.ContainsKey(contest))
                {
                    contestsPaswords.Add(contest, password);
                }
                else
                {
                    contestsPaswords[contest] = password;
                }
            }
            while ((input = Console.ReadLine()) != "end of submissions") // {contest}=>{password}=>{username}=>{points}
            {
                string[] array = input.Split("=>");

                string contest = array[0];
                string password = array[1];
                string userName = array[2];
                int points = int.Parse(array[3]);

                if (contestsPaswords.ContainsKey(contest) && contestsPaswords.ContainsValue(password))
                {

                    if (!scoreTable.ContainsKey(userName))
                    {
                        scoreTable.Add(userName, new Dictionary<string, int>());
                        scoreTable[userName].Add(contest, points);
                        bestUser.Add(userName, points);
                    }
                    else if (!scoreTable[userName].ContainsKey(contest))
                    {
                        scoreTable[userName].Add(contest, points);
                        bestUser[userName] += points;

                    }
                    else
                    {
                        if (points > scoreTable[userName][contest])
                        {
                            bestUser[userName] -= scoreTable[userName][contest];
                            bestUser[userName] += points;
                            scoreTable[userName][contest] = points;

                        }

                    }

                }

            }

            foreach (var user in bestUser.OrderByDescending(v => v.Value))
            {
                Console.WriteLine($"Best candidate is {user.Key} with total {user.Value} points.");
                break;
            }
            Console.WriteLine($"Ranking:");
            foreach (var item in scoreTable.OrderBy(k => k.Key))
            {
                Console.WriteLine($"{item.Key}");

                foreach (var kvp in item.Value.OrderByDescending(v => v.Value))
                {
                    Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }        
}
