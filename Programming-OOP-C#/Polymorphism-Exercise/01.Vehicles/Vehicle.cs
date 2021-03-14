using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuel, double fuelConsumption,  double airConditionConsumption)
        {
            this.Fuel = fuel;
            this.FuelConsumption = fuelConsumption;
            this.AirConditionConsumption = airConditionConsumption;
        }
        public double Fuel { get; set; }

        public double FuelConsumption { get; set; }

        public double AirConditionConsumption { get; set; }
              
        public string Drive(double distance) 
        {
            double neededFuel = distance * (FuelConsumption + AirConditionConsumption);

            if (neededFuel > this.Fuel)
            {
                return $"{GetType().Name} needs refueling";
            }
            this.Fuel -= neededFuel;
            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double extraFuel) 
        {
            this.Fuel += extraFuel;        
        }

    }
}
