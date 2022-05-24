using System;

namespace AvlTree
{
    public class AvlTreeNote<T> where T : IComparable<T>
    {
        public T Key;
        public int Height;
        public AvlTreeNote<T> LChild;
        public AvlTreeNote<T> RChild;

        public AvlTreeNote(T key, AvlTreeNote<T> lChild, AvlTreeNote<T> rChild)
        {
            Key = key;
            LChild = lChild;
            RChild = rChild;
        }
    }
}