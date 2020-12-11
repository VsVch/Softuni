using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {          

            string[] separator = { ":", "-"," "};

            List<Plant> plants = new List<Plant>();

            int n = int.Parse(Console.ReadLine());

            string input;

            int counter = 0;

            while (counter != n)
            {
                input = Console.ReadLine();

                string[] array = input.Split("<->");

                string plant = array[0];
                int rarity = int.Parse(array[1]);

                Plant newPlant = new Plant
                {
                    Name = array[0],
                    Rarity = rarity,
                    Raiting = 0.00,
                };

                if (plants.Contains(newPlant))
                {                    
                    newPlant.Rarity = rarity;
                }
                else
                {
                    plants.Add(newPlant);
                }

                counter++;
            }
            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] command = input
                        .Split(separator,StringSplitOptions.RemoveEmptyEntries);
                
                string cmdArg = command[0];
                string plantName = command[1];

                bool isThePlantExsist = plants.Select(x => x.Name).Contains(plantName);

                if (!isThePlantExsist)
                {
                    Console.WriteLine("error");
                    continue;
                }
                
                Plant plant = plants.FirstOrDefault(p => p.Name == plantName);                           
                                
                if (cmdArg == "Rate")// {plant} - {rating}
                {                    
                    double rating = double.Parse(command[2]);
                                                                            
                    if (plant.Raiting == 0.00)
                    {
                        plant.Raiting = rating;
                       
                    }
                    else
                    {
                        plant.Raiting = (plant.Raiting + rating) / 2;
                    }
                }
                else if (cmdArg == "Update") // {plant} - {new_rarity} 
                {                    
                    int newRarity = int.Parse(command[2]);
                    plant.Rarity = newRarity;
                }
                else if (cmdArg == "Reset")
                {                    
                    plant.Raiting = 0.00;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            Console.WriteLine($"Plants for the exhibition:");

            foreach (var plant in plants.OrderByDescending(r=>r.Rarity).ThenByDescending(r => r.Raiting))
            {
                Console.WriteLine(plant);
            }        
        }
    }
    class Plant 
    {
        public string Name { get; set; }

        public  int Rarity { get; set; }

        public  double Raiting { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"- {Name};");
            sb.Append($" Rarity: {Rarity};");
            sb.Append($" Rating: {Raiting:f2}");
            return sb.ToString().Trim();
        }
    }
}
