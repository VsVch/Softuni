using System;
using System.Data;

namespace _04.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberStudents = int.Parse(Console.ReadLine());
            const double convector = 1.0;
            int studentTotall = 0;
            double fallStudents = 0;
            double between34 = 0;
            double between45 = 0;
            double topStudents = 0;
            double studentGrede = 0;
            for (int i = 1; i <= numberStudents; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade <= 2.99)
                {
                    studentTotall++; 
                    fallStudents++;
                    studentGrede += grade;
                }
                else if (grade <= 3.99)
                {
                    studentTotall++;
                    between34++;
                    studentGrede += grade;
                }
                else if (grade <= 4.99)
                {
                    studentTotall++;
                    between45++;
                    studentGrede += grade;
                }
                else if (grade >= 4.99 && grade <= 6.00)
                {
                    studentTotall++;
                    topStudents++;
                    studentGrede += grade;
                }
            }
            double averageGrade = convector * studentGrede / studentTotall;
            double percentFallStudents = convector * fallStudents * 100 / studentTotall;
            double percentBetween34 = convector * between34 * 100 / studentTotall;
            double percentBetween45 = convector * between45 * 100 / studentTotall;
            double percentTopStudents = convector * topStudents * 100 / studentTotall;
            Console.WriteLine($"Top students: {percentTopStudents:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {percentBetween45:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {percentBetween34:f2}%");
            Console.WriteLine($"Fail: {percentFallStudents:f2}%");
            Console.WriteLine($"Average: {averageGrade:f2}");
        }
    }
}
