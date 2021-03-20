using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals
{
    public class Dog : Mammal
    {
        public const double DogWeightModifier = 0.4;

        private static HashSet<string> dogAllowedFoods = new HashSet<string>()
        {
            nameof(Meat)            
        };

        public Dog(string name,
            double weight,            
            string livingRegion)
            : base(name, weight,dogAllowedFoods, DogWeightModifier, livingRegion)
        {
        }       

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
