using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Car : ICar
    {
        private const int MinModelValueLenght = 4;

        private string model;
        private int horsePower;
       
        private int minHorsePower;
        private int maxHorsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {            
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;

            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model 
        {
            get => this.model;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinModelValueLenght)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, MinModelValueLenght));
                }
                this.model = value;
            }
        }

        public int HorsePower 
        { 
            get => this.horsePower;
            private set 
            {
                if (value < minHorsePower || value > maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return CubicCentimeters / HorsePower * laps;
        }
    }
}
