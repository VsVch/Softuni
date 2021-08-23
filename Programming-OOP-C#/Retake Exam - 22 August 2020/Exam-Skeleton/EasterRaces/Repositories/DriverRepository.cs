using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly List<IDriver> drivers;

        public DriverRepository()
        {
            drivers = new List<IDriver>();
        }

        public void Add(IDriver model)
        {
            drivers.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.drivers.ToArray();
        }

        public IDriver GetByName(string name)  // meaby error ? car = null
        {
            IDriver driver = drivers.FirstOrDefault(c => c.Name == name);
            return driver;
        }

        public bool Remove(IDriver model)
        {
            IDriver driver = drivers.FirstOrDefault(c => c.Name == model.Name);

            if (driver == null)
            {
                return false;
            }

            drivers.Remove(driver);
            return true;
        }
    }
}
