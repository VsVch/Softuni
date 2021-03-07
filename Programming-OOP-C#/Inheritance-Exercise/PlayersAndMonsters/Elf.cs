using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Elf : Hero
    {
        public Elf(string username, int level, string bow) 
            : base(username, level)
        {
            this.Bow = bow;
        }

        public string Bow { get; set; }
    }
}