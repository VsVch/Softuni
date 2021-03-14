using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine // "{model} {power} {displacement} {efficiency}
    {
        private string model;
        private int power;
        private string displacement = "n/a";
        private string efficiency = "n/a";


        public string Model { get => model; set => model = value; }
        public int Power { get => power; set => power = value; }
        public string Displacement { get => displacement; set => displacement = value; }
        public string Efficiency { get => efficiency; set => efficiency = value; }

        //public Engine(string model, int power)
        //{
        //    this.EngineModel = model;
        //    this.Power = power;            
        //}

        //public Engine(string engineModel, int power, int displacement) :this (engineModel, power)
        //{
        //    this.Displacement = displacement;
        //}

        //public Engine(string model, int power, char efficiency) : this(model, power)
        //{
        //    this.Efficiency = efficiency;
        //}

        //public Engine(string model, int power, int displacement, char efficiency) : this(model, power)
        //{
        //    this.Displacement = displacement;
        //    this.Efficiency = efficiency;
        //}

        //public string EngineModel { get; set; }

        //public int Power { get; set; }

        //public int Displacement { get; set; }

        //public char Efficiency { get; set; }
    }
}
