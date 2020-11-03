using System;

namespace Lab2FLCD
{
    public class MyLinkedList
    {
        public int Size = -1;
        public MyLinkedElement Head;

        public MyLinkedList()
        {
            Head = null;
        }

        public void Add(string element)
        {
            if (Head is null)
            {
                Head = new MyLinkedElement();
                Head.Content = element;
                Size++;
                Head.Position = Size;
            }
            else
            {
                MyLinkedElement point = Head;
                while (point.Next != null)
                {
                    point = point.Next;
                }
                point.Next = new MyLinkedElement();
                point.Next.Content = element;
                Size++;
                point.Next.Position = Size;
            }
        }

        public override string ToString()
        {
            if (Size == -1)
                return "";
            string total = new string("");
            total += "["+ Head.Position.ToString() + " --- " + Head.Content + "]";
            MyLinkedElement point = Head;
            while (point.Next != null)
            {
                point = point.Next;
                total += "[" + point.Position.ToString() + " --- " + point.Content + "]";
            }

            return total;
        }
    }
}