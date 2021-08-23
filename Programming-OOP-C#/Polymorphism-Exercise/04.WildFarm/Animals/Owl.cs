using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals
{
    public class Owl : Bird
    {
        private const double OwlWeightModifier = 0.25;

        private static HashSet<string> owlAllowedFoods = new HashSet<string>() 
        { 
            nameof(Meat) 
        };

        public Owl(string name, 
            double weight,                                  
            double wingSize)
            : base(name, weight, owlAllowedFoods, OwlWeightModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }     
               
    }
}
