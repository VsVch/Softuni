using EasterRaces.Models.Races;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {

        private readonly List<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }

        public void Add(IRace model)
        {
            races.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.races.ToArray();
        }

        public IRace GetByName(string name)  // meaby error ? car = null
        {
            IRace race = races.FirstOrDefault(c => c.Name == name);
            return race;
        }

        public bool Remove(IRace model)
        {
            IRace race = races.FirstOrDefault(c => c.Name == model.Name);

            if (race == null)
            {
                return false;
            }

            races.Remove(race);
            return true;
        }
    }
}
