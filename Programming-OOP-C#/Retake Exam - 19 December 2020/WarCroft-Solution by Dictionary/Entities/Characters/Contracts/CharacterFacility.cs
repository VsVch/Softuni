using System;
using System.Collections.Generic;
using System.Text;

namespace WarCroft.Entities.Characters.Contracts
{
    public static class CharacterFacility
    {
        public static Character CharactreCreator(Character character)
        {

            if (character.GetType().Name == nameof(Warrior))
            {
                character = new Warrior(character.Name);
            }
            else if (character.GetType().Name == nameof(Priest))
            {
                character = new Priest(character.Name);
            }

            return character;
        }
    }
}
