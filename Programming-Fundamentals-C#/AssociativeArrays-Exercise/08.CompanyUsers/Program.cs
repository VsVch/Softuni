using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            Dictionary<string, List<string>> employeesInfo = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split("->");

                string company = command[0];
                string employee = command[1];

                if (!employeesInfo.ContainsKey(company))
                {
                    employeesInfo.Add(company, new List<string>());
                }
                if (!employeesInfo[company].Contains(employee))
                {
                    employeesInfo[company].Add(employee);
                }
                else
                {
                    continue;
                }
              
                
            }
            foreach (var item in employeesInfo.OrderBy(k => k.Key))
            {
                Console.WriteLine($"{item.Key}");

                foreach (var itemValue in item.Value)
                {
                    Console.WriteLine($"--{itemValue}");
                }
            }
            
        }
    }
}
