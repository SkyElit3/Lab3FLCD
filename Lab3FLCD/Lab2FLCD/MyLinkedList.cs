using System;

namespace Lab2FLCD
{
    public class MyLinkedList
    {
        public int size = -1;
        public MyLinkedElement head;

        public MyLinkedList()
        {
            head = null;
        }

        public void add(string element)
        {
            if (head is null)
            {
                head = new MyLinkedElement();
                head.content = element;
                size++;
                head.position = size;
            }
            else
            {
                MyLinkedElement point = head;
                while (point.next != null)
                {
                    point = point.next;
                }
                point.next = new MyLinkedElement();
                point.next.content = element;
                size++;
                point.next.position = size;
            }
        }

        public override string ToString()
        {
            if (size == -1)
                return "";
            string total = new string("");
            total += "["+ head.position.ToString() + " --- " + head.content + "]";
            MyLinkedElement point = head;
            while (point.next != null)
            {
                point = point.next;
                total += "[" + point.position.ToString() + " --- " + point.content + "]";
            }

            return total;
        }
    }
}