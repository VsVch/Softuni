using System;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>();

            list.Add(5);
            list.Add(3);

            foreach (var item in list)
            {
                Console.WriteLine("In the foreach");
                Console.WriteLine(item);
            }
        }
    }
}
