using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class SoftUniLinkedList
    {

        private int count = 0;
        public int Value { get; set; }

        public Node Head { get; set; }

        public Node Tail { get; set; }

        public int[] ToMyArray() 
        {
            int index = 0;
            int[] array = new int[count];

            ForeachFromHead((node) =>
            {
                array[index] = node.Value;
                index++;            
            });
            return array;       
        
        }


        public void ForeachFromHead(Action<Node> action)
        {
            Node currNode = Head;

            while (currNode != null)
            {
                action(currNode);
                currNode = currNode.Next;
            }        
        }

        public void ForeachFromTail(Action<Node> action)
        {
            Node currNode = Tail;

            while (currNode != null)
            {
                action(currNode);
                currNode = currNode.Privius;                    
            }
        }

        public void AddHead(Node node)
        {
            count++;

            if (Head == null)
            {
                Head = node;                    
                Tail = node;
                return;
            }
            node.Next = Head;
            Head.Privius = node;
            Head = node;           
        }

        public void AddLast(Node node) 
        {
            count++;

            if (Tail == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            node.Privius = Tail;
            Tail.Next = node;
            Tail = node;
        }
        public Node RemoveHead() 
        {
            
            if (Head == null)
            {
                return null;
            }

            var noteToreturn = Head;
            count--;

            if (Head.Next != null)
            {
                Head = Head.Next;
                Head.Privius = null;

            }
            else
            {
                Head = null;
                Tail = null;
            }
            return noteToreturn;       
        
        }

        public Node RemoveTail()
        {

            if (Tail == null)
            {
                return null;
            }
            
            var noteToreturn = Tail;
            count--;

            if (Tail.Privius != null)
            {
                Tail = Tail.Privius;
                Tail.Next = null;

            }
            else
            {
                Tail = null;
                Head = null;
            }
            return noteToreturn;
        }
    }
}
