using System;
using System.Collections.Generic;

namespace InheritanceLecture
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Ball ball = new Ball(new Position(5,6), Direction.Right);

            List<GameObject> objects = new List<GameObject>();
            objects.Add(new Ball(new Position(6,5), Direction.Right));
            objects.Add(new Racket(5, new Position(3,2)));
            objects.Add(new Racket(5, new Position(30,2)));

            foreach (var gameObjct in objects)
            {
                gameObjct.Draw();
            }

        }
    }
}
