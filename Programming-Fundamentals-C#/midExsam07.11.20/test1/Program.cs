using System;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            double bugget = double.Parse(Console.ReadLine());
            int numStudents = int.Parse(Console.ReadLine());
            double flourPrice = double.Parse(Console.ReadLine());
            double oneEggPrice = double.Parse(Console.ReadLine());
            double oneApronPrice = double.Parse(Console.ReadLine());

            double apronsNeeded = Math.Ceiling( numStudents + 1.0 * numStudents * 20 / 100) * oneApronPrice;
            double eggsNeeded = oneEggPrice * 10 * numStudents;
            double totalFlour = flourPrice * (numStudents - (numStudents / 5));                                   
            double totallPrice = apronsNeeded + eggsNeeded + totalFlour;
       
            if (bugget >= totallPrice)
            {
                Console.WriteLine($"Items purchased for {totallPrice:f2}$.");
            }
            else
            {
                double moneyNeeded = totallPrice - bugget;
                Console.WriteLine($"{moneyNeeded:f2}$ more needed.");
            }
           
        }
    }
}
