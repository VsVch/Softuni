using System;

namespace _05.Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
                        
            while (true)
            {
                string country = Console.ReadLine();
                if (country == "End")
                {
                    break;
                }
                double priceOftrip = double.Parse(Console.ReadLine());
                double savedMoney = 0;
                while (savedMoney < priceOftrip)
                {
                    double inputMoney = double.Parse(Console.ReadLine());

                    savedMoney += inputMoney;
                }
                Console.WriteLine($"Going to {country}!");
            }
            
        }
    }
}
