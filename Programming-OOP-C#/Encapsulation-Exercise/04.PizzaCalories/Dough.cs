using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {

        private const string InvalidDoughExceptionMessege = "Invalid type of dough.";
        private const int MinDoughWeight = 1;
        private const int MaxDoughWeight = 200;
        private const int CaloriesPerGramDought = 2;

        private const double CaloriesWhite = 1.5;
        private const double CaloriesWholegrain = 1.0;
        private const double CaloriesCrispy = 0.9;
        private const double CaloriesChewy = 1.1;
        private const double CaloriesHomemade = 1.0;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType 
        {
            get => this.flourType;
            private set 
            {
                var nameToLower = value.ToLower();

                if (nameToLower != "white"&&
                nameToLower != "wholegrain")
                {
                    throw new ArgumentException(InvalidDoughExceptionMessege);
                }
                this.flourType = value;
            }
        }

        public string BakingTechnique 
        {
            get => this.bakingTechnique;
            private set 
            {
                var nameToLower = value.ToLower();

                if (nameToLower != "crispy" &&
                nameToLower != "chewy" &&
                nameToLower != "homemade")
                {
                    throw new ArgumentException(InvalidDoughExceptionMessege);
                }
                this.bakingTechnique = value;
            }
        }

        public int Weight 
        {
            get => this.weight;
            private set 
            {
                if (value < MinDoughWeight || value > MaxDoughWeight)
                {
                    throw new ArgumentException($"Number of toppings should be in range [{MinDoughWeight}..{MaxDoughWeight}].");
                }
                this.weight = value;
            }
        }
        public double GetCalories()
        {
            double flourTypeModifier = GetFlourTypeModifier();
            double bakingTechniqueModifier = GetBakingTechniqueModifier();
            double doughCalories = 
                CaloriesPerGramDought * 
                this.Weight * 
                flourTypeModifier * 
                bakingTechniqueModifier;

            return doughCalories;
        }

        private double GetBakingTechniqueModifier()
        {
            if (bakingTechnique.ToLower() == "crispy")
            {
                return CaloriesCrispy;
            }
            else if (bakingTechnique.ToLower() == "chewy") 
            {
                return CaloriesChewy;
            }
            return CaloriesHomemade;
        }

        private double GetFlourTypeModifier()
        {
            if (this.flourType.ToLower() == "white")
            {
                return CaloriesWhite;
            }
            return CaloriesWholegrain;
        }        
    }
}
