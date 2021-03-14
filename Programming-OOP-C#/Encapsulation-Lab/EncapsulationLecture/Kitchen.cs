using System;
using System.Collections.Generic;
using System.Text;

namespace EncapsulationLecture
{
    public class Kitchen
    {
        private int meat;
        private int garlic;
        private int onion;

        public Kitchen()
        {
            this.meat = 100;
            this.garlic = 100;
            this.onion = 100;
        }
        public bool MeatballsLeft
        {
            get
            {
                return meat >= 10 && garlic >= 3;
            }
        }
        public  void OrderMeatball() 
        {
            if (CookMeatball())
            {
                Console.WriteLine("Meatball cooked");
            }
            else
            {
                Console.WriteLine("Not enough materials for a meatball");
            }
        
        }

        private bool CookMeatball() 
        {
            Console.WriteLine("Meatball being cooked");
            if (meat < 10 || garlic < 3 || onion < 3)
            {
                return false;
            }
            meat -= 10;
            garlic -= 3;
            onion -= 3;

            Console.WriteLine("MeatBall being put in plate"); 

            return true;
        }
    }
}
