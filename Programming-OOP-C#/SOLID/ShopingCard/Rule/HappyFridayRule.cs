using ShopingCard.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopingCard.Rule
{
    class HappyFridayRule : IPriceRule
    {
        public decimal CalculatePrice(OrderItem item)
        {
            return item.Price / 2;
        }

        public bool IsMuch(OrderItem item)
        {
            return item.Sku.StartsWith("HappyFridayRule");
        }
    }
}
