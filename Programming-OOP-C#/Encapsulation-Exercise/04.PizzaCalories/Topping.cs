using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const int MinToppingWeight = 1;
        private const int MaxToppingWeight = 50;

        private string name;
        private int weight;

        public Topping(string name, int weight)
        {
            this.Name = name;
            this.Weight = weight;
        }    

        public string Name 
        {
            get => this.name;
            private set
            {
                var nameToLower = value.ToLower();

                if (nameToLower != "meat" &&
                    nameToLower != "veggies" &&
                    nameToLower != "cheese" &&
                    nameToLower != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.name = value;
            }
        }

        public int Weight 
        {
            get => this.weight;
            private set 
            {
                if (value < MinToppingWeight || value > MaxToppingWeight)
                {
                    throw new ArgumentException($"Number of toppings should be in range [{MinToppingWeight}..{MaxToppingWeight}].");
                }                
                this.weight = value;
            
            }
        }
        public double GetCalories() 
        {
            double modifier = GetModifier();

            double toppingsCalories = modifier * 2 * this.Weight;
             
            return toppingsCalories;
        }
       
        private double GetModifier()
        {
            var nameToLower = name.ToLower();

            if (nameToLower == "meat")
            {
                return 1.2;
            }
            else if (nameToLower == "veggies")
            {
                return 0.8;
            }
            else if (nameToLower == "cheese")
            {
                return 1.1;
            }
            return 0.9;
        }
    }
}
