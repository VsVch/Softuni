using System;
using System.Collections.Generic;
using System.Text;

using _03.ShoppingSpree.Common;

namespace _03.ShoppingSpree.Models
{
    public class Person
    {
        public const string NOT_ENOUGH_MONE_EXP_MSG = 
            "{0} can't afford {1}";

        public const string SUCC_BOUGHT_PRODUCT_MESS = 
            "{0} bought {1}";

        private string name;
        private decimal money;
        private readonly ICollection<Product> bag;             

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            bag = new List<Product>();
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
        public decimal Money 
        {
            get => this.money;
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstant.NegativeMoneyExcMsg);
                }
                
                this.money = value;
            } 
        }
        
        public IReadOnlyCollection<Product> Bag
        {
            get 
            {
                return (IReadOnlyCollection <Product>) this.bag;
            }
        }

        public string BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                return String.Format
                    (NOT_ENOUGH_MONE_EXP_MSG, this.Name, product.Name);
            }
            this.Money -= product.Cost;
            bag.Add(product);

            return String.Format
                (SUCC_BOUGHT_PRODUCT_MESS, this.Name, product.Name);
            

        }

        public override string ToString()
        {
            string productOutput = this.Bag.Count > 0 ? string.Join(", ", this.Bag) : "Nothing bought";
             
            return $"{this.Name} - {productOutput}";
        }
    }
}
