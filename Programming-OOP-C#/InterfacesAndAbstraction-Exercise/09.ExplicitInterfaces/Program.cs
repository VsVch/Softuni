using _09.ExplicitInterfaces.Contracts;
using _09.ExplicitInterfaces.Models;
using System;

namespace _09.ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            Citizen citizen;

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] line = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string name = line[0];
                string country = line[1];
                int age = int.Parse(line[2]);

                citizen = new Citizen(name, country, age);

                IResident resident = citizen;
                IPerson person = citizen;
                
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
