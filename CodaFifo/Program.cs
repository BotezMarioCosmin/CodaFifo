using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodaFifo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyQueue queue = new MyQueue();
            queue.Enqueue("primo");
            queue.Enqueue("secondo");
            queue.Enqueue("terzo");
            Console.WriteLine(queue.ToString());

            queue.Dequeue();
            Console.WriteLine(queue.ToString());

            Console.WriteLine(queue.getHead());
            Console.ReadKey();
        }

    }

    public class Node
    {

        public Node(string element)
        {
            Element = element;
            Next = null;
        }

        public string Element { get; set; }

        public Node Next { get; set; }

        public override string ToString()
        {
            return "{" + Element + "}";
        }

    }

    public class MyQueue
    {
        private Node Head { get; set; }

        public MyQueue()
        {
            Head = null;
        }

        public void Enqueue(string element)
        {
            if (Head == null)
            {
                Head = new Node(element);
            }
            else
            {
                Node tmp = Head;

                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }

                tmp.Next = new Node(element);
            }
        }

        public string Dequeue()
        {
            Node tmp = Head;

            while (tmp.Next != null)
            {
                if (tmp.Next.Next == null)
                {
                    Node remove = tmp.Next;
                    tmp.Next = null;
                    return remove.Element;
                }
                tmp = tmp.Next;
            }

            Head = null;
            return tmp.Element;
        }

        public string getHead()
        {
            return Head.Element;
        }

        public override string ToString()
        {
            if (Head == null)
            {
                return "[]";
            }

            string final = "[";
            Node tmp = Head;

            while (tmp != null)
            {
                final += tmp.Element;
                if (tmp.Next != null)
                {
                    final += ", ";
                }
                tmp = tmp.Next;
            }

            final += "]";

            return final;
        }
    }
}
