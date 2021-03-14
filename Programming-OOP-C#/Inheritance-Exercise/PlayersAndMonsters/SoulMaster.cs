using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class SoulMaster : DarkWizard
    {
        private const int DefoutManaPoint = 150;
        public SoulMaster(string username, int level)
            : base(username, level)
        {
        }

        public override int ManaPoint 
        {
            get
            {
                return DefoutManaPoint;
            }
        }
    }
}