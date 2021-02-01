using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Shirt
    {
        //private string size;
        //private decimal price;
        //private int quantity;

        public string Size { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public void Wash()
        {
            Console.WriteLine("Tshirt was dirty now is clean :) MR proper");
        
        }
    }
}
