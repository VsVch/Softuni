using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Contracts
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository carRepository;
        private DriverRepository driverRepository;
        private RaceRepository raceRepository;

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
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            driver.AddCar(car);

            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = raceRepository.GetByName(raceName);

            IDriver driver = driverRepository.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }            

            race.AddDriver(driver);

            return $"Driver {driver.Name} added in {race.Name} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null; 

            if (type == nameof(Muscle))
            {
                car = new Muscle(model, horsePower);
            }

            else if (type == nameof(Sports))
            {
                car = new Sports(model, horsePower);
            }

            ICar curCar = carRepository
                .GetAll()
                .FirstOrDefault(c =>c.Model == model && c.GetType().Name == type && c.HorsePower == horsePower);

            
                        
            if (curCar != null && curCar.Model == car.Model && curCar.GetType().Name == car.GetType().Name && curCar.HorsePower == car.HorsePower)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }
           
            carRepository.Add(car);

            return $"{type}Car {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);            

            foreach (var item in driverRepository.GetAll())
            {
                if (item.Name == driverName)
                {
                    throw new ArgumentException($"Driver {driverName} is already created.");
                }
            }
            driverRepository.Add(driver);

            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            Race race = new Race(name, laps);

            foreach (var item in raceRepository.GetAll())
            {
                if (item.Name == name)
                {
                    throw new InvalidOperationException($"Race {name} is already create.");
                }
            }

            raceRepository.Add(race);

            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }            

            List<IDriver> driversInTheRace = new List<IDriver>();

            foreach (var item in race.Drivers)
            {
                driversInTheRace.Add(item);
            }

            if (driversInTheRace.Count < 3)
            {
                throw new InvalidOperationException($"Race {race.Name} cannot start with less than 3 participants.");
            }

            List<IDriver> driversPoints = driversInTheRace
                .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                .ToList();        

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    sb.AppendLine($"Driver {driversPoints[i].Name} wins {race.Name} race.");
                }

                if (i == 1)
                {
                    sb.AppendLine($"Driver {driversPoints[i].Name} is second in {race.Name} race.");
                }

                if (i == 2)
                {
                    sb.AppendLine($"Driver {driversPoints[i].Name} is third in {race.Name} race.");
                }
            }
           return sb.ToString().TrimEnd();
        }
    }
}
