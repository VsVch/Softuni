using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.WildFarm.Animals
{
    public class Cat : Feline
    {
        private const double CatWeightModifier = 0.3;

        private static HashSet<string> catAllowedFoods = new HashSet<string>()
        {
            nameof(Meat),
            nameof(Vegetable),
        };
        public Cat(string name, 
            double weight,                        
            string livingRegion, 
            string breed)
            : base(name, weight,catAllowedFoods, CatWeightModifier, livingRegion, breed)
        {
        }
        public override string ProduceSound()
        {
            return "Meow";
        }        

    }
}
