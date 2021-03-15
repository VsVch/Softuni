using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelWaste;    
        private double tankCapacity;

        public Vehicle
            (double fuel, 
            double tankCapacity,  
            double fuelConsumption, 
            double airConditionsConsumption,
            double fuelWaste)
        {
            this.Fuel = fuel;
            this.TankCapacity = tankCapacity;            
            this.FuelConsumption = fuelConsumption;            
            this.AirConditionsConsumption = airConditionsConsumption;
            this.fuelWaste = fuelWaste;
        }

        public double TankCapacity 
        {
            get => this.tankCapacity;
            private set 
            {
                double currFuel = this.Fuel;

                if (value < currFuel)
                {
                    this.Fuel = 0;

                    throw new ArgumentException($"Cannot fit {currFuel} fuel in the tank");
                }
                this.tankCapacity = value;
            }
        }
        public double Fuel { get; private set; }

        public double FuelConsumption { get; private set; }

        protected double AirConditionsConsumption { get; set; }

        public virtual string Drive(double distance) 
        {
            double neededFuel = (FuelConsumption + AirConditionsConsumption) * distance;

            if (neededFuel >= this.Fuel)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }
            this.Fuel -= neededFuel;
            return $"{GetType().Name} travelled {distance} km";        
        }

        public virtual void Refuel(double fuel) 
        {          
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (fuel + this.Fuel > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }
            this.Fuel += fuel * fuelWaste;

            
        }
    }
}
