using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double BusAirConditionsConsumption = 1.4;
        public Bus(double fuel, double tankCapacity, double fuelConsumption ) 
            : base(  fuel, tankCapacity, fuelConsumption, BusAirConditionsConsumption, 1.0)
        {
        }

        public void AirConditionsOff() 
        {
            AirConditionsConsumption = 0;
        }
    }
}
