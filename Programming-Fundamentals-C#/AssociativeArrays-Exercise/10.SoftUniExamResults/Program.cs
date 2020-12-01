using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            Dictionary<string, int> examScores = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();


            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] info = input.Split("-");

                string userName = info[0];
                string langluge = info[1];

                if (langluge == "banned")
                {
                    examScores.Remove(userName);
                    continue;
                }

                int points =int.Parse(info[2]);

                if (! examScores.ContainsKey(userName))
                {
                    examScores.Add(userName, points);
                }
                if (examScores[userName] < points)
                {
                    examScores[userName] = points;
                }
                if (!submissions.ContainsKey(langluge))
                {
                    submissions.Add(langluge, 1);
                }
                else
                {
                    submissions[langluge]++;
                }
                
            }
            Console.WriteLine("Results:");

            foreach (var item in examScores.OrderByDescending(v => v.Value).ThenBy(k => k.Key))
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var item in submissions.OrderByDescending(v => v.Value).ThenBy(k => k.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            
        }
    }
}
