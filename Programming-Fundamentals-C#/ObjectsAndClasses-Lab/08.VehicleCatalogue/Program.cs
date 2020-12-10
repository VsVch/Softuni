using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            List<Car> cars = new List<Car>();

            List<Truck> trucks = new List<Truck>();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split("/");

                string type = command[0];

                string brand = command[1];

                string model = command[2];

                if (type == "Car") // Trucks and Cars
                {
                    int power = int.Parse(command[3]);

                    Car car = new Car 
                    {
                        Type = type,
                        Brand =  brand,
                        Model = model,
                        Power = power,                    
                    };

                    cars.Add(car);              
                   
                }
                else if(type == "Truck")
                {
                        int weight = int.Parse(command[3]);

                    Truck truck = new Truck 
                    {
                        Type = type,
                        Brand = brand,
                        Model = model,
                        Weight = weight,
                    };

                    trucks.Add(truck);
                }

            }

            if (cars.Count > 0)
            {
                Console.WriteLine("Cars:");

                foreach (var item in cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{item.Brand}: {item.Model} - {item.Power}hp");
                }
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");

                foreach (var item in trucks.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{item.Brand}: {item.Model} - {item.Weight}kg");
                }
            }
            
        }
    }
    class Car //Brand, Model and Horse Power
    {
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }        
        public int Power { get; set; }      
    }
    class Truck  // Brand, Model and Weight
    {
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

    }    
}
