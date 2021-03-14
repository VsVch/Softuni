using System;

namespace _01.Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle car = VehicleCreater();
            Vehicle truck = VehicleCreater();

            int n = int.Parse(Console.ReadLine());

            
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string cmdArg = command[0];
                string modelVehicle = command[1];

                if (cmdArg == "Drive")
                {
                    double distance = double.Parse(command[2]);

                    if (modelVehicle == nameof(Car))
                    {
                        Console.WriteLine(car.Drive(distance)); 
                    }
                    else
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }                   
                    
                }
                else if (cmdArg == "Refuel")
                {
                    double extraFuel = double.Parse(command[2]);

                    if (modelVehicle == nameof(Car))
                    {
                        car.Refuel(extraFuel); 
                    }
                    else
                    {
                        truck.Refuel(extraFuel);
                    }
                }                
            }
            
            Console.WriteLine($"Car: {car.Fuel:f2}");
            Console.WriteLine($"Truck: {truck.Fuel:f2}");                
        }

        private static Vehicle VehicleCreater()
        {
            Vehicle vehicle = null;

            string[] parts = Console.ReadLine() // Car {fuel quantity} {liters per km}
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string currVehicle = parts[0];
            double currFuel = double.Parse(parts[1]);
            double fuelConsumption = double.Parse(parts[2]);

            if (currVehicle == "Car")
            {
                vehicle = new Car(currFuel,fuelConsumption); 
            }
            else
            {
                vehicle = new Truck(currFuel, fuelConsumption);
            }

            return vehicle;
        }
    }
}
