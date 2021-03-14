using _07.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Repair : IRepair
    {
        public Repair(string partName, int hoursWorked)
        {
            this.PartName = partName;
            this.HourdWorked = hoursWorked;
        }
        public string PartName { get; private set; }

        public int HourdWorked { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.HourdWorked}";
        }
    }
}
