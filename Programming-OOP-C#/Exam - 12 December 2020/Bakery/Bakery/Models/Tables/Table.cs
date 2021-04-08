using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;    
            

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }        

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price 
        { 
            get
            {
                return NumberOfPeople * PricePerPerson;
            } 
        }

        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            numberOfPeople = 0;
            IsReserved = false;
            
        }

        public decimal GetBill()
        {
            decimal price = 0;

            foreach (var item in foodOrders)
            {
                price += item.Price;
            }
            foreach (var item in drinkOrders)
            {
                price += item.Price;
            }
            //decimal foodCost = foodOrders.Select(f => f.Price).Sum();
            //decimal drinkCost = drinkOrders.Select(f => f.Price).Sum();

            return price;
        }

        public string GetFreeTableInfo()
        {
            return $"Table: {this.TableNumber}\r\n" +
                $"Type: {this.GetType().Name}\r\n" +
                $"Capacity: {this.Capacity}\r\n" +
                $"Price per Person: {this.PricePerPerson:f2}";           
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            this.numberOfPeople = numberOfPeople;   
        }
    }
}
