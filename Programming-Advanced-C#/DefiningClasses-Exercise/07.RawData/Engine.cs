using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Engine
    {
        private int enginSpeed;

        private int enginPower;

        public Engine(int enginSpeed, int enginPower)
        {
            this.EngineSpeed = enginSpeed;

            this.EnginePower = enginPower;
        }

        public int EngineSpeed { get; set; }

        public int EnginePower { get; set; }
        
    }
}
