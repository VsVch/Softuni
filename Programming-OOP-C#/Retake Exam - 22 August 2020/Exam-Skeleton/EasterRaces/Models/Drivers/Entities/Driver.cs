using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using System;

namespace EasterRaces.Models.Drivers
{
    public class Driver : IDriver
    {
        private string name;

        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }

                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; } = false;

        public void AddCar(ICar car)
        {            

            if (car.GetType().Name is nameof(Sports))
            {
                car = new Sports(car.Model, car.HorsePower);
            }
            else if (car.GetType().Name is nameof(Muscle))
            {
                car = new Muscle(car.Model, car.HorsePower);
            }
            else if (car == null)
            {
                throw new ArgumentNullException("Car cannot be null.");
            }
            CanParticipate = true;
            this.Car = car;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
