using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{

		private List<Character> characters;

		private Stack<Item> items; // stack ???

		public WarController()
		{
			characters = new List<Character>();
			items = new Stack<Item>();
		}

		public string JoinParty(string[] args) // string[] args
		{
			string characterType = args[0];
			string name = args[1];		


			Character character = null;

            if (nameof(Warrior) == characterType)
            {
				character = new Warrior(name);
            }
            else if (nameof(Priest) == characterType)
            {
				character = new Priest(name);
			}
            else
            {
				throw new ArgumentException($"Invalid character type \"{ characterType }\"!");

			}
			characters.Add(character);

			return $"{name} joined the party!";

			// to add in collection ???

		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

			Item item = null;

            if (nameof(HealthPotion) == itemName)
            {
				item = new HealthPotion();
            }
            else if (nameof(FirePotion) == itemName)
            {
				item = new FirePotion();
			}
            else
            {
				throw new ArgumentException($"Invalid item \"{itemName}\"!");
			}
			items.Push(item);		

			// to add in collection ???
			return $"{itemName} added to pool.";
		}

		public string PickUpItem(string[] args) // string[] args
		{
			string characterName = args[0];

			Character character =
				characters.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
				throw new ArgumentException($"Character { characterName } not found!");
            }
            if (items.Count == 0)
            {
				throw new InvalidOperationException("No items left in pool!");
            }

			Item item = items.Pop();
			character.Bag.AddItem(item);		

			return $"{characterName} picked up {item.GetType().Name}!";
		}

		public string UseItem(string [] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character character =
				characters.FirstOrDefault(c => c.Name == characterName);

			if (character == null)
			{
				throw new ArgumentException($"Character { characterName } not found!");
			}

			Item item = character.Bag.GetItem(itemName);	
				
			item.AffectCharacter(character);

			return $"{character.Name} used {itemName}.";
		}

		public string GetStats()
		{
            List<Character> sortedCharacters = characters
                //.Where(c => c.IsAlive)
                .OrderByDescending(c => c.IsAlive)
                .OrderByDescending(c => c.Health)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var character in sortedCharacters)
            {
				string isAlive = "Dead";
                
                if (character.IsAlive)
                {
					isAlive = "Alive";
                }	

				sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {isAlive}");

			}
			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			List<Character> warriors = characters.Where(w => w.GetType().Name == nameof(Warrior)).ToList();

			Warrior attacker = (Warrior)warriors.FirstOrDefault(c => c.Name == attackerName);
			Character receiver = characters.FirstOrDefault(c => c.Name == receiverName);

			if (attacker == null) // error ???
			{
				throw new ArgumentException($"Character {attackerName} not found!");
			}

			if (receiver == null)  // error ???
			{
				throw new ArgumentException($"Character {receiverName} not found!");
			}

			if (attacker.GetType().Name == nameof(Priest))
			{
				throw new ArgumentException($"{attacker.Name} cannot attack!");
			}

			attacker.Attack(receiver);
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

			if (!receiver.IsAlive)
			{
				sb.AppendLine($"{receiver.Name} is dead!");
			}

			return sb.ToString().TrimEnd();
		}

		public string Heal(string [] args)
		{
			string healerName = args[0];
			string receiverName = args[1];

			Character healer = characters.FirstOrDefault(c => c.Name == healerName);
			Character receiver = characters.FirstOrDefault(c => c.Name == receiverName);

			if ( healerName == null) // error ???
			{
				throw new ArgumentException($"Character {healerName} not found!");
			}

			if (receiverName == null)  // error ???
			{
				throw new ArgumentException($"Character {receiverName} not found!");
			}	

			if (healer.GetType().Name == nameof(Warrior))
			{
				throw new ArgumentException($"{healer.Name} cannot heal!");
			}

			receiver.Health += healer.AbilityPoints;

			return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
		}
	}

    
}
