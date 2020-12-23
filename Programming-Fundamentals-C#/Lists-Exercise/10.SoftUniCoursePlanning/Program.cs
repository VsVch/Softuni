using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine()
                                                  .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                                                  .ToList();

            string input ;

            string exercise = "-Exercise";

            while ((input = Console.ReadLine()) != "course start")
            {
                string[] command = input
                                  .Split(":",StringSplitOptions.RemoveEmptyEntries);

                string cmdArg = command[0];
                string lessonTitle = command[1];                 

                switch (cmdArg)
                {
                    case "Add":

                        if (!schedule.Contains(lessonTitle))
                        {
                            schedule.Insert(schedule.Count, lessonTitle);
                        }
                        else
                        {
                            continue;
                        }
                        break;    
                        
                    case "Insert":

                        int index = int.Parse(command[2]);

                        if (schedule.Contains(lessonTitle))
                        {
                            continue;
                        }
                        else
                        {
                            schedule.Insert(index, lessonTitle);
                        }
                        break;
                        
                    case "Remove":

                        if (schedule.Contains(lessonTitle))
                        {
                            schedule.Remove(lessonTitle);
                        }
                        else if (schedule.Contains(lessonTitle + exercise))
                        {
                            schedule.Remove(lessonTitle + exercise);
                        }
                        else
                        {
                            continue;
                        }
                        break;
                       
                    case "Swap": 

                        string lessonTwoTitle = command[2];

                        if (schedule.Contains(lessonTitle) && schedule.Contains(lessonTwoTitle))
                        {
                            for (int i = 0; i < schedule.Count; i++)
                            {
                                if (schedule[i] == lessonTitle )
                                {
                                    schedule[i] = lessonTwoTitle;

                                    if (schedule.Contains(lessonTwoTitle + exercise))
                                    {

                                        for (int j = schedule.Count - 1; j >= 0; j--)
                                        {
                                            if (schedule[j] == lessonTwoTitle + exercise)
                                            {
                                                schedule.Remove(schedule[j]);
                                                break;
                                            }
                                        }
                                        schedule.Insert((i + 1), lessonTwoTitle + exercise);
                                    }
                                }
                                else if (schedule[i] == lessonTwoTitle)
                                {
                                    schedule[i] = lessonTitle;                                    
                                }
                                
                            }
                        }
                        else
                        {
                            continue;
                        }

                        break;
                    case "Exercise":                                             
                        
                        if (schedule.Contains(lessonTitle))
                        {
                            for (int i = 0; i < schedule.Count; i++)
                            {
                                if (schedule[i] == lessonTitle)
                                {
                                    schedule.Insert((i + 1), lessonTitle + exercise);
                                }
                            }
                        }
                        else
                        {
                            schedule.Add(lessonTitle);
                            schedule.Add(lessonTitle + exercise);

                        }
                        break;

                    default:
                        break;
                }

            }

            int scheduleCounter = 0;

            foreach (var item in schedule)
            {
                scheduleCounter++;
                Console.WriteLine($"{scheduleCounter}.{item}");
            }
        }
    }
}
