using System;

namespace _05.Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            double convert = change * 100;
            int cent = (int)convert;

            int coints = 0;
            while (cent > 0)
            {
                if (cent - 200 > 0)
                {
                    coints++;
                    cent -= 200;
                }
                else if (cent - 100 > 0)
                {
                    coints++;
                    cent -= 100;
                }
                else if (cent - 50 > 0)
                {
                    coints++;
                    cent -= 50;
                }
                else if (cent - 20 > 0)
                {
                    coints++;
                    cent -= 20;
                }
                else if (cent - 10 > 0)
                {
                    coints++;
                    cent -= 10;
                }
                else if (cent - 5 > 0)
                {
                    coints++;
                    cent -= 5;
                }
                else if (cent - 2 > 0)
                {
                    coints++;
                    cent -= 2;
                }
                else if (cent - 1 > 0)
                {
                    coints++;
                    cent -= 1;
                }
               
            }
            Console.WriteLine(coints);
            
        }
    }
}
