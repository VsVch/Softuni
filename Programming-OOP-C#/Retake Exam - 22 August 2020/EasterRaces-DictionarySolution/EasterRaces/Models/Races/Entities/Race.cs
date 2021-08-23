using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int MinNameValueLenght = 5;
        private const int minLaps = 1;

        private string name;
        private int laps;

        private readonly IDictionary<string, IDriver> driverByName;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            driverByName = new Dictionary<string, IDriver>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinNameValueLenght)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MinNameValueLenght));
                }
                this.name = value;
            }
        }

        public int Laps 
        {
            get => this.laps;
            private set 
            {
                if ( value < minLaps)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, minLaps));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => driverByName.Values.ToList();

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (driverByName.ContainsKey(driver.Name))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            driverByName.Add(driver.Name, driver);
        }
    }
}
