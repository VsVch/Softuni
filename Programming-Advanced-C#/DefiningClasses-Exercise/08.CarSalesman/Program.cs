using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int nEngine = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < nEngine; i++) // {model} {power} {displacement} {efficiency}
            {
                Engine engine = new Engine();

                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string modelEngine = input[0];
                int power = int.Parse(input[1]);

                engine.Model = modelEngine;
                engine.Power = power;


                if (input.Length == 3)
                {
                    string thirdElement = input[2];

                    if (char.IsDigit(thirdElement, 0))
                    {                       
                        engine.Displacement = thirdElement;
                    }
                    else
                    {                        
                        engine.Efficiency = thirdElement;
                    }
                }
                if (input.Length == 4)
                {
                    string displacement = input[2];
                    string efficiency = input[3];

                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }

                engines.Add(engine);
            }

            int mCar = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < mCar; i++) // "{model} {engine} {weight} {color}
            {
                string[] secInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = secInput[0];
                var engine = engines.Where(e => e.Model == secInput[1]).FirstOrDefault();
               //int weight = int.Parse(secInput[2]);

                Car car = new Car();

                car.Model = model;
                car.Engine = engine;

                if (secInput.Length == 3)
                {
                    string thirdElement = secInput[2];

                    if (char.IsDigit(thirdElement, 0))
                    {
                        car.Weight = thirdElement;
                    }
                    else
                    {
                        car.Color = thirdElement;
                    }
                }
                else if (secInput.Length == 4)
                {
                    string weight = secInput[2];
                    string color = secInput[3];

                    car.Weight = weight;
                    car.Color = color;
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"   Power: {car.Engine.Power}");
                Console.WriteLine($"   Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"   Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}
