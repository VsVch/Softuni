using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.Foods
{
    public class FoodDollar : Food
    {
        private const char FoodSymbol = '$';
        private const int Points = 2;
        public FoodDollar(Wall wall)
            : base(wall, FoodSymbol, Points,ConsoleColor.Green)
        {
        }
    }
}
