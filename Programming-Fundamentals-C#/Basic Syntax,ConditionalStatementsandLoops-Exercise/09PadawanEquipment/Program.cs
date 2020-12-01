using System;

namespace _09PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightSable = double.Parse(Console.ReadLine());
            double priceOfRobe = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());
            double priceOfallRobes = priceOfRobe * countOfStudents;
            double priceOfAllLightSable = Math.Ceiling(countOfStudents * 1.1) * priceOfLightSable;
            int countOfBels = 0;
            for (int i = 1; i <= countOfStudents; i++)
            {
                if (i % 6 == 0)
                {

                }
                else
                {
                    countOfBels ++;
                }
            }
            double priceOfAllBelts = countOfBels * priceOfBelts;
            double totalPrice = priceOfAllBelts + priceOfAllLightSable + priceOfallRobes;

            if (amountOfMoney >= totalPrice)
            {
                
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                double moneyNeed = totalPrice - amountOfMoney;
                Console.WriteLine($"Ivan Cho will need {moneyNeed:f2}lv more.");
            }
            
            



        }
    }
}
