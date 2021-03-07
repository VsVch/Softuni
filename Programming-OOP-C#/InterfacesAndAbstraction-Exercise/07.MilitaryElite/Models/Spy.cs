using _07.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Spy : Solder, ISpy
    {
        public Spy(string id, string firstName, string lastName,int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return base.ToString() +
               Environment.NewLine +
               $"Code Number: {this.CodeNumber}";
        }
    }
}
