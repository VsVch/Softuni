using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input;
            List<Person> persons = new List<Person>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] date = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = date[0];
                int age = int.Parse(date[1]);
                string town = date[2];

                Person persone = new Person(name, age, town);

                persons.Add(persone);
                
            }

            int n = int.Parse(Console.ReadLine());
            int index = n - 1;

            Person currPerson = persons[index];
           

            int equalPersons = 0;

            for (int i = 0; i < persons.Count; i++)
            {
                int result = currPerson.CompareTo(persons[i]);

                if (result == 0)
                {
                    equalPersons++;
                }
            }
            if (equalPersons == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPersons} {persons.Count - equalPersons} {persons.Count}");
            }            
        }
    }
}
