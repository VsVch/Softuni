using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class DarkKnight : Knight
    {
        public const string GrandSword = "TwoHandGrandSword";
        public DarkKnight(string username, int level) 
            : base(username, level, GrandSword, GrandSword)
        {
        }
    }
}