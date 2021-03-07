using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage
{
    public class StartUp
    {
        static void Main()
        {
            Dictionary<string, IBuyer> buyersByName = 
                new Dictionary<string, IBuyer>();            

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = parts[0];
                int age =int.Parse(parts[1]);
                if (parts.Length == 3)
                {
                    string group = parts[2];

                    buyersByName[name] = new Rebel(name, age, group);
                }
                else
                {
                    string id = parts[2];
                    string birthdate = parts[3];

                    buyersByName[name] = new Citizen(name, age, id, birthdate);
                }
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string currName = input;

                if (!buyersByName.ContainsKey(currName))
                {
                    continue;
                }

                IBuyer buyer = buyersByName[currName];

                buyer.BuyFood();
            }

            int totall = buyersByName.Values.Sum(b => b.Food);

            Console.WriteLine(totall);
        }
    }
}
