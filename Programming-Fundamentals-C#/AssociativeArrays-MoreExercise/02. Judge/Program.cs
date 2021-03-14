using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;

            var dict = new Dictionary<string, Dictionary<string, int>>();

            var userTotalPoint = new Dictionary<string, int>();
                        
            while ((text = Console.ReadLine()) != "no more time")
            {
                string[] info = text.Split("->");  // {username} -> {contest} -> {points}

                string userName = info[0];
                string contest = info[1];
                int points = int.Parse(info[2]);
                bool itMustSum = false;

                if (!dict.ContainsKey(contest))
                {
                    dict[contest] = new Dictionary<string, int>();
                    dict[contest][userName] = points;
                    itMustSum = true;
                }
                else               
                {
                    if (!dict[contest].ContainsKey(userName))
                    {
                        dict[contest][userName] = points;
                        itMustSum = true;
                    }
                    else
                    {
                        int currentPoint = dict[contest][userName];
                        if (currentPoint < points)
                        {
                            dict[contest][userName] = points;
                            points = points - currentPoint;
                            itMustSum = true;
                        }
                    }                    
                }
                if (!userTotalPoint.ContainsKey(userName))
                {
                    userTotalPoint[userName] = 0;
                }
                if (itMustSum)
                {
                    userTotalPoint[userName] += points;
                }
               
            }
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count} participants");
                int counter = 1;

                foreach (var item in kvp.Value
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{counter}.{item.Key} <:> {item.Value}");
                    counter++;
                }
            }
            Console.WriteLine($"Individual standings:");
            int counterForUser = 1;
            foreach (var kvp in userTotalPoint
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Value))
            {
                Console.WriteLine($"{counterForUser}.{kvp.Key} -> {kvp.Value}");
                counterForUser++;
            }
        }
    }
}
