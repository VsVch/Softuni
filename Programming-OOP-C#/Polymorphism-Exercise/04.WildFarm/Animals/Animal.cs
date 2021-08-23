using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals
{
    public abstract class Animal
    {

        public Animal(string name, 
            double weight,            
            HashSet<string> allowedFoods,
            double weightModifier)
        {
            this.Name = name;
            this.Weight = weight;           
            this.AllowedFoods = allowedFoods;
            this.WeightModifier = weightModifier;
        }

        private HashSet<string> AllowedFoods { get; set; }

        public double WeightModifier { get; set; }

        public string Name { get; private set; }

        public double Weight { get; private set; }
        
        public int FoodEaten { get; private set; }

        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            string foodType = food.GetType().Name;
            if (!AllowedFoods.Contains(foodType))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {foodType}!");
            }
            this.FoodEaten += food.Quantity;

            this.Weight += this.WeightModifier * food.Quantity;
        }




        


    }
}
