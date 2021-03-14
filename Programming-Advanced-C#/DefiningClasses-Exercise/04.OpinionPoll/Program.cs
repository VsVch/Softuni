using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();                

           
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");

                string name = input[0];
                int age = int.Parse(input[1]);

                Person currPerson = new Person(name, age);

                people.Add(currPerson);
            }

            List<Person> members = people
                                  .Where(a => a.Age > 30)
                                  .OrderBy(n => n.Name)
                                  .ToList();

            foreach (Person member in members)
            {
                Console.WriteLine($"{member.Name} - {member.Age}");
            }
        }
    }
}
