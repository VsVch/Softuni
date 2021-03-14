using System;
using System.Collections.Generic;

namespace _08.CollectionHierarchy
{
    public class Program
    {
        static void Main(string[] args)
        {

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            List<int> addInFirstCollection = new List<int>();
            List<int> addInSecondCollection = new List<int>();
            List<int> addInThirdCollection = new List<int>();

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                addInFirstCollection.Add(addCollection.AddColection(input[i]));
                
                addInSecondCollection.Add(addRemoveCollection.AddColection(input[i]));
                
                addInThirdCollection.Add(myList.AddColection(input[i]));               
            }

            int n = int.Parse(Console.ReadLine());

            List<string> removeSecondCollection = new List<string>();
            List<string> removeThirdCollection = new List<string>();

            for (int i = 0; i < n; i++)
            {
                removeSecondCollection.Add(addRemoveCollection.RemoveColection());

                removeThirdCollection.Add(myList.RemoveColection());
            }

            Console.WriteLine(string.Join(" ", addInFirstCollection));
            Console.WriteLine(string.Join(" ", addInSecondCollection));
            Console.WriteLine(string.Join(" ", addInThirdCollection));
            Console.WriteLine(string.Join(" ", removeSecondCollection));
            Console.WriteLine(string.Join(" ", removeThirdCollection));
        }
    }
}
