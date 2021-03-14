using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Wizard : Hero
    {
        private const int manapoint = 100;

        public Wizard(string username, int level)
            : base(username, level)
        {

        }
        public virtual int ManaPoint 
        {
            get
            {
                return manapoint;
            }
        }

    }
}