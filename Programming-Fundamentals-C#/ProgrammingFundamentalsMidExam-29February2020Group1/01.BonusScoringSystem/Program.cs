using System;


namespace _01.BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
             var countOfStudents = double.Parse(Console.ReadLine());

             var countOfTheLectors = double.Parse(Console.ReadLine());

             var inicialBonus = double.Parse(Console.ReadLine());

             int maxStudentScore = int.MinValue;

             int maxStudentAttendance = int.MinValue; ;
                     

             for (int i = 0; i < countOfStudents; i++)
             {
                int studentAttendance = int.Parse(Console.ReadLine());

                 int studentScore = (int)Math.Ceiling(studentAttendance * (5 + inicialBonus) / countOfTheLectors);

                 if (studentScore > maxStudentScore)
                 {
                     maxStudentScore = studentScore;
                     maxStudentAttendance = studentAttendance;
                 }

                 
             }               

             Console.WriteLine($"Max Bonus: {maxStudentScore}.");

             Console.WriteLine($"The student has attended {maxStudentAttendance} lectures."); 
                      
        }
    }
}
