namespace ASD_Lab2;

public class BinaryRedBlack
{
    
        public class Node
        {
            public bool Red;
            public Node Left;
            public Node Right;
            public Node Parent;
            public int Data;

            public Node(int data, Node ParentNode = null)
            {
                Data = data;
                Parent = ParentNode;
                Red = true;
            }
        }
        
        private Node Root;

        public BinaryRedBlack() { }

        public void Add(int data)
        {
            AddEl(data, Root);
        }
        private void AddEl(int data, Node element)
        {
            if (Root == null)
            {
                element = new Node(data);
                Root = element;
                Root.Red = false;
            }
            else if (data < element.Data)
            {
                if (element.Left == null)
                {
                    element.Left = new Node(data, element);
                    Colour(element.Left);
                }
                else if (element.Left != null)
                    AddEl(data, element.Left);
            }
            else if (data > element.Data)
            {
                if (element.Right == null)
                {
                    element.Right = new Node(data, element);
                    Colour(element.Right);
                }
                else if (element.Right != null)
                    AddEl(data, element.Right);
            }   
        }    
        private bool IsRed(Node node)
        {
            if (node == null) return false;
            else if (!node.Red) return false;
            else return true;
        }
        private void Colour(Node node)
        {   
            if (IsRed(node.Parent) && node.Parent != null) 
            {
                Fix(node);
            } 
            else if (IsRed(Root)) 
            {
                Root.Red = false ;
            }
        }
        private void Fix(Node node)
        {
            Node grand = node.Parent.Parent;
            Node parent = node.Parent;
            if (grand.Left == parent) // uncle right
            {
                if (node.Parent.Left == node) // Left Left Case
                {
                    if (grand.Right != null && IsRed(grand.Right))
                    {
                        node.Parent.Parent.Left.Red = false;
                        node.Parent.Parent.Right.Red = false;
                        node.Parent.Parent.Red = true;
                        Colour(grand);
                    }
                    else
                    {
                        RightRotate(grand);
                        node.Parent.Red = false;
                        node.Parent.Right.Red = true;
                        if (node.Parent != null)
                            Colour(node.Parent);
                    }
                }
                else // Left Right Case
                {

                    if (grand.Right != null && IsRed(grand.Right))
                    {
                        node.Parent.Parent.Left.Red = false;
                        node.Parent.Parent.Right.Red = false;
                        node.Parent.Parent.Red = true;
                        Colour(grand);
                    }
                    else
                    {
                        LeftRotate(node.Parent);
                        RightRotate(node.Parent);
                        node.Right.Red = true;
                        node.Red = false;
                        if (node.Parent != null)
                            Colour(node.Parent);
                    }
                }
            }
            else // uncle left
            {
                if (node.Parent.Right == node) // Right Right Case
                {
                    if (grand.Left != null && IsRed(grand.Left))
                    {
                        node.Parent.Parent.Left.Red = false;
                        node.Parent.Parent.Right.Red = false;
                        node.Parent.Parent.Red = true;
                        Colour(grand);
                    }
                    else
                    {
                        LeftRotate(grand);
                        node.Parent.Red = false;
                        node.Parent.Left.Red = true;
                        if (node.Parent != null)
                            Colour(node.Parent);
                    }
                }
                else // Right Left Case
                {

                    if (grand.Left != null && IsRed(grand.Left))
                    {
                        node.Parent.Parent.Left.Red = false;
                        node.Parent.Parent.Right.Red = false;
                        node.Parent.Parent.Red = true;
                        Colour(grand);
                    }
                    else
                    {
                        RightRotate(node.Parent);
                        LeftRotate(node.Parent);
                        node.Left.Red = true;
                        node.Red = false;
                        if (node.Parent != null)
                            Colour(node.Parent);
                    }
                }
            }
        }
        private void LeftRotate(Node node)
        {
            Node child = node.Right;
            node.Right = child.Left;

            if (child.Left != null)
                child.Left.Parent = node;
            child.Parent = node.Parent;
            if (node.Parent == null)
                Root = child;
            else if (node == node.Parent.Left)
                node.Parent.Left = child;
            else node.Parent.Right = child;
            child.Left = node;
            node.Parent = child;
        }
        private void RightRotate(Node node)
        {
            Node child = node.Left;
            node.Left = child.Right;

            if (child.Right != null)
                child.Right.Parent = node;
            child.Parent = node.Parent;
            if (node.Parent == null)
                Root = child;
            else if (node == node.Parent.Right)
                node.Parent.Right = child;
            else node.Parent.Left = child;
            child.Right = node;
            node.Parent = child;

        }

