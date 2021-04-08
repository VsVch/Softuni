using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character : IAttacker, IHealer
    {
		private string name;
		private double health;
		private double armor;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
			this.Name = name;
			this.BaseHealth = health;
			this.Health = health;
			this.BaseArmor = armor;
			this.Armor = armor;
			this.AbilityPoints = abilityPoints;
			this.Bag = bag;

        }

        public string Name 
		{
			get => this.name;
			private set 
			{
                if (string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
				}
				this.name = value;
			}
		}

        public double BaseHealth { get; private set; }

        public double Health 
		{
		   get => this.health;
		   internal set 
			{
                if (value > BaseHealth)
                {
					value = BaseHealth;
                }
                if (value < 0)
                {
					value = 0;
                }

				this.health = value;
			}
		}

        public double BaseArmor { get;private set; }

        public double Armor 
		{
			get => this.armor;
			private set 
			{
                if (value < 0)
                {
					value = 0;
                }

				this.armor = value;
			} 
		}

        public double AbilityPoints { get;private set; }

		public Bag Bag { get;private set;}

		public bool IsAlive { get; set; } = true;

		public void TakeDamage(double hitPoints) 
		{
			this.EnsureAlive();

			double curArmor = Armor;
			this.Armor -= hitPoints;

            if (Armor <= 0)
            {
				this.Health -= hitPoints - curArmor;

                if (Health <= 0)
                {
					IsAlive = false;
                }
            }

		}

		public void UseItem(Item item) // check item ??/
		{

			this.EnsureAlive();

			item.AffectCharacter(this);
		}

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

		public virtual void Attack(Character character) { }

		public virtual void Heal(Character character) { }

		public override string ToString()
        {
			return string.Format(SuccessMessages.CharacterStats, Name, Health, BaseHealth, Armor, BaseArmor, IsAlive == true ? "Alive" : "Dead");
        }

		
        
    }
}