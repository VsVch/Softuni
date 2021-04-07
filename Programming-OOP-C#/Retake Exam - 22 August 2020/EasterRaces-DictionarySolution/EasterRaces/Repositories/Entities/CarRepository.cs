using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly IDictionary<string, ICar> carsByModel;

        public CarRepository()
        {
            carsByModel = new Dictionary<string, ICar>();
        }

        public void Add(ICar model)
        {
            if (carsByModel.ContainsKey(model.Model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model.Model));
            }
            this.carsByModel.Add(model.Model, model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return this.carsByModel.Values.ToList();
        }

        public ICar GetByName(string name)
        {

           return this.carsByModel.GetByKeyOrDefault(name);
        }

        private void GetByKeyOrDefault()
        {
            throw new NotImplementedException();
        }

        public bool Remove(ICar model)
        {           

            return this.carsByModel.Remove(model.Model);
        }
    }
}
