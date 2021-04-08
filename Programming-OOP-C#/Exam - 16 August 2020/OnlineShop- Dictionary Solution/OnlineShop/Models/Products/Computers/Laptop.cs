using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public class Laptop : Computer
    { 
        private const double LaptopPerformance = 10;

        private decimal price;
        public Laptop(int id, string manufacturer, string model, decimal price)
            : base(id, manufacturer, model, price, LaptopPerformance)
        {
            this.price = price;
        }

        public override double OverallPerformance => base.OverallPerformance + LaptopPerformance;

        public override decimal Price => base.Price + price;
    }
}
