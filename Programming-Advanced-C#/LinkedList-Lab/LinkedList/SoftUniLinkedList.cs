using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class SoftUniLinkedList
    {
        public Node Head { get; set; }

        public void AddHead(Node node) 
        {
            if (Head == null)
            {
                Head = node;
                return;
            }

            node.Next = Head;
            Head = node;
        
        
        }
    }
}
