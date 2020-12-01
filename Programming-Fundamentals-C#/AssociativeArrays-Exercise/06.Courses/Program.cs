using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            Dictionary<string,List<string>> cource = new Dictionary<string,List<string>>();                          
            
            while ((input = Console.ReadLine())!= "end")
            {

                string[] studentsInfo = input
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string courceName=studentsInfo[0];

                string studentName=studentsInfo[1];

                if (!cource.ContainsKey(courceName))
                {
                    cource.Add(courceName, new List<string>());
                }
                cource[courceName].Add(studentName);
            }

            foreach (var currenCource in cource.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{currenCource.Key}: {currenCource.Value.Count}");

                foreach (var item in currenCource.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
