using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD1_AvruschenkoTest
{
    internal class Node
    {
        public int Count { get; set; }
        public int Data { get; set; }
        private Node next_ind;
        private Node head;
        public Node()
        {
            Count = 0;
            head = null;
            next_ind = null;
        }
        public Node(int data)
        {
            Data = data;
            next_ind = null;
        }
        public void AddLast(int data)
        {
            Count++;
            if (head == null) { head = new Node(data); }
            else
            {

                Node last = head;
                while (last.next_ind != null) { last = last.next_ind; }
                last.next_ind = new Node(data);
            }
        }

        public int this[int index]
        {
            get
            {
                int counter = 0;
                Node current = head;
                while (current != null)
                {
                    if (counter == index)
                    {
                        return current.Data;
                    }
                    current = current.next_ind;
                    counter++;
                }
                return -1;
            }
            set
            {
                int counter = 0;
                Node current = head;
                while (current != null)
                {
                    if (counter == index)
                    {
                        current.Data = value;
                    }
                    current = current.next_ind;
                    counter++;
                }
            }
        }
        
    }
}