        public void DeleteElement(int data)
        {
            Node item = SearchNode(data, Root);
            Node X;
            Node Y;
            if (item == null)
            {
                Console.WriteLine($"\nElement {data} not exist");
                return;
            }

            if (item.Left == null || item.Right == null)
            {
                Y = item;
            }
            else
            {
                Y = ToReplace(item.Right);
            }

            if (Y.Left != null)
                X = Y.Left;
            else X = Y.Right;
            
            if (X != null)
                X.Parent = Y;
            
            if (Y.Parent == null)
                Root = X;
            else if (Y == Y.Parent.Left)
                Y.Parent.Left = X;
            else Y.Parent.Right = X;

            if (Y != item)
                item.Data = Y.Data;

            if (Y.Red == false) RemoveFix(X);
        }

        private Node ToReplace(Node toDelete)
        {
            Node temp = toDelete;

            while (temp.Left != null)
                temp = temp.Left;
            return temp;
        }

        private void RemoveFix(Node x)
        {
            while (x != null && x != Root && !IsRed(x))
            {

                if (x == x.Parent.Left)
                {
                    var w = x.Parent.Right;
                    if (IsRed(w))
                    {
                        w.Red = false;
                        x.Parent.Red = true;
                        LeftRotate(x.Parent);
                        w = x.Parent.Right;
                    }
                    if (!IsRed(w.Left) && !IsRed(w.Right))
                    {
                        w.Red = true;
                        x = x.Parent;
                    }
                    else if (!IsRed(w.Right))
                    {
                        w.Left.Red = false;
                        w.Red = true;
                        RightRotate(w);
                        w = x.Parent.Right;
                    }
                    w.Red = x.Parent.Red;
                    x.Parent.Red = false;
                    w.Right.Red = false;
                    LeftRotate(x.Parent);
                    x = Root;
                }
                else
                {
                    var w = x.Parent.Left;
                    if (IsRed(w))
                    {
                        w.Red = false;
                        x.Parent.Red = true;
                        LeftRotate(x.Parent);
                        w = x.Parent.Left;
                    }
                    if (!IsRed(w.Left) && !IsRed(w.Right))
                    {
                        w.Red = true;
                        x = x.Parent;
                    }
                    else if (!IsRed(w.Left))
                    {
                        w.Right.Red = false;
                        w.Red = true;
                        RightRotate(w);
                        w = x.Parent.Left;
                    }
                    w.Red = x.Parent.Red;
                    x.Parent.Red = false;
                    w.Left.Red = false;
                    LeftRotate(x.Parent);
                    x = Root;
                }
            }
            if (x != null)
                x.Red = false;
        }
        private Node SearchNode(int data, Node tree)
        {
            if (tree == null) { return null; }
            if (data == tree.Data) { return tree; }
            else if (data > tree.Data) { return SearchNode(data, tree.Right); }
            else if (data < tree.Data) { return SearchNode(data, tree.Left); }
            return null;
        }

