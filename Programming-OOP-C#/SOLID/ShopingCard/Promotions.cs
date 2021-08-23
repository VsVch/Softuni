using ShopingCard.Contracts;
using ShopingCard.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopingCard
{
    public class PriceCalculator
    {
        private readonly List<IPriceRule> promotionRules =
           new List<IPriceRule>()
           {
                new HappyFridayRule(),
                new SpecialRule(),
                new BlackFridayRule(),
           };

        public decimal CalculatePrice(OrderItem item)
        {
            decimal total = 0;

            var promotionRule = promotionRules
                   .FirstOrDefault(r => r.IsMuch(item));

            if (promotionRule == null)
            {
                total += item.Price;
            }
            else
            {
                total += promotionRule.CalculatePrice(item);
            }

            return total;
        }
    }
}
