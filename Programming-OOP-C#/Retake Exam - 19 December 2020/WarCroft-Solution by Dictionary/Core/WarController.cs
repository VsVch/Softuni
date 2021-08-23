using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private readonly Dictionary<string, Character> partyByName;
		private readonly Stack<Item> pool;

		public WarController()
		{
			partyByName = new Dictionary<string, Character>();
			pool = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			Character character = null;

			string characterType = args[0];
			string name = args[1];

            if (characterType == "Warrior")
            {
				character = new Warrior(name);
            }
            else if (characterType == "Priest")
            {
				character = new Priest(name);
            }
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
			}

			partyByName.Add(name, character);

			return string.Format(SuccessMessages.JoinParty, name);			 

		}

		public string AddItemToPool(string[] args)
		{
			Item item = null;

			string itemName = args[0];

            if (itemName == "HealthPotion")
            {
				item = new HealthPotion();
            }
		    else if (itemName == "FirePotion")
			{
				item = new FirePotion();
			}
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
			}

			pool.Push(item);

			return string.Format(SuccessMessages.AddItemToPool,itemName);

		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];

			Character character = GetCharacter(characterName);

			if (pool.Count == 0)
			{
				throw new InvalidOperationException(string.Format(ExceptionMessages.ItemPoolEmpty));
			}

			Item item = pool.Pop();		
			           
			string itemName = item.GetType().Name;

			character.Bag.AddItem(item);

			return string.Format(SuccessMessages.PickUpItem,characterName, itemName);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character character = GetCharacter(characterName);

			Item item = character.Bag.GetItem(itemName);

			item.AffectCharacter(character);

			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			IDictionary<string, Character> partyByNameSorted =
				partyByName.OrderByDescending(p => p.Value.IsAlive == true).
				OrderByDescending(p => p.Value.Health).ToDictionary(k => k.Key, v => v.Value);

			StringBuilder sb = new StringBuilder();

            foreach (var character in partyByNameSorted)
            {
				sb.AppendLine(character.Value.ToString());
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string reciverName = args[1];

			Character attacker = GetCharacter(attackerName);
			Character reciver = GetCharacter(reciverName);

			if (attacker.GetType().Name == nameof(Priest))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
			}

			attacker.Attack(reciver);

			StringBuilder sb = new StringBuilder();

			sb.AppendLine(string.Format(SuccessMessages.AttackCharacter,
				attackerName,reciverName, attacker.AbilityPoints,
				reciverName, reciver.Health,reciver.BaseHealth,
				reciver.Armor,reciver.BaseArmor));

            if (reciver.Health <= 0)
            {
				reciver.IsAlive = false;
				sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter,reciverName));
            }

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string reciverName = args[1];

			Character healer = GetCharacter(healerName);
			Character reciver = GetCharacter(reciverName);

            if (healer.GetType().Name == nameof(Warrior))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
			}

			healer.Heal(reciver);

			return string.Format(SuccessMessages.HealCharacter,healerName,reciverName,healer.AbilityPoints,reciverName,reciver.Health);			
		}

		public Character GetCharacter(string name) 
		{
			Character character = null;

            foreach (var item in partyByName)
            {
                if (item.Key == name)
                {
					character = partyByName[name]; 
                }
            }

			if (character == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, name));
			}

			return character;
		}
	}
}
