using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars
{
    class Sports : Car
    {
        private const double SportsCarCubicCentimeters = 3000;
        private const int SportsMinHorsePower = 250;
        private const int SportsMaxHorsePower = 450;
        public Sports(string model, int horsePower)
            : base(model, horsePower, SportsCarCubicCentimeters, SportsMinHorsePower, SportsMaxHorsePower)
        {
        }
    }
}
