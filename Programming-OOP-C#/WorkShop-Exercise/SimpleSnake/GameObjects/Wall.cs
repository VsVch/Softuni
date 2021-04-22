using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
             
        private const char WallSymbol = '\u25A0';
        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
            this.InitializaWallBorder();
        }

        private void InitializaWallBorder()
        {
            this.SetHorizontalLine(0);
            this.SetHorizontalLine(this.TopY);

            this.SetVerticalLine(0);
            this.SetVerticalLine(this.LeftX - 1);
        }

        public bool IsPointOfWall(Point snakPoint) 
        {
            return snakPoint.LeftX == 0 || snakPoint.LeftX == this.LeftX - 1 ||
                snakPoint.TopY == 0 || snakPoint.TopY == this.TopY;
        }

        private void SetHorizontalLine(int topY) 
        {
            for (int leftY = 0; leftY < this.LeftX; leftY++)
            {
                this.Draw(leftY, topY, WallSymbol);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, WallSymbol);
            }
        }
    }
}
