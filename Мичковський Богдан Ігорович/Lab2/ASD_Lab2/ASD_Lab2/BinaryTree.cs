

namespace ASD_Lab2
{
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Parent { get; set; }
        public int Data;

        public Node(int data)
        {
            Data = data;
            Left = null!;
            Right = null!;
            Parent = null!;
        }
        public class Tree
        {
            public Node Root;
            public Tree()
            {
                Root = null;
            }
            public Tree(int data)
            {
                Root = new Node(data);
            }
            public void Add(int data)
            {
                if (Root == null)
                {
                    Node newtree = new Node(data);
                    Root = newtree;
                    return;
                }

                Node current = Root;
                bool added = false;
                
                do
                {
                    if (data > current.Data)
                    {
                        if (current.Right == null)
                        {
                            if (current != null)
                            {
                                current.Right = new Node(data);
                                current.Right.Parent = current;
                            }

                            added = true;
                        }
                        else
                        {
                            current = current.Right;
                        }

                    }
                    else if (data < current.Data)
                    {
                        if(current.Left == null)
                        {
                            current.Left = new Node(data);
                            current.Left.Parent = current;
                            added = true;
                        }
                        else
                        {
                            current = current.Left;
                        }
                    }
                } while (!added);
            }

            public void FindElement(int data)
            {
                Node temp = Root;
                while (temp.Data != data)
                {
                    if (data < temp.Data)
                    {
                        if (temp.Left != null)
                        {
                            temp = temp.Left;
                        }
                        else break;
                    }
                    else
                    {
                        if (temp.Right != null)
                        {
                            temp = temp.Right;
                        }
                        else break;
                    }
                }
                if (temp.Data == data) Console.WriteLine($"Element {temp.Data} found");
                else Console.WriteLine($"Element {data} not found");
            }

            bool Find(int data)
            {
                Node temp = Root;
                while (temp.Data != data)
                {
                    if (data < temp.Data)
                    {
                        if (temp.Left != null)
                        {
                            temp = temp.Left;
                        }
                        else return false;
                    }
                    else
                    {
                        if (temp.Right != null)
                        {
                            temp = temp.Right;
                        }
                        else return false;
                    }
                }
                return true;
            }

            Node Find(int data, bool bb)
            {
                Node temp = Root;
                while (temp.Data != data)
                {
                    if (data < temp.Data)
                    {
                        temp = temp.Left;
                    }
                    else
                    {
                        temp = temp.Right;
                    }
                }
                return temp;
            }

            Node ToReplace(Node temp)
            {
                if (temp.Data > Root.Data)
                {
                    if (temp.Right != null)
                    {
                        temp = temp.Right;
                        while (temp.Left != null)
                        {
                            temp = temp.Left;
                        }
                    }
                }
                else
                {
                    if (temp.Left != null)
                    {
                        temp = temp.Left;
                        while (temp.Right != null)
                        {
                            temp = temp.Right;
                        }
                    }
                }
                return temp;
            }

            public void MaxElement()
            {
                Node current = Root;
                while (current.Right != null) { current = current.Right; }
                Console.WriteLine($"Max element is {current.Data}");
            }
            public void MinElement()
            {
                Node current = Root;
                while (current.Left != null) { current = current.Left; }
                Console.WriteLine($"Min element is {current.Data}");
            }

            void Transplant(Node t, Node u, Node v)
            {
                if (u.Parent == null)
                    t = v;
                else if(u == u.Parent.Left)
                    u.Parent.Left = v;
                else u.Parent.Right = v;
                if(v != null)
                    v.Parent = u.Parent;   
            }

            public void DeleteElement(int data)
            {
                if (Find(data))
                {
                    Node toDelete = Find(data, true);
                    Node toReplace = ToReplace(toDelete);

                    if (toDelete == null) Console.WriteLine($"Element {data} not exist");
                    else
                    {
                        if (toDelete.Left == null)
                            Transplant(Root, toDelete, toDelete.Right);
                        else if (toDelete.Right == null)
                            Transplant(Root, toDelete, toDelete.Left);
                        else
                        {
                            if (toReplace.Parent != toDelete)
                            {
                                Transplant(Root, toReplace,toDelete);
                                toReplace.Right = toDelete.Right;
                                toReplace.Right.Parent = toReplace;
                            }
                            Transplant(Root, toDelete,toReplace);
                            toReplace.Left = toDelete.Left;
                            toReplace.Left.Parent = toReplace;
                        }
                    }
                }
                else Console.WriteLine($"Element {data} not exist");
            }
            public void DisplayTree()
            {
                if (Root == null)
                {
                    Console.WriteLine("Tree is empty");
                    return;
                }

                InOrder(Root);
                Console.WriteLine();
            }
            private void InOrder(Node current)
            {
                if (current != null)
                {
                    InOrder(current.Left);
                    Console.Write("({0}) ", current.Data);
                    InOrder(current.Right);
                }
            }
        }
    }
}