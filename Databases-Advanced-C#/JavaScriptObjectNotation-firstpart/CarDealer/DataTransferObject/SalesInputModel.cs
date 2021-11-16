using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DataTransferObject
{
    public class SalesInputModel
    {
        public int CarId { get; set; }

        public int CustomerId { get; set; }

        public decimal Discount { get; set; }
    }

}
