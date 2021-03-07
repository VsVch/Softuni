using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class DarkWizard : Wizard
    {
        private const int CurrentManaPoints = 120;
        public DarkWizard(string username, int level)
            : base(username, level)
        {

        }

        public override int ManaPoint 
        { 
            get 
            {
                return CurrentManaPoints;
            }
        }
    }
}