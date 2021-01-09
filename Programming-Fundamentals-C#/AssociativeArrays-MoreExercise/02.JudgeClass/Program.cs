using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.JudgeClass
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            List<Judge> list = new List<Judge>();

            while ((input = Console.ReadLine()) != "no more time") // {username} -> {contest} -> {points}
            {
                string[] command = input.Split("->");

                string userName = command[0];
                string contest = command[1];
                int points = int.Parse(command[2]);

                Judge newUser = new Judge
                {
                    UserName = userName,
                    Contest = contest,
                    Points = points,                
                };               

                bool isContestExist = list.Select(x => x.Contest).Any(x => x.Contains(contest));
               
                bool isUserNameExist = list.Select(x => x.UserName).Contains(userName);

                if (!isContestExist)
                {                   
                    list.Add(newUser);                
                  
                }            
                else if (!isUserNameExist)
                {
                    int index = list.FindIndex(x => x.UserName == userName);
                    list[index].Contest.Add(userName);                    
                }
                else
                {
                    int index = list.FindIndex(x => x.Points == points);

                    if (points > list[index].Points)
                    {
                        list[index].Points = points;
                    }
                }
                
            }
            //int counter = 0;
            //foreach (var item in list.OrderByDescending(x => x.Points).ThenBy(x => x.UserName))
            //{
            //    Console.WriteLine($"{item.Contest}: {item.UserName.Count} participants");

            //    foreach (var member in item.UserName)
            //    {
            //        counter++;
            //        Console.WriteLine($"{counter}. {item.UserName} <::> {item.Points}");
            //    }
            //}
        }
    }
    class Judge // {username} -> {contest} -> {points}
    {
        public string UserName { get; set; }
        public string Contest { get; set; }
        public int Points { get; set; }
        

    }
}
