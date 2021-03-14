using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LastStop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> paintingNumber = Console.ReadLine()
                                              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                              .Select(int.Parse)
                                              .ToList();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                

                string portretNumber = command[0];

                if (portretNumber == "Reverse")
                {
                    paintingNumber.Reverse();
                    continue;
                }                

                int numberOne = int.Parse(command[1]);

                if (portretNumber == "Hide")
                {
                    if (paintingNumber.Contains(int.Parse(command[1])))
                    {
                        paintingNumber.Remove(int.Parse(command[1]));
                        continue;
                    }
                }                               
                
                int numberTwo = int.Parse(command[2]);

                switch (portretNumber)
                {
                    case "Change":
                        if (paintingNumber.Contains(numberOne))
                        {
                            for (int i = 0; i < paintingNumber.Count; i++)
                            {
                                if (numberOne == paintingNumber[i])
                                {
                                    paintingNumber[i] = numberTwo;
                                    break;
                                }
                                
                            }
                        }
                            break;
                    case "Switch":
                        if (paintingNumber.Contains(numberOne) && paintingNumber.Contains(numberTwo))
                        {
                            for (int i = 0; i < paintingNumber.Count; i++) 
                            {

                                if (numberOne == paintingNumber[i]) 
                                {
                                    for (int j = 0; j < paintingNumber.Count; j++)
                                    {
                                        if (numberTwo == paintingNumber[j])
                                        {
                                            int firstNum = paintingNumber[i];
                                            paintingNumber[i] = paintingNumber[j];
                                            paintingNumber[j] = firstNum;
                                            break;
                                        }

                                    }
                                    break;
                                }
                            }


                        }
                            break;
                    case "Insert":
                        if (numberOne < 0 || numberOne >= paintingNumber.Count - 1) 
                        {
                            continue;
                        }
                        else
                        {
                            paintingNumber.Insert(numberOne + 1, numberTwo);
                        }                        
                        break;
                    
                }

            }

            Console.WriteLine(string.Join(" ", paintingNumber));
        }
    }
}
