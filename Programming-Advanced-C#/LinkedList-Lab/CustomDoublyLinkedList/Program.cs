using System;

namespace CustomDoublyLinkedList
{
    public class Startup
    {
        static void Main(string[] args)
        {
            Node node = new Node(1);

            SoftUniLinkedList linkedList = new SoftUniLinkedList();

            linkedList.RemoveHead();

            for (int i = 0; i < 10; i++)
            {
                linkedList.AddHead(new Node(i));
            }

            for (int i = 0; i < 10; i++)
            {
                linkedList.AddLast(new Node(i));
            }

            Console.WriteLine(linkedList.RemoveHead().Value);
            Console.WriteLine(linkedList.RemoveHead().Value);
            Console.WriteLine(linkedList.RemoveHead().Value);

            Console.WriteLine("----------------");

            Console.WriteLine(linkedList.RemoveTail().Value);
            Console.WriteLine(linkedList.RemoveTail().Value);
            Console.WriteLine(linkedList.RemoveTail().Value);
            Console.WriteLine("----------------");

            var curNode = linkedList.Head;

            //while (curNode != null)
            //{
            //    Console.WriteLine(curNode.Value);
            //    curNode = curNode.Next;
            //}

            linkedList.ForeachFromHead((node) =>
            {
                Console.WriteLine($"{node.Value}");
            });

            Console.WriteLine("----------------");

            linkedList.ForeachFromTail((node) =>
            {
                Console.WriteLine($"{node.Value}");
            });

            int[] linkedListToArray = linkedList.ToMyArray();

            foreach (var item in linkedListToArray)
            {
                Console.WriteLine($"My number {item}");
            }
        }
    }
}
