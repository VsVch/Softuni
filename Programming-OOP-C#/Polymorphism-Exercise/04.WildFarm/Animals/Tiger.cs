using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals
{
    public class Tiger : Feline
    {
        private const double TigerWeightModifier = 1.0;

        private static HashSet<string> tigerAllowedFoods = new HashSet<string>()
        {
            nameof(Meat),
            
        };
        public Tiger(string name,
            double weight,           
            string livingRegion,
            string breed)
            : base(name, weight,tigerAllowedFoods, TigerWeightModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }        
    }
}
