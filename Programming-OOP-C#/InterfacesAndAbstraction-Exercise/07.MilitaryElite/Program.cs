using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Enums;
using _07.MilitaryElite.Models;
using System;
using System.Collections.Generic;

namespace _07.MilitaryElite
{
    public class StartUp
    {
        static void Main()
        {
            string input;
            Dictionary<string,ISolder> soldersById = new Dictionary<string, ISolder>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] line = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = line[0];
                string id = line[1];
                string firstName = line[2];
                string lastName = line[3];
                                
                if (type == nameof(Private))
                {                   
                    decimal salary =decimal.Parse(line[4]);

                    soldersById[id] = new Private(id, firstName, lastName, salary);

                }
                else if (type == nameof(LieutenantGeneral))
                {
                    decimal salary = decimal.Parse(line[4]);                    

                    LieutenantGeneral lieutenantGeneral =
                        new LieutenantGeneral(id, firstName, lastName, salary);                    

                    for (int i = 5; i < line.Length; i++)
                    {
                        string privateId = line[i];

                        if (!soldersById.ContainsKey(privateId))
                        {
                            continue;
                        }

                        lieutenantGeneral.AddPrivate((IPrivate)soldersById[privateId]);
                    }
                    soldersById[id] = lieutenantGeneral;
                }
                else if (type == nameof(Engineer))
                {
                    decimal salary = decimal.Parse(line[4]);
                  bool isCorpsIsValid = Enum.TryParse(line[5], out Corps corps);

                    if (!isCorpsIsValid)
                    {
                        continue;
                    }

                    IEngeneer engeneer = new Engineer(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < line.Length; i += 2)
                    {
                        string part = line[i];
                        int hoursWorked = int.Parse(line[i + 1]);

                        IRepair repair = new Repair(part, hoursWorked);

                        engeneer.AddRepair(repair);
                    }

                    soldersById[id] = engeneer;
                }
                else if (type == nameof(Commando))
                {
                    decimal salary = decimal.Parse(line[4]);
                    bool isCorpsIsValid = Enum.TryParse(line[5], out Corps corps);

                    if (!isCorpsIsValid)
                    {
                        continue;
                    }

                    Commando commando = new Commando(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < line.Length; i += 2)
                    {
                        string codeName = line[i];
                        string state = line[i + 1];

                        bool isMissionStateValid = Enum.TryParse(state, out MissionState missionState);

                        if (!isMissionStateValid)
                        {
                            continue;
                        }

                        IMission mission = new Mission(codeName, missionState);

                        commando.AddMission(mission);
                    }

                    soldersById[id] = commando;
                    
                }
                else if (type == nameof(Spy))
                {
                    int codeNumber = int.Parse(line[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldersById[id] = spy;
                }
            }

            foreach (var solger in soldersById)
            {
                Console.WriteLine(solger.Value);
            }
        }
       
    }
}
