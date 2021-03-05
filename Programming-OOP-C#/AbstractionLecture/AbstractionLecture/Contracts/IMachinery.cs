using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractionLecture.Contracts
{
    public interface IMachinery
    {
        public void ListAllMachines();

        List<string> machines { get; set; }
    }
}
