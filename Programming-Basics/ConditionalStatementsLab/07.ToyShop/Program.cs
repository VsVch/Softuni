using System;

namespace _07.ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averegeProgres = double.Parse(Console.ReadLine()); ;
            double minPaychek = double.Parse(Console.ReadLine());
            double onlySocialIncome = Math.Floor(minPaychek * 0.35);
            double shoolarShipForExelentResult = Math.Floor(averegeProgres * 25);
            if (income >= minPaychek && averegeProgres >= 5.50)
            {

                Console.WriteLine($"You get a scholarship for excellent results {shoolarShipForExelentResult} BGN ");
            }
            else if (income >= minPaychek && averegeProgres < 5.50)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (income < minPaychek && averegeProgres >= 5.50 && onlySocialIncome <= shoolarShipForExelentResult)
            {
                Console.WriteLine($"You get a Social scholarship {onlySocialIncome} BGN ");
            }
            else if (income < minPaychek && averegeProgres > 4.50 && onlySocialIncome <= shoolarShipForExelentResult)
            {
                Console.WriteLine($"You get a scholarship for excellent results {shoolarShipForExelentResult} BGN");
            }
            else if (income < minPaychek && averegeProgres > 4.50)
            {
                Console.WriteLine($"You get a Social scholarship {onlySocialIncome} BGN ");
            }
            else if (income < minPaychek && averegeProgres <= 4.50)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
           


                    
        }
    }
}
