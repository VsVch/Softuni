using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const int PriestBaseHealt = 50;
        private const int PriestBaseArmor = 25;
        private const int PriestAbilityPointsr = 40;
        
// 50 BaseHealth, 25 Base Armor, 40 Ability Points, and a Backpack
        public Priest(string name)
            : base(name, PriestBaseHealt, PriestBaseArmor, PriestAbilityPointsr, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            if (!character.IsAlive)
            {
                throw new ArgumentException(ExceptionMessages.AffectedCharacterDead);
            }
            if (!this.IsAlive)
            {
                throw new ArgumentException(ExceptionMessages.AffectedCharacterDead);
            }

            character.Health += this.AbilityPoints;
        }
    }
}
