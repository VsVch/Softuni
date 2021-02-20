using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
   public class Race
   {
        private List<Racer> data;

        public Race(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>(capacity);
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }

        public void Add(Racer racer) 
        {
            if (data.Count < Capacity)
            {
                data.Add(racer);
            }    
        
        }

         public bool Remove(string name) // ???
         {
            bool isRacerExist = false;

            Racer racer = data.FirstOrDefault(n => n.Name == name);

            if (racer != null)
            {
                data.Remove(racer);
                isRacerExist = true;
                return isRacerExist;
            }
            return isRacerExist;
         }

        public Racer GetOldestRacer() 
        {
            
            Racer racer = data.OrderByDescending(n => n.Age).First();
            return racer;
        }
        public Racer GetRacer(string name) 
        {
            
            Racer racer = data.FirstOrDefault(n => n.Name == name);
            return racer;
        }

        public Racer GetFastestRacer()
        {
            Racer racer = data.OrderByDescending(n => n.Car.Speed).First();
            return racer;
        }
        public string Report()
        {
            StringBuilder racersInfo = new StringBuilder();
            racersInfo.AppendLine($"Racers participating at {this.Name}:");

            foreach (Racer racer in data)
            {
                racersInfo.AppendLine($"Racer: {racer.Name}, {racer.Age} ({racer.Country})");
            }
            return racersInfo.ToString();
        }

    }
}
