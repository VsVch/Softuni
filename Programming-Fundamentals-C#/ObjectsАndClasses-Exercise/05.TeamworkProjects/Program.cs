using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamCounts = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamCounts; i++) // user and a team
            {
                string[] registration = Console.ReadLine().Split("-");

                string creatorName = registration[0];
                string teamName = registration[1];

                Team team = new Team(creatorName, teamName);

                bool isTeamNameExist = teams
                                            .Select(x => x.TeamName)
                                            .Contains(teamName);

                bool isCreatorNameExist = teams
                                            .Select(x => x.Creator)
                                            .Contains(creatorName);

                if (!isTeamNameExist)
                {
                    if (!isCreatorNameExist)
                    {
                        teams.Add(team);
                        Console.WriteLine($"Team {teamName} has been created by {creatorName} !");
                    }
                    else
                    {
                        Console.WriteLine($"{creatorName} cannot create another team!");
                    }
                }
                else
                {
                    Console.WriteLine($"Team {teamName} was already created!");    
                }

            }

            string input;

            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] command = input.Split("->");

                string newUser = command[0];
                string teamName = command[1];

                bool isTeamExsist = teams.Select(x => x.TeamName).Contains(teamName);

                bool isCreatorExist = teams.Select(x => x.Creator).Contains(newUser);

                bool isMemberExsist = teams.Select(x => x.Members).Any(x => x.Contains(newUser));

                if (!isTeamExsist)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (isCreatorExist || isMemberExsist)
                {
                    Console.WriteLine($"Member {newUser} cannot join team {teamName}!");
                }  
                else
                {
                    int index = teams.FindIndex(x => x.TeamName == teamName);
                    teams[index].Members.Add(newUser);
                }
            }

            Team[] teamToDisband = teams
                                        .OrderBy(x => x.TeamName)
                                        .Where(x => x.Members.Count == 0)
                                        .ToArray();

            Team[] fullTime = teams
                                    .OrderByDescending(x => x.Members.Count)
                                    .ThenBy(x => x.TeamName)
                                    .Where(x => x.Members.Count > 0)
                                    .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (Team team in fullTime)
            {
                sb.AppendLine($"{team.TeamName}");
                sb.AppendLine($"- {team.Creator}");

                foreach (var member in team.Members.OrderBy(x => x))
                {
                    sb.AppendLine($"-- {member}");
                }
            }

            sb.AppendLine($"Teams to disband:");

            foreach (var item in teamToDisband)
            {
                sb.AppendLine(item.TeamName);
            }

            Console.WriteLine(sb.ToString());
        }
    }
    class Team 
    {
        public Team(string creator, string teamName)
        {
            Creator = creator;
            TeamName = teamName;
            Members = new List<string>();
        }

        public string Creator { get; set; }
        public string TeamName { get; set; }
        public List<string> Members { get; set; }
    }
}
