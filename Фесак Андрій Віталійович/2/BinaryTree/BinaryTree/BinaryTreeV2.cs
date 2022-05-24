namespace BinaryTree_v2
{
    public class BinaryTree
    {
        public Node? top;

        public BinaryTree()
        {
            top = null;
        }

        public BinaryTree(int value)
        {
            top = new Node(value);
        }

        public void Add(int value)
        {
            if (top==null)
            {
                top = new Node(value);
            }
            else
            {
                Node current = top;
                while (current.Value!=value)
                {
                    if (value<current.Value  )
                    {
                        if (current.Left==null)
                        {
                            current.Left = new Node(current, value);
                            return;
                        }
                        else
                        {
                            current = current.Left;
                        }
                    }else
                    {
                        if (current.Right == null)
                        {
                            current.Right = new Node(current, value);
                            return;
                        }
                        else
                        {
                            current = current.Right;
                        }
                    }
                }

                throw new Exception("The value Already exist in tree");
            }
        }

        public Node Find(int value)
        {
            Node current = top;
            while (current != null && current.Value !=value)
            {
                if (current.Value<value)
                {
                    current = current.Right;
                }
                else
                {
                    current = current.Left;
                }
                
            }

            if (current==null)
            {
                return null;
            }

            return current;

        }

        static public Node FindMinInNode(Node node)
        {
            Node temp = node;
            while (temp.Left!=null)
            {
                temp = temp.Left;
            }
            return temp;
        }
        public Node FindMaxInNode(Node node)
        {
            Node temp = node;
            while (temp.Left!=null)
            {
                temp = temp.Left;
            }

            return temp;
        }

        public void Delete(int value)
        {
            Node? current = Find(value);
            if (current!= null)
            {
                if (current == top)
                {
                    Node temp = FindMinInNode(top.Right);
                    temp.Left = top.Left;
                    top = top.Right;
                }else if (current.Left !=null && current.Right != null)
                {
                    Node MinRightNode = BinaryTree.FindMinInNode(current.Right);
                    Node Father = current.Father;
                    Node Right = current.Right;
                    Right.Father = Father;
                    MinRightNode.Left = current.Left;
                    current.Left.Father = MinRightNode;
                    current.Father.Left = current.Right;

                }else if (current.Left !=null || current.Right != null)
                {
                    if (current.Left==null)
                    {
                        current.Right.Father = current.Father;
                        current.Father.Left = current.Right;
                    }
                    else
                    {
                        current.Left.Father = current.Father;
                        current.Father.Left = current.Left;
                    }
                }
                else
                {
                    if (current.Father.Left ==current)
                    {
                        current.Father.Left = null;
                    }
                    else
                    {
                        current.Father.Right = null;
                    }
                }
            }
            else
            {
                throw new Exception("This Node isn`t exist");
            }
            
        }
        
    }

    public class Node
    {
        public Node? Father { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public int Value { get; set; }

        public Node(int value)
        {
            Father = null;
            Left = null;
            Right = null;
            Value = value;
        }

        public Node(Node father,int value)
        {
            Father = father;
            Left = null;
            Right = null;
            Value = value;
        }
    }
}
