using System;
using System.Collections.Generic;

namespace _05.FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {         
                    
            var teamsByName = new Dictionary<string, Team>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {                
                try
                {                

                    string[] command = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                    string cmdArg = command[0];

                    if (cmdArg == "Add") // Add;Arsenal;Kieran_Gibbs;75;85;84;92;67
                    {                    // endurance, sprint, dribble, passing and shooting
                        string dataTeamName = command[1];

                        if (!teamsByName.ContainsKey(dataTeamName))
                        {
                            Console.WriteLine($"Team {dataTeamName} does not exist.");
                            continue;
                        }
                        string currPlayerName = command[2];
                        int endurance = int.Parse(command[3]);
                        int sprint = int.Parse(command[4]);
                        int dribble = int.Parse(command[5]);
                        int passing = int.Parse(command[6]);
                        int shooting = int.Parse(command[7]);

                        Player player = new Player(currPlayerName, endurance, sprint, dribble, passing, shooting);

                        var team = teamsByName[dataTeamName];

                        team.AddPlayer(player);
                       
                    }
                    else if (cmdArg == "Remove")
                    {
                        string currTeamName = command[1];
                        string currPlayerName = command[2];

                        var team = teamsByName[currTeamName];
                        team.RemovePlayer(currPlayerName);
                    }
                    else if (cmdArg == "Rating")
                    {
                        string currTeamName = command[1];

                        if (!teamsByName.ContainsKey(currTeamName))
                        {
                           Console.WriteLine($"Team {currTeamName} does not exist.");
                           continue;
                        }
                        var team = teamsByName[currTeamName];

                        Console.WriteLine($"{team.Name} - {team.Rating}");
                    }
                    else if (cmdArg == "Team")
                    {
                        string currTeamName = command[1];

                        Team team = new Team(currTeamName);

                        teamsByName.Add(currTeamName, team);
                    }
                }
                catch (Exception ex)
                 when (ex is ArgumentException || ex is InvalidOperationException)
                {
                    Console.WriteLine(ex.Message);

                }
            }            
        }
    }
}
