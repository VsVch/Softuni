using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;        
        private Dictionary<string, Player> playersByName;

        public Team(string name)
        {
            this.Name = name;
            playersByName = new Dictionary<string, Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.NameValidation
                    (value, GlobalConstants.InvalideNameExeptionsMessege);
                this.name = value;
            }
        }

        public double Rating
        {
            get
            {
                if (playersByName.Count <= 0)
                {
                    return 0;
                }
                return this.playersByName
                    .Values
                    .Average(p => p.AveragePlayerSkillLevel);
            }                

        }
        public void AddPlayer(Player player)
        {
            this.playersByName.Add(player.Name, player);        
        }

        public void RemovePlayer(string playerName)
        {
            if (!this.playersByName.ContainsKey(playerName))
            {
                throw new InvalidOperationException($"Player {playerName} is not in {this.Name} team.");
            }     
            
            playersByName.Remove(playerName);
        }

        
    }
}
