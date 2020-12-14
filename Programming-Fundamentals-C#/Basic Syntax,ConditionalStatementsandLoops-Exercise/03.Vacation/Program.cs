using System;

namespace _03.Vacantion
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfpeoples = int.Parse(Console.ReadLine());
            string tipeOfTrip = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;
            if (tipeOfTrip == "Students") //8.45	9.80	10.46
            {
                if (day == "Friday")
                {
                    price = numberOfpeoples * 8.45;
                }
                else if (day == "Saturday")
                {
                    price = numberOfpeoples * 9.8;
                }
                else if (day == "Sunday")
                {
                    price = numberOfpeoples * 10.46;
                }
                if (numberOfpeoples >= 30)
                {
                    price *= 0.85;
                }
            }
            else if (tipeOfTrip == "Business") // 10.90	15.60	16
            {
                if (numberOfpeoples >= 100)
                {
                    numberOfpeoples -= 10;
                }
                if (day == "Friday")
                {
                    price = numberOfpeoples * 10.9;
                }
                else if (day == "Saturday")
                {
                    price = numberOfpeoples * 15.6;
                }
                else if (day == "Sunday")
                {
                    price = numberOfpeoples * 16.0;
                }
            }
            else if (tipeOfTrip == "Regular") // 15	20	22.50
            {
                if (day == "Friday")
                {
                    price = numberOfpeoples * 15.0;
                }
                else if (day == "Saturday")
                {
                    price = numberOfpeoples * 20.0;
                }
                else if (day == "Sunday")
                {
                    price = numberOfpeoples * 22.5;
                }
                if (numberOfpeoples >= 10 && numberOfpeoples <= 20)
                {
                    price *= 0.95;
                }
            }
                       
            Console.WriteLine($"Total price: {price:f2}");

        }
    
    }
}
