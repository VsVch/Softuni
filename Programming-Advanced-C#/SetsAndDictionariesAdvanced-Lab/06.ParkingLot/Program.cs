using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var command = input.Split(", ");

                var direction = command[0];
                var carNumber = command[1];

                if (direction == "IN")
                {
                    carNumbers.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    carNumbers.Remove(carNumber);
                }
            }

            if (carNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var carNumber in carNumbers)
                {
                    Console.WriteLine(carNumber);
                }
            }
            
        }
    }
}
