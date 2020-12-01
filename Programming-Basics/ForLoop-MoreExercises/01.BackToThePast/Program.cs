using System;
using System.Xml;

namespace _01.BackToThePast
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double inheritance = double.Parse(Console.ReadLine());
            int yearsLiveLeft = int.Parse(Console.ReadLine());
                       
            int evenYears = 0;
            int oddYears = 0;
            double spendedMoneyEvenYear = 0;
            double spendedMoneyOddYear = 0;
            int ivanchoYears = 18;
            for (int i = 1800; i <= yearsLiveLeft; i++)
            {
                
                if (i % 2 == 0)
                {
                    evenYears++;
                    spendedMoneyEvenYear += 12000 ;
                    ivanchoYears++;


                }
                else if (i % 2 != 0)
                {
                    oddYears++;
                    spendedMoneyOddYear += 12000 + (50 * ivanchoYears);
                    ivanchoYears++;
                }
            }
                     

            
            double totallMoney = spendedMoneyOddYear + spendedMoneyEvenYear;
            if (inheritance >= totallMoney)
            {
                double moneyLeft = inheritance - totallMoney;
                Console.WriteLine($"Yes! He will live a carefree life and will have {moneyLeft:f2} dollars left.");
            }
            else
            {
                double neededMoney = totallMoney - inheritance;
                Console.WriteLine($"He will need {neededMoney:f2} dollars to survive.");
            }

        }
    }
}
