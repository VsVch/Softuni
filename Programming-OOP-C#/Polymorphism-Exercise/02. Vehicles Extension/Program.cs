using System;

namespace _02.VehiclesExtension
{
     public class Program
     {
        static void Main(string[] args)
        {
            Vehicle car = VehicleCreator();
            Vehicle truck =VehicleCreator();
            Bus bus =(Bus) VehicleCreator();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) // Drive Car {distance}
            {
                string[] command = Console.ReadLine().Split(" ");

                string cmdArg = command[0];
                string vehicleType = command[1];
                double argument = double.Parse(command[2]);
                try
                {
                    if (cmdArg == "Drive")
                    {
                        if (vehicleType == nameof(Car))
                        {
                            Console.WriteLine($"{car.Drive(argument)}");
                        }
                        else if (vehicleType == nameof(Truck))
                        {
                            Console.WriteLine($"{truck.Drive(argument)}");
                        }
                        else if (vehicleType == nameof(Bus))
                        {
                            Console.WriteLine($"{bus.Drive(argument)}");
                        }
                    }
                    else if (cmdArg == "Refuel")
                    {

                        if (vehicleType == nameof(Car))
                        {
                            car.Refuel(argument);
                        }
                        else if (vehicleType == nameof(Truck))
                        {
                            truck.Refuel(argument);
                        }
                        else if (vehicleType == nameof(Bus))
                        {
                            bus.Refuel(argument);
                        }

                    }
                    else if (cmdArg == "DriveEmpty")
                    {
                        bus.AirConditionsOff();
                        Console.WriteLine($"{bus.Drive(argument)}");
                    }
                }

                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }   
            Console.WriteLine($"Car: {car.Fuel:f2}");
            Console.WriteLine($"Truck: {truck.Fuel:f2}");
            Console.WriteLine($"Bus: {bus.Fuel:f2}");
        }      

        private static Vehicle VehicleCreator()
        {
            Vehicle vehicle = null;

            string[] parts = Console.ReadLine().Split(); // {initial fuel quantity} {liters per km} {tank capacity}"

            string vehicleType = parts[0];
            double fuel = double.Parse(parts[1]);
            double fuelConsumption = double.Parse(parts[2]);
            double tankCapacity = double.Parse(parts[3]);

            if (vehicleType == nameof(Car))
            {
                vehicle = new Car(fuel, tankCapacity, fuelConsumption);
            }
            else if (vehicleType == nameof(Truck))
            {
                vehicle = new Truck(fuel, tankCapacity, fuelConsumption);
            }
            else if (vehicleType == nameof(Bus))
            {
                vehicle = new Bus(fuel, tankCapacity, fuelConsumption);
            }
            return vehicle;
        }
     }
}
