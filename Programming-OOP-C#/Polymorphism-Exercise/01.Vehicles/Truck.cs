using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double TruckAirConditionConsumption = 1.6;
        public Truck(double fuel, double fuelConsumption) 
            : base(fuel, fuelConsumption, TruckAirConditionConsumption)
        {
        }

        public override void Refuel(double extraFuel)
        {
            base.Refuel(extraFuel * 0.95);
        }        
    }
}
