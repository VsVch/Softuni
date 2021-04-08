using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Inventory.Contracts;

namespace WarCroft.Entities.Characters.Contracts
{
    public class Warrior : Character, IAttacker
    {
        private const double WarriorHealth = 100;
        private const double WarriorArmor = 50;
        private const double WarriorAbilityPoints = 40;

        public Warrior(string name)
            : base(name, WarriorHealth, WarriorArmor, WarriorAbilityPoints, new Satchel())
        {
        }

        public override void Attack(Character character)
        { 
            this.EnsureAlive();                
            
            if (this.Name == character.Name)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
