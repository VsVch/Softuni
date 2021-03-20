using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals
{
    public class Hen : Bird
    {
        private const double HenWeightModifier = 0.35;

        private static HashSet<string> henAllowedFoods = new HashSet<string>()
        {
            nameof(Meat),
            nameof(Vegetable),
            nameof(Fruit),
            nameof(Seeds)
        };

        public Hen(string name,
            double weight,                     
            double wingSize)
            : base(name, weight, henAllowedFoods, HenWeightModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }      
                
    }
}
