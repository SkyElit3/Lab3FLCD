using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Lab2FLCD
{
    public class MyHashMap
    {
        public List<MyLinkedList> HashList = new List<MyLinkedList>();
        
        public MyHashMap()
        {
            for (int i = 0; i < 13; i++)
            {
                HashList.Add(new MyLinkedList());
            }
        }
        public int Hash(string key)
        {
            int sum = 0;
            foreach (char c in key)
            {
                int unicode = c;
                sum += unicode;
            }
            return sum % 13;
        }

        public void Add(string element)
        {
            int hashValue = this.Hash(element);
            HashList[hashValue].Add(element);
        }

        public string Search(string element)
        {
            int hashValue = this.Hash(element);
            if (HashList[hashValue].Size >= 0)
            {
                MyLinkedElement point = HashList[hashValue].Head;
                for (int i = 0; i <= HashList[hashValue].Size; i++)
                {
                    
                    if (point.Content.Equals(element))
                    {
                        return new string("" + hashValue.ToString() + " " + point.Position.ToString());
                    }

                    point = point.Next;
                }
            }
            return "Not found !";
        }

        public override string ToString()
        {
            string total = new string("");
            for (int i = 0; i < 13; i++)
            {
                total += i.ToString() + " - " + HashList[i].ToString() + Environment.NewLine;
            }

            return total;
        }
    }
}