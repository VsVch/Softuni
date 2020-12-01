using System;

namespace _05MonthPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string mounth = string.Empty;
            if (number == 1) // January, , March, April, May, June, July, August, September, October, November, December.
            {
                mounth = "January";
            }
            else if (number == 2)
            {
                mounth = "February";
            }
            else if (number == 3)
            {
                mounth = "March";
            }
            else if (number == 4)
            {
                mounth = "April";
            }
            else if (number == 5)
            {
                mounth = "May";
            }
            else if (number == 6)
            {
                mounth = "June";
            }
            else if (number == 7)
            {
                mounth = "July";
            }
            else if (number == 8)
            {
                mounth = "August";
            }
            else if (number == 9)
            {
                mounth = "September";
            }
            else if (number == 10)
            {
                mounth = "October";
            }
            else if (number == 11)
            {
                mounth = "November";
            }
            else if (number == 12)
            {
                mounth = "December";
            }
            else
            {
                Console.WriteLine("Error!");
            }
            Console.WriteLine($"{mounth}");
        }
    }
}
