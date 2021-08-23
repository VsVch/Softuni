using ShopingCard.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopingCard.Rule
{
    public class BlackFridayRule : IPriceRule
    {
        public decimal CalculatePrice(OrderItem item)
        {
            return item.Price / 50 * 100;
        }

        public bool IsMuch(OrderItem item)
        {
            return item.Sku.StartsWith("BlackFriday");
        }
    }
}
