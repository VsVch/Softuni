using System;

namespace _01.NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficienci = int.Parse(Console.ReadLine());
            int secondEmployeeEfficienci = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficienci = int.Parse(Console.ReadLine());

            int allEmployeeEfficienci = firstEmployeeEfficienci + secondEmployeeEfficienci + thirdEmployeeEfficienci;

            int peoplesCount = int.Parse(Console.ReadLine());

            int questionsOfAnswer = peoplesCount;

            int hoursCount = 0;

            bool isAllQuestionsAnswered = false;

            while (isAllQuestionsAnswered == false)
            {
                if (questionsOfAnswer <= 0)
                {
                    isAllQuestionsAnswered = true;
                    break;
                }
                hoursCount++;

                questionsOfAnswer -= allEmployeeEfficienci;

                if (hoursCount % 4 == 0)
                {
                    hoursCount ++;
                }
            }
            Console.WriteLine($"Time needed: {hoursCount}h.");
        }
    }
}
