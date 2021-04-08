using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public class DesktopComputer : Computer
    {

        private const double DesktopComputerPerformance = 15;

        private decimal price;
        public DesktopComputer(int id, string manufacturer, string model, decimal price)
            : base(id, manufacturer, model, price, DesktopComputerPerformance)
        {
            this.price = price;
        }

        public override double OverallPerformance => base.OverallPerformance + DesktopComputerPerformance;

        public override decimal Price => base.Price + price;
    }
}
