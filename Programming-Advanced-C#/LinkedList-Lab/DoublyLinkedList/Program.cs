using System;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            SoftUniDoublyLinkedList doublyLinkedList = new SoftUniDoublyLinkedList();
        
            for (int i = 0; i < 20; i++)
            {
                doublyLinkedList.AddHead(new Node(i));
            }
            var currNode = doublyLinkedList.Tail;

            while (currNode != null)
            {
                Console.WriteLine(currNode.Value);
                currNode = currNode.Previus;
            }
        }
    }
}
