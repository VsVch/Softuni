using System;
using System.Collections.Generic;

namespace _06.EqualityLogic
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<Person> hashPeoples = new HashSet<Person>();

            SortedSet<Person> sortedSetPeoples = new SortedSet<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] personArg = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personArg[0];
                int age = int.Parse(personArg[1]);

                Person person = new Person(name, age);

                hashPeoples.Add(person);
                sortedSetPeoples.Add(person);
            }

            Console.WriteLine(hashPeoples.Count);
            Console.WriteLine(sortedSetPeoples.Count);
        }
    }
}
