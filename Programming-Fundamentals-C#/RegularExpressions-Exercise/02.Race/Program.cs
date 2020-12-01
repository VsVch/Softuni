using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] separator = { " ",","};

            string[] input = Console.ReadLine()
                .Split(separator, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> players = new Dictionary<string, int>();

            foreach (var player in input)
            {
                players.Add(player, 0);                
            }
            string namePattern = @"[\W\d]";
            string distancePattern = @"[\WA-Za-z]";
                        
            string code;            

            while ((code = Console.ReadLine()) != "end of race")
            {
                string name = Regex.Replace(code, namePattern, "");
                string distance = Regex.Replace(code, distancePattern, "");

                int tottalDistance = 0;

                for (int i = 0; i < distance.Length; i++)
                {
                    tottalDistance += int.Parse(distance[i].ToString());
                }

                if (players.ContainsKey(name))
                {

                    players[name] += tottalDistance;
                }
                
            }

            int count = 0;

            foreach (var player in players.OrderByDescending(v => v.Value))
            {
                count++;

                string output = string.Empty;

                if (count == 1)
                {
                    output = "1st";
                }
                else if (count == 2)
                {
                    output = "2nd";
                }
                else if (count == 3)
                {
                    output = "3rd";
                }
                else
                {
                    break;
                }

                Console.WriteLine($"{output} place: {player.Key}");
            }

        }
    }
}
