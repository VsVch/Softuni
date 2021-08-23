using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EasterRaces.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> cars;

        public CarRepository()
        {
            cars = new List<ICar>();
        }

        public void Add(ICar model)
        {
            cars.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return this.cars.ToArray();
        }

        public ICar GetByName(string name)  // meaby error ? car = null
        {
            ICar car = cars.FirstOrDefault(c => c.Model == name);
            return car;
        }

        public bool Remove(ICar model)
        {
            ICar car = cars.FirstOrDefault(c => c.Model == model.Model);

            if (car == null)
            {
                return false;
            }

            cars.Remove(car);
            return true;
        }
    }
}
