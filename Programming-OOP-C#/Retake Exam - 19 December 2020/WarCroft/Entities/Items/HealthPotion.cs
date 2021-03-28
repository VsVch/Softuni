using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int HealtPotionWeight = 5;
        private const int HealtpotionEffect = 20;
        public HealthPotion()
            : base(HealtPotionWeight)
        {
        }

        public override void AffectCharacter(Character character) 
        {
           character.Health += HealtpotionEffect;
            
        }
    }
}
