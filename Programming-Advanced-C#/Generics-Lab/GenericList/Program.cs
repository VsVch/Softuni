using System;

namespace GenericList
{
     public class Program
    {
        static void Main(string[] args)
        {

            GenericList<string> stringList = new GenericList<string>();

            stringList.Add("gogi");

            Console.WriteLine(stringList.GetAt(0));

            GenericList<int> list = new GenericList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            Console.WriteLine(list.GetAt(0));
            Console.WriteLine(list.GetAt(1));
            Console.WriteLine(list.GetAt(2));

            
        }
    }
}
