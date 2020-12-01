using System;
using System.Xml.Schema;

namespace _04.Rate
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = double.Parse(Console.ReadLine());
            double mounts = int.Parse(Console.ReadLine());
            
            double moneySample = 500;
            double moneyDificult = 500;
            for (double i = 1; i <= mounts; i++)
            {
              
                moneySample += sum * 1.0 * 3/ 100;
                moneyDificult += moneyDificult  * 1.0 * 2.7 / 100;
                
                
 
            }
            double totalMoneyWin = Math.Abs(moneyDificult - moneySample);
            Console.WriteLine($"Simple interest rate: {moneySample:f2} lv.");
            Console.WriteLine($"Complex interest rate: {moneyDificult:f2} lv.");
            if (moneySample > moneyDificult)
            {
                Console.WriteLine($"Choose a simple interest rate. You will win {totalMoneyWin:f2} lv.");
            }
            else
            {
                Console.WriteLine($"Choose a complex interest rate. You will win {totalMoneyWin:f2} lv.");
            }
           
            
            
        }
    }
}
