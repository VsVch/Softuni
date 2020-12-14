using System;

namespace _05.Ligin
{
    class Program
    {
        static void Main(string[] args)
        {
            //string userName = Console.ReadLine();
            //string corectPassword = string.Empty;
            //for (int i = userName.Length - 1; i >= 0; i--)
            //{
            //    corectPassword += userName[i];
            //}

            //bool sTop = false;
            //int counter = 0;
            //string laslPassword = " ";
            //while (sTop != true)
            //{
            //    string curentPassword = Console.ReadLine();

            //    if (corectPassword != curentPassword)
            //    {
            //        counter++;
            //        laslPassword = curentPassword;
            //        if (counter >= 4)
            //        {
            //            Console.WriteLine($"User {userName} blocked!");
            //            sTop = true;
            //            Environment.Exit(0);
            //        }
            //        Console.WriteLine($"Incorrect password. Try again.");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"User {userName} logged in.");
            //        sTop = true;
            //        Environment.Exit(0);                   
            //    }
            // }
            string userName = Console.ReadLine();
            string password = string.Empty;
            int count = 0;
            for (int i = userName.Length - 1; i >= 0; i--)
            {
                password += userName[i];
            }
            while (true)
            {
                string currentUser = Console.ReadLine();
                if (password != currentUser)
                {
                    count++;
                    if (count == 4)
                    {
                        Console.WriteLine($"User {userName} blocked!");
                        break;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }
                else
                {
                    Console.WriteLine($"User {userName} logged in.");
                    break;
                }
            }
        }
    }
}
