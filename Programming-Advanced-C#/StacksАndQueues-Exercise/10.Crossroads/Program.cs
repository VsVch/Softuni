using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());            

            Queue<string> cars = new Queue<string>();
            string input;
            bool isCrashHeppend = false;
            int carPassedCounter = 0;
            while ((input = Console.ReadLine()) != "END")
            {
                int greenLight = greenLightDuration;
                if (input == "green")
                {
                    while (greenLight != 0 && cars.Count > 0 )
                    {
                        string car = cars.Dequeue();
                        int carLength = car.Length;                        

                        if (greenLight - carLength < 0)
                        {                                                   

                            if (greenLight + freeWindow - carLength < 0)
                            {
                               
                                isCrashHeppend = true;
                                string ch = car.Substring(greenLight + freeWindow, 1);
                                Console.WriteLine($"{car} was hit at {ch}.");
                                Console.WriteLine("A crash happened!");
                                Environment.Exit(0);
                            }
                            greenLight = 0;
                            
                        }
                        else 
                        {
                            greenLight -= carLength;
                        }                      
                        
                        carPassedCounter++;
                    }
                    
                }
                else
                {
                    cars.Enqueue(input);
                }
            }
            if (!isCrashHeppend)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carPassedCounter} total cars passed the crossroads.");
            }
        }
    }
}
