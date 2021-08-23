using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character 
    {
		// TODO: Implement the rest of the class.
		private string name;
		private double baseHealt;
		private double healt;
		private double baseArmor;
		private double armor;

		// string name, double health, double armor, double abilityPoints, Bag bag
		public Character(string name, double baseHealt, double baseArmor, double abilityPoints, Bag bag)
        {
			this.Name = name;
			this.BaseHealth = baseHealt;			
			this.BaseArmor = baseArmor;
			this.Health = baseHealt;
			this.Armor = baseArmor;
			this.AbilityPoints = abilityPoints;
            this.Bag = bag;
			this.IsAlive = true;	
        }

		public string Name 
		{
			get => this.name;
			set 
			{
                if (string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException("Name cannot be null or whitespace!");
                }
				this.name = value;
			}
		}

		//TODO max healt
        public double BaseHealth { get;private set; }
		
		public double Health 
		{
			get => this.healt;
		    set
			{
                if (value <= 0)
                {
					IsAlive = false;
					value = 0;
                }
                if (value > this.BaseHealth)
                {
					value = baseHealt;
                }
				this.healt = value;
			}

		}

        public double BaseArmor { get; private set; }

        public double Armor 
		{
			get => this.armor;
			set 
			{
                if (value < 0)
                {
					value = 0;                
				}

				this.armor = value;
			}
	    }

        public double AbilityPoints  { get; private set; }

		public Bag Bag { get; set; }

		public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
		public void TakeDamage(double hitPoints)
		{
			
            if (!this.IsAlive)
            {
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
				// dead messege
			}
			double actualArmorPoint = this.Armor;

			this.Armor -= hitPoints;

			if (this.Armor <= 0)
			{
                this.Health -= hitPoints - actualArmorPoint;
				this.Armor = 0;

				if (this.Health <= 0)
				{
					IsAlive = false;
				}
			}		
			
		}
		public void UseItem(Item item) 
		{
			if (!this.IsAlive)
			{
				// dead messege
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}            
		}		
       
    }
}