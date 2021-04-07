using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly CarRepository carRepository;
        private readonly DriverRepository driverRepository;
        private readonly RaceRepository raceRepository;

        private const int minParticipatesDrivers = 3;

        public ChampionshipController()
        {
            carRepository = new CarRepository();
            driverRepository = new DriverRepository();
            raceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car = carRepository.GetByName(carModel);

            IDriver driver = driverRepository.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName,carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = raceRepository.GetByName(raceName);

            IDriver driver = driverRepository.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            string curtype = type + "Car";

            if (curtype == "SportsCar")
            {
                car = new SportsCar(model, horsePower);
            }
            else if (curtype == "MuscleCar")
            {
                car = new MuscleCar(model, horsePower);
            }

            carRepository.Add(car);

            return string.Format(OutputMessages.CarCreated, curtype, model);
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);            

            driverRepository.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);

            raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
           IRace race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < minParticipatesDrivers)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, minParticipatesDrivers));
            }

            List<string> orderedDrivers = new List<string>();

            foreach (var item in race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)))
            {
                orderedDrivers.Add(item.Name);
            }

            raceRepository.Remove(race);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition,orderedDrivers[0],raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition,orderedDrivers[1],raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition,orderedDrivers[2],raceName));

            return sb.ToString().TrimEnd();
        }
    }
}
