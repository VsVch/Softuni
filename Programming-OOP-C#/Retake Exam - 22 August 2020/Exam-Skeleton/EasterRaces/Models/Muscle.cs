using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars
{
    public class Muscle : Car
    {
        private const double MuscleCarCubicCentimeters = 5000;
        private const int MuscleMinHorsePower = 400;
        private const int MuscleMaxHorsePower = 600;
        public Muscle(string model, int horsePower)
            : base(model, horsePower, MuscleCarCubicCentimeters, MuscleMinHorsePower, MuscleMaxHorsePower)
        {
        }
    }
}
