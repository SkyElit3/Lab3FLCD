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

        public void add(string element)
        {
            int hash_value = this.Hash(element);
            HashList[hash_value].add(element);
        }

        public string search(string element)
        {
            int hash_value = this.Hash(element);
            if (HashList[hash_value].size >= 0)
            {
                for (int i = 0; i <= HashList[hash_value].size; i++)
                {
                    MyLinkedElement point = HashList[hash_value].head;
                    if (point.content.Equals(element))
                    {
                        return new string("" + hash_value.ToString() + " " + point.position.ToString());
                    }
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