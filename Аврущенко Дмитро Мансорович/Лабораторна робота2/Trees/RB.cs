using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    class RBTree<T>
        where T : IComparable<T>
    {
        public class Node
        {
            // red = true, black = false
            public bool Color;
            public Node LeftNode;
            public Node RightNode;
            public Node ParentNode;
            public T Data;

            public Node(T Data, Node ParentNode = null)
            {
                this.Data = Data;
                this.ParentNode = ParentNode;
                this.Color = true;
            }
        }
        //Reference on root node
        private Node Root;

        public RBTree() { }

        public void AddNode(T Data)
        {
            AddNode(Data, Root);
        }
        private void AddNode(T Data, Node tree)
        {
            if (Root == null)
            {
                tree = new Node(Data);
                Root = tree;
                Root.Color = false;
            }
            else if (Data.CompareTo(tree.Data) < 0)
            {
                if (tree.LeftNode == null)
                {
                    tree.LeftNode = new Node(Data, tree);
                    CheckViolation(tree.LeftNode);
                }
                else if (tree.LeftNode != null)
                    AddNode(Data, tree.LeftNode);
            }
            else if (Data.CompareTo(tree.Data) > 0)
            {
                if (tree.RightNode == null)
                {
                    tree.RightNode = new Node(Data, tree);
                    CheckViolation(tree.RightNode);
                }
                else if (tree.RightNode != null)
                    AddNode(Data, tree.RightNode);
            }   
        }    
        private bool IsRed(Node node)
        {
            if (node == null) return false;
            else if (!node.Color) return false;
            else return true;
        }
        private void CheckViolation(Node node)
        {   
            if (IsRed(node.ParentNode) && node.ParentNode != null) 
            {
                Fix(node);
            } 
            else if (
                IsRed(Root)) 
            {
                Root.Color = false ;
            }
        }
        private void Fix(Node node)
        {
            Node grand = node.ParentNode.ParentNode;
            Node parent = node.ParentNode;
            if (grand.LeftNode == parent) // uncle right
            {

                if (node.ParentNode.LeftNode == node) // Left Left Case
                {
                    if (grand.RightNode != null && IsRed(grand.RightNode))
                    {
                        node.ParentNode.ParentNode.LeftNode.Color = false;
                        node.ParentNode.ParentNode.RightNode.Color = false;
                        node.ParentNode.ParentNode.Color = true;
                        CheckViolation(grand);
                    }
                    else
                    {
                        RightRotate(grand);
                        node.ParentNode.Color = false;
                        node.ParentNode.RightNode.Color = true;
                        if (node.ParentNode != null)
                            CheckViolation(node.ParentNode);
                    }
                }
                else // Left Right Case
                {

                    if (grand.RightNode != null && IsRed(grand.RightNode))
                    {
                        node.ParentNode.ParentNode.LeftNode.Color = false;
                        node.ParentNode.ParentNode.RightNode.Color = false;
                        node.ParentNode.ParentNode.Color = true;
                        CheckViolation(grand);
                    }
                    else
                    {
                        LeftRotate(node.ParentNode);
                        RightRotate(node.ParentNode);
                        node.RightNode.Color = true;
                        node.Color = false;
                        if (node.ParentNode != null)
                            CheckViolation(node.ParentNode);
                    }
                }
            }
            else // uncle left
            {
                if (node.ParentNode.RightNode == node) // Right Right Case
                {
                    if (grand.LeftNode != null && IsRed(grand.LeftNode))
                    {
                        node.ParentNode.ParentNode.LeftNode.Color = false;
                        node.ParentNode.ParentNode.RightNode.Color = false;
                        node.ParentNode.ParentNode.Color = true;
                        CheckViolation(grand);
                    }
                    else
                    {
                        LeftRotate(grand);
                        node.ParentNode.Color = false;
                        node.ParentNode.LeftNode.Color = true;
                        if (node.ParentNode != null)
                            CheckViolation(node.ParentNode);
                    }
                }
                else // Right Left Case
                {

                    if (grand.LeftNode != null && IsRed(grand.LeftNode))
                    {
                        node.ParentNode.ParentNode.LeftNode.Color = false;
                        node.ParentNode.ParentNode.RightNode.Color = false;
                        node.ParentNode.ParentNode.Color = true;
                        CheckViolation(grand);
                    }
                    else
                    {
                        RightRotate(node.ParentNode);
                        LeftRotate(node.ParentNode);
                        node.LeftNode.Color = true;
                        node.Color = false;
                        if (node.ParentNode != null)
                            CheckViolation(node.ParentNode);
                    }
                }
            }
        }
        private void LeftRotate(Node node)
        {
            Node child = node.RightNode;
            node.RightNode = child.LeftNode;

            if (child.LeftNode != null)
                child.LeftNode.ParentNode = node;
            child.ParentNode = node.ParentNode;
            if (node.ParentNode == null)
                Root = child;
            else if (node == node.ParentNode.LeftNode)
                node.ParentNode.LeftNode = child;
            else node.ParentNode.RightNode = child;
            child.LeftNode = node;
            node.ParentNode = child;
        }
        private void RightRotate(Node node)
        {
            Node child = node.LeftNode;
            node.LeftNode = child.RightNode;

            if (child.RightNode != null)
                child.RightNode.ParentNode = node;
            child.ParentNode = node.ParentNode;
            if (node.ParentNode == null)
                Root = child;
            else if (node == node.ParentNode.RightNode)
                node.ParentNode.RightNode = child;
            else node.ParentNode.LeftNode = child;
            child.RightNode = node;
            node.ParentNode = child;

        }

        public void RemoveNode(T Data)
        {
            Node item = SearchNode(Data, Root);
            if (item == null) { Console.WriteLine("Nothing to delete!"); return; }
            Node X = null;
            Node Y = null;


            if (item.LeftNode == null || item.RightNode == null)
            {
                Y = item;
            }
            else
            {
                Y = TreeSuccessor(item.RightNode);
            }
            if (Y.LeftNode != null)
            {
                X = Y.LeftNode;
            }
            else
            {
                X = Y.RightNode;
            }
            if (X != null)
            {
                X.ParentNode = Y;
            }
            if (Y.ParentNode == null)
            {
                Root = X;
            }
            else if (Y == Y.ParentNode.LeftNode)
            {
                Y.ParentNode.LeftNode = X;
            }
            else
            {
                Y.ParentNode.RightNode = X;
            }
            if (Y != item)
            {
                item.Data = Y.Data;
            }
            if (Y.Color == false)
            {
                RemoveFix(X);
            }
        }
        //private Node TreeMin(Node tree)
        //{
        //    while (tree.LeftNode != null) { tree = tree.LeftNode; }
        //    return tree;
        //}

        private Node TreeSuccessor(Node X)
        {
            Node temp = X;

            while (temp.LeftNode != null)
                temp = temp.LeftNode;

            return temp;
        }






        private void RemoveFix(Node x)
        {
            while (x != null && x != Root && !IsRed(x))
            {

                if (x == x.ParentNode.LeftNode)
                {
                    var w = x.ParentNode.RightNode;
                    if (IsRed(w))
                    {
                        w.Color = false;
                        x.ParentNode.Color = true;
                        LeftRotate(x.ParentNode);
                        w = x.ParentNode.RightNode;
                    }
                    if (!IsRed(w.LeftNode) && !IsRed(w.RightNode))
                    {
                        w.Color = true;
                        x = x.ParentNode;
                    }
                    else if (!IsRed(w.RightNode))
                    {
                        w.LeftNode.Color = false;
                        w.Color = true;
                        RightRotate(w);
                        w = x.ParentNode.RightNode;
                    }
                    w.Color = x.ParentNode.Color;
                    x.ParentNode.Color = false;
                    w.RightNode.Color = false;
                    LeftRotate(x.ParentNode);
                    x = Root;
                }
                else
                {
                    var w = x.ParentNode.LeftNode;
                    if (IsRed(w))
                    {
                        w.Color = false;
                        x.ParentNode.Color = true;
                        LeftRotate(x.ParentNode);
                        w = x.ParentNode.LeftNode;
                    }
                    if (!IsRed(w.LeftNode) && !IsRed(w.RightNode))
                    {
                        w.Color = true;
                        x = x.ParentNode;
                    }
                    else if (!IsRed(w.LeftNode))
                    {
                        w.RightNode.Color = false;
                        w.Color = true;
                        RightRotate(w);
                        w = x.ParentNode.LeftNode;
                    }
                    w.Color = x.ParentNode.Color;
                    x.ParentNode.Color = false;
                    w.LeftNode.Color = false;
                    LeftRotate(x.ParentNode);
                    x = Root;
                }
            }
            if (x != null)
                x.Color = false;
        }
        private Node SearchNode(T Data, Node tree)
        {
            if (tree == null) { return null; }
            if (Data.CompareTo(tree.Data) == 0) { return tree; }
            else if (Data.CompareTo(tree.Data) > 0) { return SearchNode(Data, tree.RightNode); }
            else if (Data.CompareTo(tree.Data) < 0) { return SearchNode(Data, tree.LeftNode); }
            return null;
        }

        public bool SearchNode(T Data)
        {
            if (SearchNode(Data, Root) == null) { Console.WriteLine($"{Data} is absent"); return false; }
            else { Console.WriteLine($"{Data} is here" ); return true; }
        }
        public void DisplayTree()
        {
            if (Root == null)
            {
                Console.WriteLine("Nothing in the tree!");
                return;
            }
            else
            {
                Console.WriteLine("Preorder: ");
                Preorder(Root);
                Console.WriteLine();

                Console.WriteLine("Postorder: ");
                Postorder(Root);
                Console.WriteLine();

                Console.WriteLine("Inorder: ");
                Inorder(Root);
                Console.WriteLine();
            }
        }
        private void Preorder(Node current)
        {
            if (current != null)
            {
                Console.Write("{0}, {1}; ", current.Data, current.Color);
                Preorder(current.LeftNode);
                Preorder(current.RightNode);
            }
        }
        private void Postorder(Node current)
        {
            if (current != null)
            {
                Postorder(current.LeftNode);
                Postorder(current.RightNode);
                Console.Write("{0}, {1}; ", current.Data, current.Color);
            }
        }
        private void Inorder(Node current)
        {
            if (current != null)
            {
                Inorder(current.LeftNode);
                Console.Write("{0}, {1}; ", current.Data, current.Color);
                Inorder(current.RightNode);
            }
        }
        public T Min()
        {
            Node current = Root;
            while (current.LeftNode != null) { current = current.LeftNode; }
            return current.Data;
        }
        public T Max()
        {
            Node current = Root;
            while (current.RightNode != null) { current = current.RightNode; }
            return current.Data;
        }
    }
}
