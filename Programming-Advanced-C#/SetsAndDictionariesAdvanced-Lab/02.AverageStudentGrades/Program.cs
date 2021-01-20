using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> studentsGrade = new Dictionary<string, List<decimal>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0].Trim();
                var grade = decimal.Parse(input[1]);

                if (!studentsGrade.ContainsKey(name))
                {
                    studentsGrade.Add(name, new List<decimal>());
                }
                studentsGrade[name].Add(grade);
            }

            foreach (var student in studentsGrade)
            {
                Console.Write($"{student.Key} -> ");               

                foreach (decimal item in student.Value)
                {
                    Console.Write($"{item:f2} ");
                   
                }
                
                Console.WriteLine($"(avg: {student.Value.Average():f2})");
                
            }
        }       
    }
}
