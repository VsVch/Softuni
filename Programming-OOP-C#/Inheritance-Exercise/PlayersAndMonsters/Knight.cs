using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Knight : Hero
    {

        public Knight(string username, int level, string sword, string sheld) 
            : base(username, level)
        {
            this.Sword = sword;
            this.Sheld = sheld;
        }

        public string Sword { get; set; }

        public string Sheld { get; set; }


    }
}