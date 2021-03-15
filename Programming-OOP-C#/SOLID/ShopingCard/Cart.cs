using ShopingCard.Contracts;
using ShopingCard.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopingCard
{
    public class Cart
    {
        private readonly List<OrderItem> items;
        private readonly PriceCalculator pricecalculator =
            new PriceCalculator();
        public Cart()
        {
            this.items = new List<OrderItem>();
        }

        public IEnumerable<OrderItem> Items 
        {
            get { return new List<OrderItem>(this.items); }
        }

        public string CustomerEmail { get; set; }

        public void Add (OrderItem orderItem)
        {
            this.items.Add(orderItem);
        }
        public decimal TotalAmound() 
        {
            decimal total = 0;

            foreach (var item in this.items)
            {
                total += pricecalculator.CalculatePrice(item);
            }

            return total;
        
        }
    }
}
