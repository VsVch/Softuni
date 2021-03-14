using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    class Rebel : Person
    {
       // private List<Rebel> rebels;

        public Rebel(string name, int age, string group)
            : base(name, age)
        {            
            this.Group = group;
           // this.rebels = new List<Rebel>();
        }       
        public string Group { get; set; }
               

        public override void BuyFood()
        {
            this.Food += 5;
        }
    }
}
