using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionState state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; private set; }

        public MissionState State { get; private set; }

        public void CompleteMission()
        {
            this.State = MissionState.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
