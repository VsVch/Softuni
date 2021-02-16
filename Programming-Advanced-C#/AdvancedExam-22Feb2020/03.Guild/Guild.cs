using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            roster = new List<Player>(capacity);
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return roster.Count; } }

        public void AddPlayer(Player player)
        {
           
            if (this.roster.Count < this.Capacity)
            {
                roster.Add(player);
            }
        }
        public bool RemovePlayer(string name) 
        {
            bool isExist = false;
            Player currPlayer = roster.FirstOrDefault(p => p.Name == name);

            if (currPlayer != null)
            {
                roster.Remove(currPlayer);
                isExist = true;
                return isExist;
            }
            return isExist;             
        }
        public void PromotePlayer(string name) 
        {
            Player currPlayer = roster.FirstOrDefault(p => p.Name == name);

            if (currPlayer.Rank != "Member")
            {
                currPlayer.Rank = "Member";
            }
           
        }
        public void DemotePlayer(string name)
        {
            Player currPlayer = roster.FirstOrDefault(p => p.Name == name);

            if (currPlayer.Rank != "Trial")
            {
           
                currPlayer.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string guildClass)
        {
            Player[] guildClassArray = this.roster.Where(p => p.Class == guildClass).ToArray();

            this.roster = this.roster.Where(p => p.Class != guildClass).ToList();
            return guildClassArray;
        }

        public string Report() 
        {
            StringBuilder guildInfo = new StringBuilder();
            guildInfo.AppendLine($"Players in the guild: {this.Name}");

            foreach (Player player in roster)
            {
                guildInfo.AppendLine($"Player {player.Name}: {player.Class}");                
                guildInfo.AppendLine($"Rank: {player.Rank}");
                guildInfo.AppendLine($"Description: {player.Description}");
            }           

            return guildInfo.ToString().Trim();
        }
    }
}
