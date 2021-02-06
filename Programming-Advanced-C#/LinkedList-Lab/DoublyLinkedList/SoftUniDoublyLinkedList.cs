using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkedList
{
    class SoftUniDoublyLinkedList
    {
        public Node Head { get; set; }

        public Node Tail { get; set; }

        public void AddHead(Node node) 
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }
            node.Next = Head;
            Head.Previus = node;
            Head = node;
        
        
        }
    }
}
