using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StoreBoxes
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Box> listOfBoxes = new List<Box>();

			while (true)
			{
				string[] input = Console.ReadLine()// {Serial Number} {Item Name} {Item Quantity} {itemPrice}
					.Split(" ", StringSplitOptions.RemoveEmptyEntries)
					.ToArray();

				string serialNumber = input[0];
				string itemName = input[1];
				int itemQuantlity = int.Parse(input[2]);
				double itemPrice = double.Parse(input[3]);

				BoxId(serialNumber, itemName);
				BoxPrice(itemQuantlity, itemPrice);
			}  

		}

        private static string BoxId(string serialNumber, string itemName)
        {
            return (serialNumber, itemName);

		}

        private static double BoxPrice( int itemQuantlity, double itemPrice)
        {
			double boxPrice = 1.0 * itemQuantlity * itemPrice;

			return boxPrice;

		}
    }
	class Item // Name and Price.
	{
		public string Name { get; set; }

		public double Price { get; set; }
	}
	class Box // Serial Number, Item, Item Quantity and Price for a Box
	{

		//public Box()
	    //   {
		//	Item = new Item();
       //      }
		public string SerialNumber { get; set; }

		public string Item { get; set; }

		public string ItemQuantlity { get; set; }

		public double PriceForABox { get; set; }
	}
}
