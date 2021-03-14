using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.RawData
{
    public class Car
    {
        private string model;

        private Engine engine;

        private Cargo cargo;

        private Tire[] tires;

        public Car(string model, int engineSpeed, 
            int enginePower, int cargoWeight, 
            string cargoType, 
            double tire1Pressure, int tire1Age, 
            double tire2Pressure, int tire2Age,
            double tire3Pressure, int tire3Age,
            double tire4Pressure, int tire4Age)
        {
            this.Model = model;
            this.Engine = new Engine(engineSpeed, enginePower);
            this.Cargo = new Cargo(cargoWeight, cargoType);
            this.Tires = new Tire[]
            {
                new Tire(tire1Pressure, tire1Age),
                new Tire(tire2Pressure, tire2Age),
                new Tire(tire3Pressure, tire3Age),
                new Tire(tire4Pressure, tire4Age),              
            };
           

        }
        public string Model { get; set; }
        
        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tire[] Tires { get; set; }




    }
}
