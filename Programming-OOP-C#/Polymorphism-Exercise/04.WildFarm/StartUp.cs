using _04.WildFarm.Animals;
using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                Animal animal = CreateAnimal(input);

                string foodInput = Console.ReadLine();
                Food food = CreateFood(foodInput);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);

                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private static Food CreateFood(string foodInput)
        {            
            string[] foodData = foodInput
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string foodType = foodData[0];
            int foodQuantity = int.Parse(foodData[1]);

            Food food = null;

            if (foodType == nameof(Meat))
            {
                food = new Meat(foodQuantity);
            }
            else if (foodType == nameof(Vegetable))
            {
                food = new Vegetable(foodQuantity);
            }
            else if (foodType == nameof(Seeds))
            {
                food = new Seeds(foodQuantity);
            }
            else if (foodType == nameof(Fruit))
            {
                food = new Fruit(foodQuantity);
            }
            return food;
        }

        private static Animal CreateAnimal(string input)
        {           
            string[] animalData = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string animalType = animalData[0];
            string animalName = animalData[1];
            double weight = double.Parse(animalData[2]);
            

            Animal animal = null;

            if (animalType == nameof(Dog))
            {
                string livingRegion = animalData[3];
                animal = new Dog(animalName, weight, livingRegion);
            }
            else if (animalType == nameof(Mouse))
            {
                string livingRegion = animalData[3];
                animal = new Mouse(animalName, weight, livingRegion);
            }
            else if (animalType == nameof(Hen))
            {
                double wingSize = double.Parse(animalData[3]);
                animal = new Hen(animalName, weight, wingSize);
            }
            else if (animalType == nameof(Owl))
            {
                double wingSize = double.Parse(animalData[3]);
                animal = new Owl(animalName, weight, wingSize);
            }
            else if (animalType == nameof(Tiger))
            {
                string livingRegion = animalData[3];
                string breed = animalData[4];
                animal = new Tiger(animalName, weight, livingRegion, breed);
            }
            else if (animalType == nameof(Cat))
            {
                string livingRegion = animalData[3];
                string breed = animalData[4];
                animal = new Cat(animalName, weight, livingRegion, breed);
            }

            return animal;
        }
    }
}
