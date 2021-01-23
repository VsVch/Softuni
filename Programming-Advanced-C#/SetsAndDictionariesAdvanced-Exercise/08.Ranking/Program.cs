using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dateExsam = new Dictionary<string, string>();

            string input;

            while ((input = Console.ReadLine()) != "end of contests") //{contest}:{password for contest}
            {
                string[] tokens = input.Split(":");

                string contest = tokens[0];
                string password = tokens[1];

                if (!dateExsam.ContainsKey(contest))
                {
                    dateExsam.Add(contest, password);
                }                
            }

            Dictionary<string, Dictionary<string, int>> examsScore = 
                new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "end of submissions") //{contest}=>{password}=>{username}=>{points}
            {
                string[] tokens = input.Split("=>");

                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (dateExsam.ContainsKey(contest) && dateExsam[contest] == password )
                {

                    if (!examsScore.ContainsKey(username))
                    {
                        examsScore.Add(username, new Dictionary<string, int>());
                    }

                    if (!examsScore[username].ContainsKey(contest))
                    {
                        examsScore[username].Add(contest, points);
                    }

                    if (examsScore[username][contest] < points)
                    {
                        examsScore[username][contest] = points;
                    }
                }
                else
                {
                    continue;
                }
            }
            KeyValuePair<string, Dictionary<string, int>> bestCandidate = 
                examsScore.OrderByDescending(v => v.Value.Values.Sum()).First();

            int bestCandidatePoints = bestCandidate.Value.Values.Sum();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidatePoints} points.");

            Console.WriteLine("Ranking:");

            foreach (var name in examsScore.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{name.Key}");

                foreach (var item in name.Value.OrderByDescending(v => v.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
