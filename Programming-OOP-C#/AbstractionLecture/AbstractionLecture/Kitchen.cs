using AbstractionLecture.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractionLecture
{
    public class Kitchen : IOrdereble, IMachinery, ICostCalculatable
    {
        public List<string> Machineries { get; set; }
        public List<string> machines { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void CalculateCost()
        {
            throw new NotImplementedException();
        }
        public void ListAllMachines()
        {
            throw new NotImplementedException();
        }

        public void Order(string name)
        {
            throw new NotImplementedException();
        }

        public void OrderMeal(string mealName) 
        {
            Console.WriteLine($"Meal ordered {mealName}");        
        }

        public void AddProduct(string product) 
        {
            Console.WriteLine($"Product added {product}");        
        }

        public void CalcolateCost() 
        {
            Console.WriteLine("Current cost is: Too much");
        
        }

        public void ListAllMachineries() 
        {
            foreach (var item in Machineries)
            {
                Console.WriteLine($"machine: {item}");
            }
        
        }

        
    }
}
