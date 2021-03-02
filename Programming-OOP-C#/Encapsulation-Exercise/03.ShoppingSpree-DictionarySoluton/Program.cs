using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree_DictionarySoluton
{
    public class Program
    {      

        public static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            try
            {
                people = ReadPeople();
                products = ReadProducts();
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split(" ");

                string personName = command[0];
                string productName = command[1];

                Person person = people[personName];
                Product product = products[productName];
                try
                {
                    person.AddProduct(product);
                    Console.WriteLine($"{personName} bought {productName}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }           
            }

            foreach (var person in people.Values)
            {
                Console.WriteLine(person);
            }
        }

        private static Dictionary<string, Product> ReadProducts()
        {
            var result = new Dictionary<string, Product>();

            string[] parts = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                string[] partData = part.Split("=");

                string name = partData[0];
                decimal cost = decimal.Parse(partData[1]);

                result[name] = new Product(name, cost);
            }
            return result;
        }

        private static Dictionary<string,Person> ReadPeople()
        {
            var result
                = new Dictionary<string, Person>();

            string[] parts = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                string[] personData = part.Split("=");

                string name = personData[0];

                decimal money = decimal.Parse(personData[1]);

                result[name] = new Person(name, money);
            }

            return result;
        }
    }
}
