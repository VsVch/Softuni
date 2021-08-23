using System;
using System.Collections.Generic;
using System.Text;

namespace ShopingCard.Contracts
{
    public interface IPriceRule
    {
        decimal CalculatePrice(OrderItem item);

        bool IsMuch(OrderItem item);
    }
}
