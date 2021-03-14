using System;
using System.Linq.Expressions;

namespace _03.FitnessCard
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();
            double cost = 0;
            if (gender == "m")
            {
                
                switch (sport)
                {
                    
                    case "Gym":                        
                        if (age <= 19)
                        {
                            cost += 42 - (42 * 0.2);
                            break;
                        }
                        cost += 42;
                        break;
                    case "Boxing":
                        cost += 41;
                        if (age <= 19)
                        {
                            cost += 41 - (41 * 0.2);
                            break;
                        }
                        cost += 41;
                        break;
                    case "Yoga":                        
                        if (age <= 19)
                        {
                            cost += 45 - (45 * 0.2);
                            break;
                        }
                        cost += 45;
                        break;
                    case "Zumba":                        
                        if (age <= 19)
                        {
                            cost += 34 - (34 * 0.2);
                            break;
                        }
                        cost += 34;
                        break;
                    case "Dances":                        
                        if (age <= 19)
                        {
                            cost += 51 - (51 * 0.2);
                            break;
                        }
                        cost += 51;
                        break;
                    case "Pilates":                        
                        if (age <= 19)
                        {
                            cost += 39 - (39 * 0.2);
                            break;
                        }
                        cost += 39;
                        break;
                }
            }
            else if (gender == "f")
            {
                switch (sport)
                {

                    case "Gym":                        
                        if (age <= 19)
                        {
                            cost += 35 - (35 * 0.2);
                            break;
                        }
                        cost += 35;
                        break;                        
                    case "Boxing":                        
                        if (age <= 19)
                        {
                            cost += 37 - (37 * 0.2);
                            break;
                        }
                        cost += 37;
                        break;
                    case "Yoga":                        
                        if (age <= 19)
                        {
                            cost += 42 - (42 * 0.2);
                            break;
                        }
                        cost += 42;
                        break;
                    case "Zumba":                        
                        if (age <= 19)
                        {
                            cost += 31 - (31 * 0.2);
                            break;
                        }
                        cost += 31;
                        break;
                    case "Dances":
                        
                        if (age <= 19)
                        {
                            cost += 53 - (53 * 0.2);
                            break;
                        }
                        cost += 53;
                        break;
                    case "Pilates":
                        
                        if (age <= 19)
                        {
                            cost += 37 - (37 * 0.2);

                        }
                        cost += 37;
                        break;
                }
            }
            if (sum >= cost)
            {
                
                
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
                
            }
            else
            {
                double moneyNeeded = cost * 1.0 - sum;
                Console.WriteLine($"You don't have enough money! You need ${moneyNeeded:f2} more.");
            }

        }
    }
}
