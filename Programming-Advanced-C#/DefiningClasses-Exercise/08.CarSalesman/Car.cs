using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car // "{model} {engine} {weight} {color}
    {
        private string model;
        private Engine engine;
        private string weight = "n/a";
        private string color = "n/a";

        public string Model { get => model; set => model = value; }
        public Engine Engine { get => engine; set => engine = value; }
        public string Weight { get => weight; set => weight = value; }
        public string Color { get => color; set => color = value; }

        //public Car(string model, string engine)
        //{
        //    this.Model = model;
        //    this.Engine = engine;
        //}

        //public Car(string model, string engine, int wight) : this (model, engine)
        //{
        //    this.Weight = wight;
        //}
        //public Car(string model, string engine, string color) : this (model, engine)
        //{
        //    this.Color = color;
        //}

        //public Car(string model, string engine, int wight, string color) : this(model, engine)
        //{
        //    this.Weight = wight;
        //    this.Color = color;
        //}

        //public string Model { get; set; }

        //public string Engine { get; set; }

        //public int Weight { get; set; }

        //public string Color { get; set; }



    }
}
