using System;

namespace _08.OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHours = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arriveHours = int.Parse(Console.ReadLine());
            int arriveMinuts = int.Parse(Console.ReadLine());
            int difference = 0;
            int hour = 0;
            int minutes = 0;

            examMinutes += examHours * 60;
            arriveMinuts += arriveHours * 60;
            if (arriveMinuts > examMinutes)
            {
                Console.WriteLine("Late");
                difference = arriveMinuts - examMinutes;
                if (difference < 60)
                {
                    Console.WriteLine($"{difference} minutes after the start");
                }
                else
                {
                    hour = difference / 60;
                    minutes = difference % 60;
                    Console.WriteLine($"{hour}:{minutes:d2} hours after the start");
                }
            }
            else if (arriveMinuts < examMinutes - 30)
            {
                Console.WriteLine("Early");
                difference = examMinutes - arriveMinuts;
                if (difference <60)
                {
                    Console.WriteLine($"{difference} minutes before the start");
                }
                else
                {
                    hour = difference / 60;
                    minutes = difference % 60;
                    Console.WriteLine($"{hour}:{minutes:d2} hours before the start");
                }
            }
            else if (examMinutes == arriveMinuts)
            {
                Console.WriteLine("On Time");
            }
            else
            {
                Console.WriteLine("On Time");
                difference = examMinutes - arriveMinuts;
                Console.WriteLine($"{difference} minutes before the start ");
            }
        }
    }
}
