using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        //100 Base Health, 50 Base Armor, 40 Ability Points, and a Satchel 
        private const int WarriorBaseHealt = 100;
        private const int WarriorBaseArmor = 50;
        private const int WarriorAbilityPointsr = 40;
        
        public Warrior(string name)
            : base(name, WarriorBaseHealt, WarriorBaseArmor, WarriorAbilityPointsr, new Satchel())        
        {           
        }       

        public void Attack(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            if (character.Name == this.Name)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }


            character.TakeDamage(this.AbilityPoints);
        }
    }
}
