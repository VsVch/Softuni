using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            Dictionary<string,string> lightSide = new Dictionary<string, string>();
            Dictionary<string,string> darkSide = new Dictionary<string, string>();
           

            List<string> forceUser = new List<string>();
            List<string> changeUser = new List<string>();


            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {                

                if (input.Contains('>'))
                {
                    
                    changeUser = input.Split("->")
                        .Reverse()
                        .ToList();
                    string changeSideFors = changeUser[0];
                    string changeUserName = changeUser[1];

                    if (lightSide.ContainsKey(changeUserName))
                    {
                        lightSide.Remove(changeUserName);
                        darkSide.Add(changeSideFors, changeUserName);
                        Console.WriteLine($"{changeUserName} joins the {changeSideFors} side!");
                    }
                    if (darkSide.ContainsKey(changeUserName))
                    {
                        darkSide.Remove(changeUserName);
                        lightSide.Add(changeSideFors, changeUserName);
                        Console.WriteLine($"{changeUserName} joins the {changeSideFors} side!");
                    }
                   
                   
                }
                else
                {
                  forceUser = input.Split(" | ")                                
                                .ToList();
                    string sideForce = forceUser[0];
                    string userName = forceUser[1];

                    if (sideForce == "Light")
                    {
                        lightSide.Add(sideForce, userName);
                    }
                    else if (sideForce == "Dark")
                    {
                        darkSide.Add(sideForce, userName);
                    }
                }       
            }
            if (darkSide.Count >= lightSide.Count)
            {
                if (darkSide.Count != 0)
                {
                    foreach (var itemKey in darkSide)
                    {
                        Console.WriteLine($"Side: {itemKey.Key}, Members: {darkSide.Count}");

                        foreach (var item in darkSide.OrderBy(n => n))
                        {
                            Console.WriteLine($"! {item.Value}");
                        }
                    }
                }
                if (lightSide.Count != 0)
                {
                    foreach (var itemKey in lightSide)
                    {
                        Console.WriteLine($"Side: {itemKey.Key}, Members: {lightSide.Count}");

                        foreach (var item in lightSide.OrderBy(n => n))
                        {
                            Console.WriteLine($"! {item.Value}");
                        }
                    }
                }
            }
            else
            {
                if (lightSide.Count != 0)
                {
                    foreach (var itemKey in lightSide)
                    {
                        Console.WriteLine($"Side: {itemKey.Key}, Members: {lightSide.Count}");

                        foreach (var item in lightSide.OrderBy(n => n))
                        {
                            Console.WriteLine($"! {item.Value}");
                        }
                    }
                }
                if (darkSide.Count != 0)
                {
                    foreach (var itemKey in darkSide)
                    {
                        Console.WriteLine($"Side: {itemKey.Key}, Members: {darkSide.Count}");

                        foreach (var item in darkSide.OrderBy(n => n))
                        {
                            Console.WriteLine($"! {item.Value}");
                        }
                    }
                }
            }



            
        }
    }
}
