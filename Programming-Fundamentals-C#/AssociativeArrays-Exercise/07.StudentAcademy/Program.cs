using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, double> studentGrade = new Dictionary<string, double>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                double grade = double.Parse(Console.ReadLine());

                if (! studentGrade.ContainsKey(name))
                {
                    studentGrade.Add(name, grade);
                }
                else
                {
                    studentGrade[name] = (studentGrade[name] + grade) / 2;
                }
                
            }

            Dictionary<string, double> sortedStudentGrade = studentGrade
                .OrderByDescending(n => n.Value)
                .ToDictionary(n => n.Key, n =>n.Value);

            foreach (var item in sortedStudentGrade)
            {
                if (item.Value >= 4.50)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value:f2}");
                }
            }
                
        }
    }
}
