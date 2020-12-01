using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _02.ArcheryTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                int[] arr = Console.ReadLine().Split("|").Select(int.Parse).ToArray();

                int points = 0;
                string input = string.Empty;

                while ((input = Console.ReadLine()) != "Game over")
                {
                    string[] commandArr = input.Split("@");

                    if (commandArr[0] != "Reverse" && (int.Parse(commandArr[1]) < 0 || int.Parse(commandArr[1]) >= arr.Length))
                    {
                        continue;
                    }

                    switch (commandArr[0])
                    {
                        case "Shoot Left":
                            int startIndex = int.Parse(commandArr[1]);
                            int length = int.Parse(commandArr[2]) % arr.Length;

                            startIndex = (arr.Length - length + startIndex) % arr.Length;

                            points = TargetSum(arr, points, startIndex);
                            break;
                        case "Shoot Right":
                            startIndex = int.Parse(commandArr[1]);
                            length = int.Parse(commandArr[2]) % arr.Length;

                            startIndex = (startIndex + length) % arr.Length;

                            points = TargetSum(arr, points, startIndex);
                            break;
                        case "Reverse":
                            arr = arr.Reverse().ToArray();
                            break;
                        default:
                            break;
                    }
                }

                Console.WriteLine(string.Join(" - ", arr));
                Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
            }

            static int TargetSum(int[] arr, int points, int startIndex)
            {
                if (arr[startIndex] <= 5)
                {
                    points += arr[startIndex];
                    arr[startIndex] = 0;
                }
                else
                {
                    points += 5;
                    arr[startIndex] -= 5;
                }

                return points;
            }
        }
    }
}
