using System;
using System.ComponentModel.DataAnnotations;

namespace _05.EasterEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggsNumber = int.Parse(Console.ReadLine());
            int countRed = 0;
            int countOrange = 0;
            int countBlue = 0;
            int countGreen = 0;           
            int maxValue = 0;
            string maxValueColor = "";
             for (int i = 1; i <= eggsNumber; i++)
             {
                string colorsOfEggs = Console.ReadLine();
                switch (colorsOfEggs)
                {
                    case "red":
                        countRed++;                        
                        break;
                    case "orange":
                        countOrange++;                       
                        break;
                    case "blue":
                        countBlue++;                       
                        break;
                    case "green":
                        countGreen++;                        
                        break;
                }
             }
            if (countRed > countOrange && countRed > countBlue && countRed > countGreen)
            {
                maxValue = countRed;
                maxValueColor = "red";
            }
            if (countOrange > countRed && countOrange > countBlue && countOrange > countGreen)
            {
                maxValue = countOrange;
                maxValueColor = "orange";
            }
            if (countBlue > countRed && countBlue > countOrange && countBlue > countGreen)
            {
                maxValue = countBlue;
                maxValueColor = "blue";
            }
            if (countGreen > countRed && countGreen > countOrange && countGreen > countBlue)
            {
                maxValue = countGreen;
                maxValueColor = "green";
            }
            Console.WriteLine($"Red eggs: {countRed}");
            Console.WriteLine($"Orange eggs: {countOrange}");
            Console.WriteLine($"Blue eggs: {countBlue}");
            Console.WriteLine($"Green eggs: {countGreen}");
            Console.WriteLine($"Max eggs: {maxValue} -> {maxValueColor} ");
        }
    }
}
