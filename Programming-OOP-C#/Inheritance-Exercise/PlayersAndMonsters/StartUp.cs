using System;
namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoulMaster soulMaster = new SoulMaster("Sand", 78);

            Console.WriteLine(soulMaster.ToString());
            Console.WriteLine(soulMaster.ManaPoint);
        }
    }
}