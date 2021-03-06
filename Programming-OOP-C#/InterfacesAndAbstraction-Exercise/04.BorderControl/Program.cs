using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IIdentificable> visitors = new List<IIdentificable>();

            IIdentificable visitor = null;

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] line = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = line[0];

                if (line.Length == 3)
                {
                    int age = int.Parse(line[1]);
                    string id = line[2];

                    visitor = new Citizen(name, age, id);

                    visitors.Add(visitor);
                }
                else if (line.Length == 2) 
                {
                    string id = line[1];

                    visitor = new Robot(name, id);

                    visitors.Add(visitor);
                }                
            }           

            string secretNumber = Console.ReadLine();

           List<IIdentificable>filteredVisitors = visitors
                .Where(v => v.Id.EndsWith(secretNumber))
                .ToList();

            foreach (var item in filteredVisitors)
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}
