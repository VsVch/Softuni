using System;

namespace _05.AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            

            double seveMoney = 0;

            while (input != "NoMoreMoney")

            {
                double inputMoney = double.Parse(input);
                if (inputMoney < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                      
                Console.WriteLine($"Increase: {input:f2}");
                seveMoney += inputMoney;

                input = Console.ReadLine();
                
            }
            Console.WriteLine($"Total: {seveMoney:f2}");
        }
    }
}
