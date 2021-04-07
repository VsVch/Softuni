using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly IDictionary<string, IDriver> driversByName;

        public DriverRepository()
        {
            driversByName = new Dictionary<string, IDriver>();
        }
        public void Add(IDriver model)
        {
            if (driversByName.ContainsKey(model.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, model.Name));
            }
            driversByName.Add(model.Name, model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.driversByName.Values.ToList();
        }

        public IDriver GetByName(string name)
        {
           return this.driversByName.GetByKeyOrDefault(name);            
        }

        public bool Remove(IDriver model)
        {
            return this.driversByName.Remove(model.Name);
        }
    }
}
