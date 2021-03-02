using System;
using System.Collections.Generic;

using _03.ShoppingSpree.Common;

namespace _03.ShoppingSpree.Models
{
    public class Product
    {
        private string name;
        private decimal cost;
      


        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;            
        }

        public string Name 
        {
            get => this.name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstant.EmptyNameExpMsg);
                }
                this.name = value;
            }             
        }

        public decimal Cost 
        {
            get => this.cost;
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstant.NegativeMoneyExcMsg);
                }
                this.cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name; 
        }

    }
}
