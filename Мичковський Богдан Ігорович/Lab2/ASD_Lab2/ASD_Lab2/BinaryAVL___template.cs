namespace ASD_Lab2
{
    public class BinaryAVL___template
    {
        public class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Parent { get; set; }
            public int Data;
            public int Height;

            public Node(int data, Node parent = null)
            {
                Data = data;
                Left = null;
                Right = null;
                Parent = parent;
                Height = 1;
            }

            public Node()
            {
                Left = null;
                Right = null;
                Parent = null;
            }
        }

        public class AVL
        {
            public Node Root;
            
            public AVL()
            {
            }
            
            public void AddElement(int data)
            {
                Add(data, Root);
                Balance(data, Root);
            }
            public void Add(int data, Node tree)
            {
                if (Root == null)
                {
                    tree = new Node(data);
                    Root = tree;
                }
                else if (data < tree.Data)
                {
                    if (tree.Left != null)
                        Add(data, tree.Left);
                    else tree.Left = new Node(data, tree);
                }
                else if (data > tree.Data)
                {
                    if (tree.Right != null)
                        Add(data, tree.Right);
                    else tree.Right = new Node(data, tree);
                }
                else return;

                tree.Height = 1 + Math.Max(Height(tree.Left), Height(tree.Right));
                
                tree = Balance(data, tree);
            }
            int HeightDifference(Node temp)
            {
                if (temp == null) return 0;
                return Height(temp.Left) - Height(temp.Right);
            }

            int Height(Node temp)
            {
                if (temp == null) return 0;
                return temp.Height;
            }

            public Node Balance(int data, Node tree)
            {
                int balance = HeightDifference(tree);
            
                if (balance > 1 &&  data - tree.Left.Data < 0)
                    tree = RightRotate(tree);
                if (balance < -1 && data - tree.Right.Data > 0)
                    tree = LeftRotate(tree);
            
                if (balance > 1 && data - tree.Left.Data < 0)
                {
                    tree.Left = LeftRotate(tree.Left);
                    tree = RightRotate(tree);
                }
                if (balance < -1 && data - tree.Right.Data > 0)
                {
                    tree.Right = RightRotate(tree.Right);
                    tree = LeftRotate(tree);
                }
                
                return tree;
            }
            Node LeftRotate(Node current)
            {
                Node tochange = current.Right;
                current.Right = tochange.Left;

                if (tochange.Left != null)
                    tochange.Left.Parent = current;
                tochange.Parent = current.Parent;
                if (current.Parent == null)
                    Root = tochange;
                else if (current == current.Parent.Left)
                    current.Parent.Left = tochange;
                else current.Parent.Right = tochange;


                tochange.Left = current;
                current.Parent = tochange;


                current.Height = Math.Max(Height(current.Left), Height(current.Right)) + 1;
                tochange.Height = Math.Max(Height(tochange.Left), Height(tochange.Right)) + 1;

                return tochange;


                /*
                Node temp1 = current.Right;
                Node temp2 = temp1.Left;

                temp1.Left = current;
                current.Right = temp2;

                current.Height = Math.Max(Height(current.Left), Height(current.Right));
                temp1.Height = Math.Max(Height(current.Left), Height(current.Right));
                
                return temp1;
                */
            }
            Node RightRotate(Node current)
            {
                Node tochange = current.Left;
                current.Left = tochange.Right;

                if (tochange.Right != null)
                    tochange.Right.Parent = current;

                tochange.Parent = current.Parent;
                if (current.Parent == null)
                    Root = tochange;
                else if (current == current.Parent.Right)
                    current.Parent.Right = tochange;
                else current.Parent.Left = tochange;
                
                tochange.Right = current;
                current.Parent = tochange;

                current.Height = Math.Max(Height(current.Left), Height(current.Right)) + 1;
                tochange.Height = Math.Max(Height(tochange.Left), Height(tochange.Right)) + 1;

                return tochange;
                

                /*
                Node temp1 = current.Left;
                Node temp2 = temp1.Left;

                temp1.Right = current;
                current.Left = temp2;

                current.Height = Math.Max(Height(current.Left), Height(current.Right));
                temp1.Height = Math.Max(Height(current.Left), Height(current.Right));
                
                return temp1;
                */
            }

            public void Transplant(Node t, Node u, Node v)
            {
                if (u.Parent == null)
                    t = v;
                else if(u == u.Parent.Left)
                    u.Parent.Left = v;
                else u.Parent.Right = v;
                if(v != null)
                    v.Parent = u.Parent;   
            }
            
            public bool Find(int data)
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

            public Node Find(int data, bool bb)
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

            public Node ToReplace(Node temp)
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

            public void DeleteElement(int data)
            {
                if (Find(data))
                {
                    Node toDelete = Find(data, true);
                    Node toReplace = ToReplace(toDelete);

                    if (toDelete==null) Console.WriteLine("Element do not exist");
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
                else Console.WriteLine("Element do not exist");
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
        }
    }
}