        public void SearchNode(int data)
        {
            if (SearchNode(data, Root) == null) { Console.WriteLine($"Element {data} not found"); }
            else { Console.WriteLine($"Element {data} found" ); }
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
    } 
    
/*
Node Root;
public int numberCount=0;

void LeftRotate(ref Node node)
{
    Node pare = node.Parent;
    Node r = node.Right;
    Node l = node.Left;

    r.Left = node;
    node.Parent = r;
    node.Right = l;

    if (l != null)
    {
        l.Parent = node;
    }
    if (r != null)
    {
        r.Parent = pare;
    }
    node = r;
}
void RightRotate(ref Node node)
{
    Node pare = node.Parent;
    Node r = node.Right;
    Node l = node.Left;

    r.Right = node;
    node.Parent = l;
    node.Left = r;

    if (r != null)
    {
        r.Parent = node;
    }
    if (l != null)
    {
        l.Parent = pare;
    }
    node = l;
}

public void Add(int data)
{
    Root = InsertNode(Root, data, null);
    Node InsertedNode = Root;
    numberCount++;
    if (numberCount > 2)
    {
        Node parent;
        Node grandparent;
        Node greatgrandparent;
        GetNodes(InsertedNode, out parent, out grandparent, out greatgrandparent);
        FixTreeInsert(InsertedNode, parent, grandparent, greatgrandparent);
    }
}

private Node InsertNode(Node node, int data, Node parent)
{
    if (node == null)
    {
        Node newnode = new Node(data, parent);
        if (numberCount > 0)
        {
            newnode.Red = true;
        }
        else
        {
            newnode.Red = false;
        }
        return newnode;
    }
    else if (data < node.Data)
    {
        node.Left = InsertNode(node.Left, data, node);
        return node;
    }
    else if (data > node.Data)
    {
        node.Right = InsertNode(node.Right, data, node);
        return node;
    }
    else
    {
        throw new InvalidOperationException("Element exist");
    }
}

private void GetNodes(Node current, out Node parent, out Node grandparent, out Node greatgrandparent)
{
    parent = null;
    grandparent = null;
    greatgrandparent = null;
    if (current != null)
    {
        parent = current.Parent;
    }
    if (parent != null)
    {
        grandparent = parent.Parent;
    }
    if (grandparent != null)
    {
        greatgrandparent = grandparent.Parent;
    }
}

private void FixTreeInsert(Node child, Node parent, Node grandparent, Node greatgrandparent)
{
    if (grandparent != null)
    {
        Node uncle = (grandparent.Right == parent) ? grandparent.Left : grandparent.Right;
        if (uncle != null && parent.Red && uncle.Red)
        {
            uncle.Red = false;
            parent.Red = false;
            grandparent.Red = true;
            Node level4 = null;
            Node level5 = null;
            if (greatgrandparent != null)
            {
                level4 = greatgrandparent.Parent;
            }

            if (level4 != null)
            {
                level5 = level4.Parent;
            }

            FixTreeInsert(grandparent, greatgrandparent, level4, level5);
        }
        else if (uncle == null || parent.Red && !uncle.Red)
        {
            if (grandparent.Right == parent && parent.Right == child)
            {
                parent.Red = false;
                grandparent.Red = true;
                if (greatgrandparent != null)
                {
                    if (greatgrandparent.Right == grandparent)
                    {
                        LeftRotate(ref grandparent);
                        greatgrandparent.Right = grandparent;
                    }
                    else
                    {
                        LeftRotate(ref grandparent);
                        greatgrandparent.Left = grandparent;
                    }
                }
                else
                {
                    LeftRotate(ref Root);
                }
            }
            else if (grandparent.Left == parent && parent.Left == child)
            {
                if (grandparent.Right == parent && parent.Right == child)
                {
                    parent.Red = false;
                    grandparent.Red = true;
                    if (greatgrandparent != null)
                    {
                        if (greatgrandparent.Right == grandparent)
                        {
                            RightRotate(ref grandparent);
                            greatgrandparent.Right = grandparent;
                        }
                        else
                        {
                            RightRotate(ref grandparent);
                            greatgrandparent.Left = grandparent;
                        }
                    }
                    else
                    {
                        RightRotate(ref Root);
                    }
                }
            }
            else if (grandparent.Right == parent && parent.Left == child)
            {
                child.Red = false;
                grandparent.Red = true;
                RightRotate(ref parent);
                if (greatgrandparent != null)
                {
                    if (greatgrandparent.Right == grandparent)
                    {
                        LeftRotate(ref grandparent);
                        greatgrandparent.Right = grandparent;
                    }
                    else
                    {
                        LeftRotate(ref grandparent);
                        greatgrandparent.Left = grandparent;
                    }
                }
                else
                {
                    LeftRotate(ref Root);
                }
            }
            else if (grandparent.Left == parent && parent.Right == child)
            {
                child.Red = false;
                grandparent.Red = true;
                LeftRotate(ref parent);
                if (greatgrandparent != null)
                {
                    if (greatgrandparent.Right == grandparent)
                    {
                        RightRotate(ref grandparent);
                        greatgrandparent.Right = grandparent;
                    }
                    else
                    {
                        RightRotate(ref grandparent);
                        greatgrandparent.Left = grandparent;
                    }
                }
                else
                {
                    RightRotate(ref Root);
                }
            }
        }

        if (Root.Red)
        {
            Root.Red = false;
        }
    }
}
*/