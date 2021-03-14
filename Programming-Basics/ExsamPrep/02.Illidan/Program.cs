using System;

namespace _02.Illidan
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPeoples = int.Parse(Console.ReadLine());
            int straightOfonePerson = int.Parse(Console.ReadLine());
            int blodeOfIlidan = int.Parse(Console.ReadLine());
            int overalStraightOfplayers = numberPeoples * straightOfonePerson;
            if(blodeOfIlidan > overalStraightOfplayers)
            {
                int bloodNeeded = blodeOfIlidan - overalStraightOfplayers;
                Console.WriteLine($"You are not prepared! You need {bloodNeeded} more points.");
            }
            else if (blodeOfIlidan <= overalStraightOfplayers)
            {
                int blodLeft = overalStraightOfplayers - blodeOfIlidan;
                Console.WriteLine($"Illidan has been slain! You defeated him with {blodLeft} points.");
            }

        }
    }
}
