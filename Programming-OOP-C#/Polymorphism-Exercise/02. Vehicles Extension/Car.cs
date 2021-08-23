using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double CarAirConditionsConsumption = 0.9;
        public Car(double fuel, double tankCapacity, double fuelConsumption)
            : base(fuel, tankCapacity, fuelConsumption, CarAirConditionsConsumption, 1.0)
        {
        }

    }
}
