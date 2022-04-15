using System.Diagnostics;

namespace Lab_1_ASD
{
    internal class Node
    {
        public int CountNode;
        public int elem;
        public Node next_ind;
        Node head;


        public Node() 
        {
            head = null;
            CountNode = 0;
        }  
        public Node(int data)
        {
            elem = data;
            next_ind = null;
        }
        


        public void AddFront(int data)
        {
            Node node = new Node(data);
            node.next_ind = head;
            head = node;
            CountNode++;
        }

        public void PrintList()
        {
            Node temp = head;
            Console.Write("[ ");
            while (temp != null)
            {
                Console.Write(temp.elem + " ");
                temp = temp.next_ind;
            }
            Console.WriteLine("]");
        }
        public void AddLast(int data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = new Node(data);
                return;
            }

            newNode.next_ind = null;
            Node last = head;
            while (last.next_ind != null)
                last = last.next_ind;
            last.next_ind = newNode;
        }
        public void Linear(int data)
        {
            var time = new Stopwatch();
            time.Start();
            Node temp = head;
            bool found = false;
            while (temp != null && found != true)
            {
                if (temp.elem == data)
                {
                    Console.WriteLine("Node found: " + temp.elem);
                    found = true;
                    time.Stop();
                    Console.WriteLine("Time spent: " + time.Elapsed);
                    break;

                }
                temp = temp.next_ind;
            }
            if (found == false)
            {
                Console.WriteLine("Num not found");
                time.Stop();
                Console.WriteLine("Time spent: " + time.Elapsed);
            }
        }
        public void Barrier(int data)
        {
            var time = new Stopwatch();
            time.Start();
            Node temp = head;
            int count = 0;
            while (temp.elem != data)
            {
                temp = temp.next_ind;
                count++;
            }
            Console.WriteLine("Node found index: " + count);
            time.Stop();
            Console.WriteLine("Time spent: " + time.Elapsed);
        }

        static Node Midd(Node first, Node last)
        {
            Node mid = first;
            Node temp = first.next_ind;

            while (temp != last)
            {
                temp = temp.next_ind;
                if (temp != last)
                {
                    temp = temp.next_ind;
                    mid = mid.next_ind;
                }
            }
            return mid;
        }
        static Node FindNode(Node head, int ind)
        {
            Node find = head;
            int count = 0;
            while (count != ind && find != null)
            {
                find = find.next_ind;
                count++;
            }
            return find;
        }
        public int Size()
        {
            Node node = head;
            int count = 0;
            while (node != null)
            {
                count++;
                node = node.next_ind;
            }

            return count;
        }
        public void LinkSortChoose()
        {
            Node first = head;
            Node second = first.next_ind;

            while (first != null)
            {
                while (second != null)
                {
                    if (first.elem > second.elem)
                    {
                        int temp = first.elem;
                        first.elem = second.elem;
                        second.elem = temp;
                    }
                    second = second.next_ind;
                }
                first = first.next_ind;
                if (first.next_ind == null) { break; }
                else { second = first.next_ind; }
            }
        }
        public void Binary(int data)
        {
            var time = new Stopwatch();
            time.Start();
            Node first = head;
            Node last = null;
            bool found = false;

            while (last != first)
            {
                Node mid = Midd(first, last);
                if (mid.elem == data)
                {
                    Console.WriteLine("Node found : " + mid.elem);
                    found = true;
                    time.Stop();
                    Console.WriteLine("Time spent: " + time.Elapsed);
                    break;
                }
                else if (mid.elem < data)
                {
                    first = mid.next_ind;
                }
                else
                {
                    last = mid;
                }
            }
            if (found == false)
            {
                Console.WriteLine("Num not found");
                time.Stop();
                Console.WriteLine("Time spent: " + time.Elapsed);
            }
        }
        public void BinaryGolden(int data, int size)
        {
            var time = new Stopwatch();
            time.Start();
            Node first = head;
            Node last = null;
            bool found = false;
            int start = 0;
            int end = size;

            while (last != first)
            {
                int mid = (int)(start + (end - start) / 1.6);

                Node node = FindNode(head, mid);


                if (node.elem == data)
                {
                    Console.WriteLine("Node found : " + node.elem);
                    found = true;
                    time.Stop();
                    Console.WriteLine("Time spent: " + time.Elapsed);
                    break;
                }
                else if (node.elem < data)
                {
                    first = node.next_ind;
                    start = mid + 1;
                }
                else
                {
                    last = node;
                    end = mid - 1;
                }
            }
            if (found == false)
            {
                Console.WriteLine("Num not found");
                time.Stop();
                Console.WriteLine("Time spent: " + time.Elapsed);
            }
        }
    }
}
