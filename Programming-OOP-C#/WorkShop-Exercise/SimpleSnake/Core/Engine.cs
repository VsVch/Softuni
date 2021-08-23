using SimpleSnake.Core.Contracts;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine : IEngine
    {
        private readonly Point[] pointOfDirection;
        private Direction direction;
        private readonly Snake snake;
        private readonly Wall wall;
        private double sleepTime;



        public Engine(Wall wall, Snake snake)
        {
            this.pointOfDirection = new Point[4];
            this.wall = wall;
            this.snake = snake;

            this.sleepTime = 100;
        }

        public void Run()
        {
            this.CreateDirection();

            while (true)
            {

                if (Console.KeyAvailable)
                {
                    this.GetNextDirection();
                }

                bool isMoving = this.snake
                .IsMoving(this.pointOfDirection[(int)this.direction]);

                if (!isMoving)
                {
                    this.AskUserForRestart();
                }

                this.PrintStatisticsInfo();

                sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }
        }

        private void PrintStatisticsInfo()
        {
            int leftX = this.wall.LeftX + 2;
            int topY = 1;

            Console.SetCursorPosition(leftX, topY - 1);
            Console.Write(new string('-', 18));

            Console.SetCursorPosition(leftX, topY);
            Console.Write($"Player points : {this.snake.SnakePoints}");

            Console.SetCursorPosition(leftX, topY + 1);
            Console.Write($"Player level: {this.snake.SnakeLevel}");

            Console.SetCursorPosition(leftX, topY +2);
            Console.Write(new string('-', 18));
        }

        private void CreateDirection() 
        {
            this.pointOfDirection[0] = new Point(1, 0);
            this.pointOfDirection[1] = new Point(-1, 0);
            this.pointOfDirection[2] = new Point(0, 1);
            this.pointOfDirection[3] = new Point(0, -1);
        }

        private void GetNextDirection() 
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (this.direction != Direction.Right)
                {
                    this.direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (this.direction != Direction.Left)
                {
                    this.direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (this.direction != Direction.Down)
                {
                    this.direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (this.direction != Direction.Up)
                {
                    this.direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX + 1;
            int topY = 4;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n");

            Console.SetCursorPosition(leftX, topY + 1);
            Console.Write("Your choice: ");

            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                this.StopGame();
            }
        }
        private void StopGame() 
        {
            Console.SetCursorPosition(10, 10);
            Console.Write("Game over!");
            Environment.Exit(0);
        }
    }
}
