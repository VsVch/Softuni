using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();

            IBirthable birthable = null;

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] line = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdArg = line[0];

                if (cmdArg == "Citizen") // Citizen Pesho 22 9010101122 10/10/1990
                {
                    string name = line[1];
                    int age = int.Parse(line[2]);
                    string id = line[3];
                    string birthDate = line[4];

                    birthable = new Citizen(name, age, id, birthDate);

                    birthables.Add(birthable);
                }

                if (cmdArg == "Pet") // Pet Sharo 13 / 11 / 2005
                {
                    string name = line[1];
                    string birthDate = line[2];

                    birthable = new Pet(name, birthDate);

                    birthables.Add(birthable);
                }
            }

            string sicretDate = Console.ReadLine();

            List<IBirthable> filtredList = birthables
                    .Where(b => b.Birthdate.EndsWith(sicretDate))
                    .ToList();
                                      

            foreach (var item in filtredList)
            {
                Console.WriteLine(item.Birthdate);
            }
           
        }
    }
}
