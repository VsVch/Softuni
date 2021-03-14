using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedforSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            var carsMileage = new Dictionary<string, int>();

            var carsFuel = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int maxMileage = 100000;

            int maxFuelTank = 75;

            while (true) // {car}|{mileage}|{fuel}
            {

                if (input.Equals("Stop"))
                {
                    break;
                }

                if (input.Contains("|"))
                {
                    string[] array = input.Split("|");

                    string car = array[0];
                    int mileage = int.Parse(array[1]);
                    int fuel = int.Parse(array[2]);

                    carsMileage.Add(car, mileage);
                    carsFuel.Add(car, fuel);
                }

                if (input.Contains(" : "))
                {
                    string[] command = input.Split(" : ");

                    string cmdArg = command[0];

                    if (cmdArg == "Drive") // {car} : {distance} : {fuel}
                    {
                        string car = command[1];
                        int distance = int.Parse(command[2]);
                        int fuel = int.Parse(command[3]);

                        if (carsFuel[car] < fuel)
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                        else
                        {
                            carsFuel[car] -= fuel;
                            carsMileage[car] += distance;
                            Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                            if (carsMileage[car] >= maxMileage)
                            {
                                Console.WriteLine($"Time to sell the {car}!");

                                carsMileage.Remove(car);
                                carsFuel.Remove(car);
                            }
                        }
                    }
                    else if (cmdArg == "Refuel") // {car} : {fuel}
                    {
                        string car = command[1];
                        int fuel = int.Parse(command[2]);
                        int oldFuel = carsFuel[car];

                        int refuel = fuel + carsFuel[car];

                        if (refuel > maxFuelTank)
                        {
                            carsFuel[car] = maxFuelTank;
                            Console.WriteLine($"{car} refueled with {maxFuelTank - oldFuel} liters");
                        }
                        else
                        {
                            carsFuel[car] = refuel;
                            Console.WriteLine($"{car} refueled with {fuel} liters");
                        }
                    }
                    else if (cmdArg == "Revert") // {car} : {kilometers}
                    {
                        string car = command[1];
                        int kilometers = int.Parse(command[2]);

                        int revert = carsMileage[car] - kilometers;

                        if (revert >= 10000)
                        {
                            carsMileage[car] = revert;
                            Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                        }
                        else
                        {
                            carsMileage[car] = 10000;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var car in carsMileage.OrderByDescending(v => v.Value).ThenBy(k => k.Key)) // mileage in decscending order, then by their name in ascending order.
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value} kms, Fuel in the tank: {carsFuel[car.Key]} lt.");
            }
        }
    }
}
