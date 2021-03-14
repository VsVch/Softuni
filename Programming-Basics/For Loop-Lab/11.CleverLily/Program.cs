using System;

namespace _11.CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMashine = double.Parse(Console.ReadLine());
            double priceOfToys = double.Parse(Console.ReadLine());
            int toyscount = 0;
            double savedMoney = 0;
            int temp = 10;
            
            for (int i = 1; i <= age; i++)
            {
               
                if (i % 2 != 0)
                {
                    toyscount++;
                }
                else
                {
                    savedMoney += temp;
                    temp += 10;

                }

            }
            savedMoney -= age / 2;
            savedMoney += toyscount * priceOfToys;
            double totallMoneyLeft = Math.Abs(savedMoney - washingMashine);
            if (savedMoney >= washingMashine)
            {
                Console.WriteLine($"Yes! {totallMoneyLeft:f2}");
            }
            else
            {
                
                Console.WriteLine($"No! {totallMoneyLeft:f2}");
            }
        }
    }
}
