using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.Foods
{
    public class FoodHash : Food
    {
        private const char FoodSymbol = '#';
        private const int Points = 2;
        public FoodHash(Wall wall)
            : base(wall, FoodSymbol, Points, ConsoleColor.Blue)
        {
        }
    }
}
