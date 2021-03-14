using System;

namespace _02.SummerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            //int degrees = int.Parse(Console.ReadLine());
            //string time = Console.ReadLine();
            //if (degrees >= 10 &&  degrees <= 18)
            //{
            //    switch (time)
            //    {
            //        case "Morning":
            //            Console.WriteLine($"It's {degrees} degrees, get your Sweatshirt and Sneakers.");
            //            break;
            //        case "Afternoon":
            //            Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");
            //            break;
            //        case "Evening":
            //            Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");
            //            break;
            //    }
            //}
            //else if (degrees > 18 && degrees <= 24)
            //{
            //    switch (time)
            //    {
            //        case "Morning":
            //            Console.WriteLine($"It's {degrees} degrees, get your Sweatshirt and Sneakers.");
            //            break;
            //        case "Evening":
            //            Console.WriteLine($"It's {degrees} degrees, get your Sweatshirt and Sneakers.");
            //            break;
            //        case "Afternoon":                    
            //            Console.WriteLine($"It's {degrees} degrees, get your T-Shirt and Sandals.");
            //            break;
            //    }
            //}
            //else if (degrees >= 25)
            //{
            //    switch (time)
            //    {
            //        case "Morning":
            //            Console.WriteLine($"It's {degrees} degrees, get your T-Shirt and Sandals.");
            //            break;
            //        case "Afternoon":                  
            //            Console.WriteLine($"It's {degrees} degrees, get your Swim Suit and Barefoot.");
            //            break;
            //        case "Evening":                    
            //            Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");
            //            break;
            //    }
            // }

            int degrees = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            string outfit = "";
            string shoes = "";
            if (degrees >= 10 && degrees <= 18)
            {
                if (timeOfDay == "Morning")
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (timeOfDay == "Afternoon" || timeOfDay == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }                 
            }
            else if (degrees > 18 && degrees <= 24)
            {
                if (timeOfDay == "Morning" ||timeOfDay == "Evening")
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (timeOfDay == "Afternoon")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }         
            }
            else if (degrees >= 25)
            {
                if (timeOfDay == "Morning")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (timeOfDay == "Afternoon")
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
                else if (timeOfDay == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
             
            }
            Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");

        }

    }
}
