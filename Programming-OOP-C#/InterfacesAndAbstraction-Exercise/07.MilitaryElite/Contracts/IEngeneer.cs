using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Contracts
{
    public interface IEngeneer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs {get;}

        void AddRepair(IRepair repair);
    }
}
