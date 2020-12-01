using System;
using System.Data;
using System.Runtime.ConstrainedExecution;

namespace _04.TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int jury = int.Parse(Console.ReadLine());
            string nameOfPresentation = Console.ReadLine();
            
            double counter = 0;
            double allScore = 0;
            while (nameOfPresentation != "Finish")
            {
                double score = 0;
                for (int i = 1; i <= jury; i++)
                {
                    double evaluation = double.Parse(Console.ReadLine());
                    score += evaluation;
                    allScore += evaluation;
                    counter++;
                    
                }                
                double averageScore = score / jury;
                Console.WriteLine($"{nameOfPresentation} - {averageScore:f2}.");
                
                nameOfPresentation = Console.ReadLine();
            }

            double finalScore = allScore / counter;
            Console.WriteLine($"Student's final assessment is {finalScore:f2}.");
        }

    }
}
