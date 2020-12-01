using System;

namespace _08.GraduationPt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double totalSum = 0;
            double curentGrade = 1;
            double countOfReapeatedClasses = 0;
            
            bool isExcluded = false; 
            
            while (curentGrade <= 12)
            {
                if (countOfReapeatedClasses == 2)
                {

                    Console.WriteLine($"{name} has been excluded at {curentGrade} grade ");
                    isExcluded = true;
                    break;
                }

                double grade = double.Parse(Console.ReadLine());
       
                if (grade < 4 )
                {
                    countOfReapeatedClasses++;

                    continue;
                   
                }
                totalSum += grade;

                curentGrade++;
               
            }
            if (!isExcluded)
            {
                double averageGread = totalSum / curentGrade;
                Console.WriteLine($"{name} graduated. Average grade: {averageGread:f2}");
            }
            

        }
    }
}
