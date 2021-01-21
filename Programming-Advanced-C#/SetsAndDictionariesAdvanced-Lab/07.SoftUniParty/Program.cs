using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipMembers = new HashSet<string>();

            HashSet<string> regularMembers = new HashSet<string>();

            string input;

            while ((input = Console.ReadLine()) != "PARTY")
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[0] == '0' || input[0] == '1' || input[0] == '2' || 
                        input[0] == '4' || input[0] == '5' || input[0] == '6' || 
                        input[0] == '7' || input[0] == '8' || input[0] == '9'  )
                    {
                        vipMembers.Add(input);
                        break;
                    }
                    else
                    {
                        regularMembers.Add(input);
                        break;
                    }
                }               
            }

            while ((input = Console.ReadLine()) != "END")
            {
                string gestName = input;

                if (vipMembers.Contains(gestName))
                {
                    vipMembers.Remove(gestName);
                }
                if (regularMembers.Contains(gestName))
                {
                    regularMembers.Remove(gestName);
                }
            }
            int mistGuests = vipMembers.Count + regularMembers.Count;
            Console.WriteLine(mistGuests);
            foreach (var vip in vipMembers)
            {
                Console.WriteLine(vip);
            }
            foreach (var regular in regularMembers)
            {
                Console.WriteLine(regular);
            }
        }
    }
}
