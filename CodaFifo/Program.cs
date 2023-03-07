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
            MyStack stack = new MyStack();
            stack.Push("B");
            stack.Push("A");
            Console.WriteLine(stack);

            Console.WriteLine(stack.getInverseOrder());


            Console.WriteLine(stack);
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

    public class MyStack
    {

        private Node Top { get; set; }

        public MyStack()
        {
            Top = null;
        }

        public void Push(string element)
        {

            Node tmp = new Node(element);

            tmp.Next = Top;

            Top = tmp;

        }

        public string Pop()
        {

            if (Top == null)
            {
                throw new Exception("empty stack");
            }

            string tmp = Top.Element;
            Top = Top.Next;

            return tmp;
        }

        public string getTop()
        {
            if (Top == null)
            {
                throw new Exception("empty stack");
            }
            return Top.Element;
        }

        public override string ToString()
        {
            Node iterator = Top;
            string s = "-\n";
            while (iterator != null)
            {
                s += iterator.Element + "\n";
                iterator = iterator.Next;
            }
            s += "-";
            return s;
        }

        public string getInverseOrder()
        {


            MyStack temp = new MyStack();
            while (this.Top != null)
            {
                temp.Push(this.Pop());
            }

            string s = temp.ToString();

            while (temp.Top != null)
            {
                this.Push(temp.Pop());
            }

            return s;
        }

    }

}
