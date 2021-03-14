using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Engine
    {
        public Engine(int horsePower, double cubicCapacity)
        {
            HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
        public int HorsePower { get; set; }

        public double CubicCapacity { get; set; }
    }
}
