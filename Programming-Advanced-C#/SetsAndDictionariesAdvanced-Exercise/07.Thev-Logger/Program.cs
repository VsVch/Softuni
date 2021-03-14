using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Thev_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            Dictionary<string, Dictionary<string ,SortedSet<string>>> vLoggers =                 
                new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            while ((input = Console.ReadLine()) != "Statistics") 
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string vloggerOne = command[0];

                if (input.Contains("joined")) // EmilConrad joined The V-Logger
                {
                    
                    if (!vLoggers.ContainsKey(vloggerOne))
                    {
                        vLoggers.Add(vloggerOne,new Dictionary<string, SortedSet<string>>());
                        vLoggers[vloggerOne].Add("joining", new SortedSet<string>());
                        vLoggers[vloggerOne].Add("following", new SortedSet<string>());
                    }                  
                                       
                }
                else if (input.Contains("followed")) // Saffrona followed EmilConrad
                {

                    string vloggertwo = command[2];

                    if (vLoggers.ContainsKey(vloggerOne) && vLoggers.ContainsKey(vloggertwo) && vloggerOne != vloggertwo)
                    {
                        vLoggers[vloggertwo]["following"].Add(vloggerOne);
                        vLoggers[vloggerOne]["joining"].Add(vloggertwo);                 
                    }
                }
            }
            // Dictionary<string, Dictionary<string, SortedSet<string>>>
            Dictionary<string, Dictionary<string, SortedSet<string>>> sortedVLoggers = 
                vLoggers.OrderByDescending(v => v.Value["following"].Count)
                .ThenBy(v => v.Value["joining"].Count)
                .ToDictionary(k => k.Key, v=>v.Value);
                
            Console.WriteLine($"The V-Logger has a total of {vLoggers.Count} vloggers in its logs.");

            int vloggersCounter = 0;

            foreach (var vlogger in sortedVLoggers)
            {
               Console.WriteLine($"{++vloggersCounter}" +
                   $". {vlogger.Key} : " +
                   $"{vlogger.Value["following"].Count} followers, " +
                   $"{vlogger.Value["joining"].Count} following");

                if (vloggersCounter == 1)
                {
                    foreach (var item in vlogger.Value["following"])
                    {
                        Console.WriteLine($"*  {item}");
                    }
                    
                }
                
            }

        }
    }
}
