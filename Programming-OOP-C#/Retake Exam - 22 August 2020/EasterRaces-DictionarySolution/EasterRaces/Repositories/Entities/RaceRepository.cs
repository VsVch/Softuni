using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private IDictionary<string, IRace> racesByName;

        public RaceRepository()
        {
            racesByName = new Dictionary<string, IRace>();
        }

        public void Add(IRace model)
        {
            if (racesByName.ContainsKey(model.Name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists));
            }

            racesByName.Add(model.Name, model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.racesByName.Values.ToList();
        }

        public IRace GetByName(string name)
        {
            return this.racesByName.GetByKeyOrDefault(name);
        }

        public bool Remove(IRace model)
        {
            return this.racesByName.Remove(model.Name);
        }
    }
}
