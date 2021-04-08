using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Inventory.Contracts;

namespace WarCroft.Entities.Characters.Contracts
{
    public class Priest : Character, IHealer
    {

        private const double PriestHealth = 50;
        private const double PriestArmor = 25;
        private const double PriestAbilityPoints = 40;

        public Priest(string name)
            : base(name, PriestHealth, PriestArmor, PriestAbilityPoints, new Backpack())
        {
        }

        public override void Heal(Character character)
        {
            this.EnsureAlive();
            
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            character.Health += this.AbilityPoints;
        }
    }
}
