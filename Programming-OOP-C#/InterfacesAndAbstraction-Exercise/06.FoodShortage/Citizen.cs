using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    class Citizen : Person, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthdate)
            : base(name,age)
        {           
            this.Birthdate = birthdate;
            this.Id = id;
        }      

        public string Birthdate { get; private set; }

        public string Id { get; private set; }
             
        
        public override void BuyFood()
        {
            this.Food += 10;
        }
    }
}
