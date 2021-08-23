using SimpleSnake.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const int SnakeStartLenght = 6;
        private const char SnakeSymbol = '\u25CF';
        private const char EmptySpaceSymbol = ' ';

        private readonly Food[] foods;

        private readonly Queue<Point> snakeElements;        
        private readonly Wall wall;
        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;
       

        private bool isFoodSpawned;
        private int snakePoints;
        private int levelCounter;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeElements = new Queue<Point>();
            this.foods = new Food[3];            
            this.foodIndex = RandomFoodNumber;

            this.isFoodSpawned = false;
            this.snakePoints = 6;
            this.levelCounter = 100;

            this.GetFoods();
            this.CtreateSnake();
        }

        public int SnakePoints => this.snakePoints;

        public int SnakeLevel => levelCounter / 100;

        private int RandomFoodNumber => new Random().Next(0, this.foods.Length);

        public bool IsMoving(Point direction) 
        {
            
            Point currentSnakeHead = this.snakeElements.Last();

            GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = this.snakeElements
                .Any(p => p.LeftX == this.nextLeftX && p.TopY == this.nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point newSnakeHead = new Point(this.nextLeftX, this.nextTopY);

            if (this.wall.IsPointOfWall(newSnakeHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(newSnakeHead);
            newSnakeHead.Draw(SnakeSymbol);

            if (!this.isFoodSpawned)
            {
                this.foods[foodIndex].SetRandomPosition(this.snakeElements);
                this.isFoodSpawned = true;
            }

            if (foods[this.foodIndex].IsFoodPoint(newSnakeHead))
            {
                this.Eat(direction, currentSnakeHead);
            }
            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(EmptySpaceSymbol);

            levelCounter++;

            return true;

        }

        private void Eat(Point direction, Point currentSnakeHead) 
        {
            int length = this.foods[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue
                    (new Point(this.nextLeftX, this.nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }

            this.snakePoints += length;

            this.foodIndex = RandomFoodNumber;
            this.foods[foodIndex].SetRandomPosition(this.snakeElements);
        }

        private void GetNextPoint(Point direction, Point snakeHead)         
        {
            this.nextLeftX = direction.LeftX + snakeHead.LeftX;
            this.nextTopY = direction.TopY + snakeHead.TopY;
        }

        private void CtreateSnake() 
        {
            for (int topY = 1; topY <= SnakeStartLenght; topY++)
            {
                this.snakeElements.Enqueue(new Point(2, topY));
            }
        }

        private void GetFoods() 
        {
            //Assembly assembly = Assembly.GetExecutingAssembly();

            //Type[] foodType = assembly
            //    .GetTypes()
            //    .Where(t => t.Name.StartsWith("Food"))
            //    .ToArray();
            //int counter = 0;
            //foreach (var food in foodType)
            //{
            //    var curFood =(Food)Activator.CreateInstance(food);
            //    counter++;
            //    foods[counter] = curFood;
            //}

            this.foods[0] = new FoodHash(this.wall);
            this.foods[1] = new FoodDollar(this.wall);
            this.foods[2] = new FoodAsterisk(this.wall);
        }


    }
}
