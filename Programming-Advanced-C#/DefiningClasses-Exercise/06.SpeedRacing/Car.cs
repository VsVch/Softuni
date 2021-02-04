using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
     
    public class Car
    {
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public bool Drive( double amountOfKm) 
        {
           
            double neededFuel = this.FuelConsumptionPerKilometer * amountOfKm;

            if (neededFuel <= this.FuelAmount) //? error
            {
                FuelAmount -= neededFuel;
                TravelledDistance += amountOfKm;
                return true;
            }
            return false;
        }
    }
}
