using Composite.Components;
using CompositePattern.Components;
using System;
using System.Threading;

namespace Composite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IComponent page = new Component(new Position(0, 0));


            //rectangle.Draw();

            page.Add(new Rectangle(new Position(45, 10), 10));

            IComponent rec = BuildRec(new Position(0, 0));
            IComponent rec2 = BuildRec(new Position(30, 10));

            page.Add(rec);            

            page.Draw();

            while (true)
            {
                Position position = new Position(1, 1);
                Console.Clear();
                rec.Move(position);
                page.Draw();
                Thread.Sleep(500);
            }

            Console.ReadLine();
        }

        public static IComponent BuildRec(Position pos)
        {
            IComponent rec = new Rectangle(new Position(15 + pos.X, 5 + pos.Y), 10);
            rec.Add(new Text(new Position(25 +pos.X, 5 + pos.Y), "Composite is cool"));
            rec.Add(new Text(new Position(35 + pos.X, 2 + pos.Y), "SomeText"));
            rec.Add(new Text(new Position(70 + pos.X, 9 + pos.Y), "3"));
            rec.Add(new Text(new Position(5 + pos.X, 8 + pos.Y), "4141"));

            return rec;
        }
    }
}
