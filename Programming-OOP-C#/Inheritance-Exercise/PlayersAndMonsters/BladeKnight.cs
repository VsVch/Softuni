using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class BladeKnight : DarkKnight
    {
        public BladeKnight(string username, int level, string leftBlade, string rightBlade)
            : base(username, level)
        {
            this.LeftBlade = leftBlade;
            this.RightBlade = rightBlade;
        }

        public string LeftBlade { get; set; }

        public string RightBlade { get; set; }
    }
}