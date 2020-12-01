using System;

namespace _03.Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string gymnasticDevice = Console.ReadLine();
            double dificult = 0;
            double performance = 0;
            switch (gymnasticDevice)//("ribbon", "hoop" или "rope") ("Russia", "Bulgaria" или "Italy")
            {
                case "ribbon":
                    if (country == "Russia")
                    {
                        dificult = 9.1;
                        performance = 9.4;
                    }
                    else if (country == "Bulgaria")
                    {
                        dificult = 9.6;
                        performance = 9.4;
                    }
                    else if (country == "Italy")
                    {
                        dificult = 9.2;
                        performance = 9.5;
                    }
                    break;
                case "hoop":
                    if (country == "Russia")
                    {
                        dificult = 9.3;
                        performance = 9.8;
                    }
                    else if (country == "Bulgaria")
                    {
                        dificult = 9.55;
                        performance = 9.75;
                    }
                    else if (country == "Italy")
                    {
                        dificult = 9.45;
                        performance = 9.35;
                    }
                    break;
                case "rope":
                    if (country == "Russia")
                    {
                        dificult = 9.6;
                        performance = 9.0;
                    }
                    else if (country == "Bulgaria")
                    {
                        dificult = 9.5;
                        performance = 9.4;
                    }
                    else if (country == "Italy")
                    {
                        dificult = 9.7;
                        performance = 9.15;                    
                    }
                    break;
            }
            double totalScore = dificult + performance;
            double percentFromMaxScore = (20 - totalScore) * 100 / 20;
            Console.WriteLine($"The team of {country} get {totalScore:f3} on {gymnasticDevice}.");
            Console.WriteLine($"{percentFromMaxScore:f2}%");
        }
    }
}
