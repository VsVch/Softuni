using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private const int minLenght = 1;
        private const int maxLenght = 15;

        private const int MaxToppingsCount = 10;

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            toppings = new List<Topping>();
        }

        public string Name 
        {
            get => this.name;
            private set 
            {
                if (value.Length < minLenght || value.Length > maxLenght)
                {
                    throw new ArgumentException($"Pizza name should be between {minLenght} {maxLenght} symbols.");
                }
                this.name = value;
            }
        }
        public void AddTopping(Topping topping) 
        {         
            if (toppings.Count == MaxToppingsCount)
            {
                throw new InvalidOperationException
                    ($"Number of toppings should be in range [0..{MaxToppingsCount}].");
            }

            this.toppings.Add(topping);
        }

        public double GetCalories()
        {
            return this.dough.GetCalories() + this.toppings.Sum(t => t.GetCalories());
        
        }
    }
}
