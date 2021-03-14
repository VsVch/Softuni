using System;
using System.Collections.Generic;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> family = new List<Person>();
            Person mother = new Person("Mimi", 34);
            Person father = new Person("Sasho", 38);
            Child child = new Child("Misho", 6);           
            Baby baby = new Baby("Lubi", 1);

            family.Add(mother);
            family.Add(father);
            family.Add(child);
            family.Add(baby);

            foreach (var famalyMember in family)
            {
                Console.WriteLine(famalyMember);
            }          
            

        }
    }
}