using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class  Car
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public void  Drive( double distance)
        {
            bool isEnougFuel = true;
            double fuelToConsum = FuelConsumption * distance;

            if (FuelQuantity - fuelToConsum >= 0)
            {
                FuelQuantity -= fuelToConsum;
            }
            else if (true)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        
        }
        public string WhoAmI() 
        {
            return $"Make: {this.Make}    " +
                $"Model: {this.Model}    " +
                $"Year: {this.Year}    " +
                $"Fuel: {this.FuelQuantity:f2}L";
        
        }
    }
}
