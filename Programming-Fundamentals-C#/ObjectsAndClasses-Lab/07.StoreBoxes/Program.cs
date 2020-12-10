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

			string input;

			while ((input = Console.ReadLine()) != "end")
			{
				string[] command = input
					.Split(" ", StringSplitOptions.RemoveEmptyEntries)
					.ToArray();

				string serialNumber = command[0];
				string itemName = command[1];
				int itemQuantlity = int.Parse(command[2]);
				double itemPrice = double.Parse(command[3]);

				

				Box box = new Box
				{
					SerialNumber = serialNumber,
					Item = itemName,
					ItemQuantlity = itemQuantlity,
				    PriceForABox = itemPrice,
					TotallPrice = BoxPrice(itemQuantlity, itemPrice),

				};

				listOfBoxes.Add(box);
			}

            foreach (var item in listOfBoxes.OrderByDescending(p => p.TotallPrice))
            {
                Console.WriteLine($"{item.SerialNumber}");
                Console.WriteLine($"-- {item.Item} - ${item.PriceForABox:f2}: {item.ItemQuantlity}");
                Console.WriteLine($"-- ${item.TotallPrice:f2}");
            }


		}        

        private static double BoxPrice( int itemQuantlity, double itemPrice)
        {
			double boxPrice = 1.0 * itemQuantlity * itemPrice;

			return boxPrice;

		}
    }	
	class Box // Serial Number, Item, Item Quantity and Price for a Box
	{		
		public string SerialNumber { get; set; }

		public string Item { get; set; }

		public int ItemQuantlity { get; set; }

		public double PriceForABox { get; set; }

		public double TotallPrice { get; set; }
	}
}
