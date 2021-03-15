using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double TruckFuelWaste = 0.95;
        private const double TruckAirConditionsConsumption = 1.6;
        public Truck(double fuel, double tankCapacity, double fuelConsumption)
           : base(fuel, tankCapacity, fuelConsumption, TruckAirConditionsConsumption, TruckFuelWaste)
        {
        }

        public override void Refuel(double fuel)
        {
            
            base.Refuel(fuel);
        }
    }
}
