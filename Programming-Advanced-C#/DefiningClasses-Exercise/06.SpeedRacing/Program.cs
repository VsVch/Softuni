using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++) //"{model} {fuelAmount} {fuelConsumptionFor1km}"
            {
                string[] inputOne = Console.ReadLine().Split(" ");

                string model = inputOne[0];
                double fuelAmount = double.Parse(inputOne[1]);
                double fuelConsumptionFor1km = double.Parse(inputOne[2]);

                Car currCar = new Car()
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsumptionPerKilometer = fuelConsumptionFor1km
                };

                cars.Add(currCar);
            }

            string input;
            while ((input = Console.ReadLine()) != "End") //{carModel} {amountOfKm}
            {
                string[] command = input.Split(" ");

                string carModel = command[1];
                double amountOfKm = double.Parse(command[2]);

                Car currCar = cars.FirstOrDefault(x => x.Model == carModel);

               bool isDrive = currCar.Drive(amountOfKm);

                if (isDrive == false)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }

        }
    }
    
}
