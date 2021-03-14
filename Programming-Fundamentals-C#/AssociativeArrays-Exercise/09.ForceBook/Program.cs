using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> members = new Dictionary<string, List<string>>();

            string input;                       

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] command;

                if (input.Contains("|")) // {forceSide} | {forceUser}
                {
                    command = input.Split("|", StringSplitOptions.RemoveEmptyEntries);

                    string forceSide = command[0].Trim();
                    string userName = command[1].Trim();

                    bool isUserNameExist = false;

                    foreach (var member in members)
                    {
                        foreach (var item in member.Value)
                        {
                            if (item == userName)
                            {
                                isUserNameExist = true;                                
                            }
                        }
                    }

                    if (!members.ContainsKey(forceSide))
                    {
                        members.Add(forceSide, new List<string>());
                        members[forceSide].Add(userName);
                        
                    }                    
                    else 
                    {
                        if (!isUserNameExist) 
                        {
                            members[forceSide].Add(userName);
                        }                      
                    }
                }
                else if (input.Contains("->")) // {forceUser} -> {forceSide}
                {
                    command = input.Split("->" , StringSplitOptions.RemoveEmptyEntries);

                    string userName = command[0].Trim();
                    string forceSide = command[1].Trim();

                    bool isUserNameExist = false;

                    string currentForceSide = string.Empty;
                    foreach (var member in members)
                    {
                        foreach (var item in member.Value)
                        {
                            if (item == userName)
                            {
                                isUserNameExist = true;
                                currentForceSide = member.Key;
                            }
                        }
                    }

                    if (isUserNameExist)
                    {                       
                        members[currentForceSide].Remove(userName);

                        if (!members.ContainsKey(forceSide))
                        {
                            members.Add(forceSide, new List<string>());
                            members[forceSide].Add(userName);                                
                        }
                        else
                        {
                            members[forceSide].Add(userName);
                        }
                    }
                    else
                    {
                        if (!members.ContainsKey(forceSide))
                        {
                            members.Add(forceSide, new List<string>());
                            members[forceSide].Add(userName);
                        }
                        else
                        {
                            members[forceSide].Add(userName);
                        }
                    }

                    Console.WriteLine($"{userName} joins the {forceSide} side!");
                }                
            }

            

            foreach (var member in members.OrderByDescending(x => x.Value.Count()).ThenBy(x => x.Key))
            {
                if (member.Value.Count() == 0)
                {
                    continue;
                }
                Console.WriteLine($"Side: {member.Key}, Members: {member.Value.Count()}");

                foreach (var item in member.Value.OrderBy(x =>x))
                {
                    Console.WriteLine($"! {item}");
                }
            }
        }
    }
}
