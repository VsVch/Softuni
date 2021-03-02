using _03.ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree.Core
{
    public class Engine
    {
        private readonly ICollection<Person> peoples;
        private readonly ICollection<Product> products;
        public Engine()
        {
            this.peoples = new List<Person>();
            this.products = new List<Product>();            
        }
        public void Run() 
        {
            try
            {
                this.ParsePeopleInput();
                this.ParseProductInput();

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] cmdArg = command
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string personName = cmdArg[0];
                    string productName = cmdArg[1];

                    Person person = this.peoples.FirstOrDefault(p => p.Name == personName);

                    Product product = this.products.FirstOrDefault(p => p.Name == productName);

                    if (person != null && product != null)
                    {
                        string result = person.BuyProduct(product);

                        Console.WriteLine(result);
                    }

                }

                foreach (Person person in this.peoples)
                {
                    Console.WriteLine(person);
                }

            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }          
        
        }
        private void ParsePeopleInput()
        {
            string[] peopleArg = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (string personStr in peopleArg)
            {
                string[] personArg = personStr.Split("=");

                string personName = personArg[0];
                decimal personMoney = decimal.Parse(personArg[1]);

                Person person = new Person(personName, personMoney);

                this.peoples.Add(person);
            }

        }

        private void ParseProductInput() 
        {
            string[] productArgs = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (string productStr in productArgs)
            {
                string[] productArg = productStr.Split("=");

                string productName = productArg[0];
                decimal productMoney = decimal.Parse(productArg[1]);

                Product product = new Product(productName, productMoney);

                this.products.Add(product);
            }
        }
    }
}
