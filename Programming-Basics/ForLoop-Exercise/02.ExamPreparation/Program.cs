using System;

namespace _02.ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int poorGradesLimit = int.Parse(Console.ReadLine());
            string task = Console.ReadLine();
            int gradeCounter = 0;
            int poorGrateCounter = 0;
            int score = 0;
            bool isPerfect = true;
            string lastProblem = "";
            while (task != "Enough")
            {
                lastProblem = task;
                int grade = int.Parse(Console.ReadLine());
                gradeCounter++;
                score += grade;
                if (grade <= 4)
                {
                    poorGrateCounter++;
                    if (poorGrateCounter >= poorGradesLimit)
                    {
                        isPerfect = false;
                        break;
                    }
                }
                task = Console.ReadLine();
            }
            double averageScore = 1.0 * score / gradeCounter;
            if (isPerfect)
            {
                Console.WriteLine($"Average score: {averageScore:f2}");
                Console.WriteLine($"Number of problems: {gradeCounter}");
                Console.WriteLine($"Last problem: {lastProblem}");
               
            }
            else
            {
                Console.WriteLine($"You need a break, {poorGrateCounter} poor grades.");
            }
        }
    }
}
