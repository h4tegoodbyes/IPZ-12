namespace ASD_Lab2;

public class AVL
{
    class Node
    {
        public int Data;
        public Node Left;
        public Node Right;
        public int Height;

        public Node(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    
    Node Root;
    public AVL()
    {
    }

    public void Add(int data)
    {
        Node Element = new Node(data);
        if (Root == null)
        {
            Root = Element;
        }
        else
        {
            Root = Insert(Root, Element);
        }
    }

    private Node Insert(Node current, Node n)
    {
        if (current == null)
        {
            current = n;
            return current;
        }
        else if (n.Data < current.Data)
        {
            current.Left = Insert(current.Left, n);
            current = Balance(current);
        }
        else if (n.Data > current.Data)
        {
            current.Right = Insert(current.Right, n);
            current = Balance(current);
        }
        return current;
    }

    private Node Balance(Node current)
    {
        int b = CorrectHeight(current);
        if (b > 1)
        {
            if (CorrectHeight(current.Left) > 0)
            {
                current = RotateLL(current);
            }
            else
            {
                current = RotateLtoR(current);
            }
        }
        else if (b < -1)
        {
            if (CorrectHeight(current.Right) > 0)
            {
                current = RotateRtoL(current);
            }
            else
            {
                current = RotateRR(current);
            }
        }

        return current;
    }

    public void Delete(int data)
    {
        Root = Delete(Root, data);
    }

    private Node Delete(Node current, int key)
    {
        Node parent;
        if (current == null)
        {
            return null;
        }
        else
        {
            if (key < current.Data)
            {
                current.Left = Delete(current.Left, key);
                if (CorrectHeight(current) == -2)
                {
                    if (CorrectHeight(current.Right) <= 0)
                    {
                        current = RotateRR(current);
                    }
                    else
                    {
                        current = RotateRtoL(current);
                    }
                }
            }
            else if (key > current.Data)
            {
                current.Right = Delete(current.Right, key);
                if (CorrectHeight(current) == 2)
                {
                    if (CorrectHeight(current.Left) >= 0)
                    {
                        current = RotateLL(current);
                    }
                    else
                    {
                        current = RotateLtoR(current);
                    }
                }
            }
            else
            {
                if (current.Right != null)
                {
                    parent = current.Right;
                    while (parent.Left != null)
                    {
                        parent = parent.Left;
                    }

                    current.Data = parent.Data;
                    current.Right = Delete(current.Right, parent.Data);
                    
                    if (CorrectHeight(current) == 2)
                    {
                        if (CorrectHeight(current.Left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLtoR(current);
                        }
                    }
                }
                else
                {
                    return current.Left;
                }
            }
        }

        return current;
    }
    /*
    public void Find(int key)
    {
        if (Find(key, root).data == key)
        {
            Console.WriteLine($"Element {key} found");
        }
        else
        {
            Console.WriteLine($"Element {key} not found");
        }
    }

    private Node Find(int target, Node current)
    {

        if (target < current.data)
        {
            if (target == current.data)
            {
                return current;
            }
            return Find(target, current.left);
        }
        else
        {
            if (target == current.data)
            {
                return current;
            }
            else
                return Find(target, current.right);
        }

    }
    */
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

    private int max(int l, int r)
    {
        return l > r ? l : r;
    }

    private int getHeight(Node current)
    {
        int height = 0;
        if (current != null)
        {
            int l = getHeight(current.Left);
            int r = getHeight(current.Right);
            int m = max(l, r);
            height = m + 1;
        }

        return height;
    }

    private int CorrectHeight(Node current)
    {
        int l = getHeight(current.Left);
        int r = getHeight(current.Right);
        int h = l - r;
        return h;
    }

    private Node RotateRR(Node parent)
    {
        Node pivot = parent.Right;
        parent.Right = pivot.Left;
        pivot.Left = parent;
        return pivot;
    }

    private Node RotateLL(Node parent)
    {
        Node pivot = parent.Left;
        parent.Left = pivot.Right;
        pivot.Right = parent;
        return pivot;
    }

    private Node RotateLtoR(Node parent)
    {
        Node pivot = parent.Left;
        parent.Left = RotateRR(pivot);
        return RotateLL(parent);
    }

    private Node RotateRtoL(Node parent)
    {
        Node pivot = parent.Right;
        parent.Right = RotateLL(pivot);
        return RotateRR(parent);
    }

    public void MaxElement()
    {
        Node current = Root;
        while (current.Right != null)
        {
            current = current.Right;
        }

        Console.WriteLine($"Max element is {current.Data}");
    }

    public void MinElement()
    {
        Node current = Root;
        while (current.Left != null)
        {
            current = current.Left;
        }
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