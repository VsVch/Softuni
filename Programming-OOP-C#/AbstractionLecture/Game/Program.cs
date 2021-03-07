using AbstractionLecture.Contract;
using AbstractionLecture.Renderers;
using System;
using System.Collections.Generic;

namespace AbstractionLecture
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IRenderer renderer = new TextRenderer("../../../game.txt");
            Ball ball = new Ball(new Position(5,6), Direction.Right, renderer);

            List<GameObject> objects = new List<GameObject>();
            objects.Add(new Ball(new Position(6,5), Direction.Right, renderer));
            objects.Add(new Racket(5, new Position(2,3), renderer));
            objects.Add(new Racket(5, new Position(2,30), renderer));

            foreach (var gameObjct in objects)
            {
                gameObjct.Draw();
            }

        }
    }
}
