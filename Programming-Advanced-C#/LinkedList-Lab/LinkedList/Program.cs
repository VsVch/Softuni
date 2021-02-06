using System;

namespace LinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            SoftUniLinkedList linkedList = new SoftUniLinkedList();

            linkedList.AddHead(new Node(1));
            linkedList.AddHead(new Node(2));
            linkedList.AddHead(new Node(3));
            linkedList.AddHead(new Node(4));

            var currNode = linkedList.Head;

            while (currNode != null)
            {
                Console.WriteLine(currNode.Value);
                currNode = currNode.Next;
            }
        }
    }
}
