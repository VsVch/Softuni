using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals
{
    public class Mouse : Mammal
    {
        public const double MouseWeightModifier = 0.1;

        private static HashSet<string> mouseAllowedFoods = new HashSet<string>()
        {          
            nameof(Vegetable),
            nameof(Fruit)            
        };

        public Mouse(string name, 
            double weight,                       
            string livingRegion) 
            : base(name, weight, mouseAllowedFoods, MouseWeightModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }        
    }
}
