using System;

namespace _08.FuelTank_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Бензин – 2.22 лева за един литър,
            //•	Дизел – 2.33 лева за един литър
            //•	Газ – 0.93 лева за литър
            const double gasolin = 2.22;
            const double dissel = 2.33;
            const double gas = 0.93;
            string fuel = Console.ReadLine();
            double litersFuel = double.Parse(Console.ReadLine());
            string clubCard = Console.ReadLine();
            double gasolinDiscount = litersFuel * 0.82;
            double disselDiscount = litersFuel * 0.88;
            double gasDiscount = litersFuel * 0.92;
            double price = 0;
            switch (fuel)
            {
                case "Gas":
                    if (litersFuel <= 20)
                    {
                        if (clubCard == "Yes")
                        {
                            price = gas * gasDiscount;
                        }
                        else if (clubCard == "No")
                        {
                            price = gas * litersFuel;
                        }
                    }
                    else if (litersFuel > 20 && litersFuel <= 25)
                    {
                        
                        if (clubCard == "Yes")
                        {
                            price = gas * 0.92 * gasDiscount;
                        }
                        else if (clubCard == "No")
                        {
                            price = gas * litersFuel * 0.92;
                        }                             
                    }
                    else
                    {
                        if (clubCard == "Yes")
                        {
                            price = gas *  0.90 * gasDiscount;
                        }
                        else if (clubCard == "No")
                        {
                            price = gas * litersFuel * 0.90;
                        }
                        Console.WriteLine($"{price:f2} lv.");
                    }
                    break;
                case "Gasoline":
                    if (litersFuel <= 20)
                    {
                        
                        if (clubCard == "Yes")
                        {
                            price = gasolin * gasolinDiscount;
                        }
                        else if (clubCard == "No")
                        {
                            price = gasolin * litersFuel;
                        }         
                    }
                    else if (litersFuel > 20 && litersFuel <= 25)
                    {
                        
                        if (clubCard == "Yes")
                        {
                            price = gasolin  * 0.92 * gasolinDiscount;
                        }
                        else if (clubCard == "No")
                        {
                            price = gasolin * litersFuel * 0.92;
                        }
                    }
                    else
                    {                        
                        if (clubCard == "Yes")
                        {
                            price = gasolin * 0.90 * gasolinDiscount;
                        }
                        else if (clubCard == "No")
                        {
                            price = gasolin * litersFuel * 0.90;
                        }
                        Console.WriteLine($"{price:f2} lv.");
                    }
                    break;
                case "Diesel":
                    if (litersFuel <= 20)
                    {
                        if (clubCard == "Yes")
                        {
                            price = dissel * disselDiscount;
                        }
                        else if (clubCard == "No")
                        {
                            price = dissel * litersFuel;
                        }
                    }
                    else if (litersFuel > 20 && litersFuel <= 25)
                    {
                        if (clubCard == "Yes")
                        {
                            price = dissel * 0.92 * disselDiscount;
                        }
                        else if (clubCard == "No")
                        {
                            price = dissel * litersFuel * 0.92;
                        }
                    }
                    else
                    {
                        if (clubCard == "Yes")
                        {
                            price = dissel * 0.90 * disselDiscount;
                        }
                        else if (clubCard == "No")
                        {
                            price = dissel * litersFuel * 0.90;
                        }
                        Console.WriteLine($"{price:f2} lv.");
                    }
                    break;
                    
            }
            

        }

    }
}
