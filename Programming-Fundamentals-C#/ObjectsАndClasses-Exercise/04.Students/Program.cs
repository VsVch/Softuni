using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string firsName = tokens[0];
                string lastName = tokens[1];
                double grade = double.Parse(tokens[2]);

                Student student = new Student(firsName, lastName, grade);

                students.Add(student);
            }
            students = students.OrderByDescending(x => x.Grade).ToList();

            foreach (Student currentstudent in students)
            {
                Console.WriteLine(currentstudent);
            }
            
        }
    }
    class Student 
    {
        public Student(string firstname, string lastname, double grade) 
        {
            FirstName = firstname;
            LastName = lastname;
            Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
}
