using System;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Dice dice = new Dice() 
            { Side = 5, Color = "red",Player = new Player("Gogi") };
            Console.WriteLine(dice.Side);
            Console.WriteLine(dice.Color);

            Dice dice2 = (Dice)dice.Clone();
            dice2.Player.Name = "Pesho";
            dice2.Side = 6;

            Console.WriteLine(dice2.Side);
            Console.WriteLine(dice.Side);

            Console.WriteLine(dice2.Player.Name);

            Console.WriteLine($"Dice 1 player: {dice.Player.Name}");
            Console.WriteLine($"Dice 2 player: {dice2.Player.Name}");
        }
    }
}
