using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Console_Lab1
{
    public class Item<T>
    {
        public Item(T dt)
        {
            Data = dt;
        }

        public readonly T Data;
        public Item<T> Next;
    }

    public partial class LinkedList<T>: IEnumerable<T>
    {
        private Item<T> _head;
        private Item<T> _tail;
        private int _count;

        public void AddLast(T data)
        {
            Item<T> item = new Item<T>(data);
 
            if (_head == null)
                _head = item;
            else
                _tail.Next = item;
            _tail = item;
 
            _count++;
        }

        public Item<T> Get(int index)
        {
            Item<T> current = _head;
            int count = 0;

            while (current != null) {
                if (count == index)
                    return current;
                count++;
                current = current.Next;
            }

            Debug.Assert(false);
            return current;
        }

        public int Count => _count;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
 
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Item<T> current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}