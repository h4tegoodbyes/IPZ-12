using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    class SplayTree<T>
        where T : IComparable<T>
    {
        public class Node
        {
            public Node LeftNode;
            public Node RightNode;
            public Node ParentNode;
            public T Data;

            public Node(T Data, Node ParentNode = null)
            {
                this.Data = Data;
                this.ParentNode = ParentNode;   
            }
        }

        private Node Root;
        public SplayTree()
        {

        }
        public void AddNode(T Data)
        {
            AddNode(Data, Root);
        }
        public void AddNode(T Data, Node tree = null)
        {
            if (Root == null)
            {
                tree = new Node(Data);
                Root = tree;
            }
            else if (Data.CompareTo(tree.Data) < 0)
            {
                if (tree.LeftNode == null)
                {
                    tree.LeftNode = new Node(Data, tree);
                    while (Data.CompareTo(Root.Data) != 0)
                        Splay(Root, Data);
                }
                else if (tree.LeftNode != null)
                    AddNode(Data, tree.LeftNode);
            }
            else if (Data.CompareTo(tree.Data) > 0)
            {
                if (tree.RightNode == null)
                {
                    tree.RightNode = new Node(Data, tree);
                    while (Data.CompareTo(Root.Data) != 0)
                        Splay(Root, Data);
                }
                else if (tree.RightNode != null)
                    AddNode(Data, tree.RightNode);
            }
            else return;
        }

        public void Search(T Data)
        {
            if (SearchNode(Data, Root) == null) { Console.WriteLine("{0} is absent", Data); }
            else if(Root.Data.CompareTo(Data) ==  0)
                Console.WriteLine($"The element is in Root: {Root.Data}");
            else 
            {   
                while(Data.CompareTo(Root.Data)!=0)
                    Splay(Root, Data);
                Console.WriteLine($"The element is in Root: {Root.Data}");
            }
        }
        private Node SearchNode(T Data, Node tree)
        {
            if (tree == null) { return null; }
            if (Data.CompareTo(tree.Data) == 0) { return tree; }
            else if (Data.CompareTo(tree.Data) > 0) { return SearchNode(Data, tree.RightNode); }
            else if (Data.CompareTo(tree.Data) < 0) { return SearchNode(Data, tree.LeftNode); }
            return null;
        }

        public void RemoveNode(T Data)
        {
            Node tree = SearchNode(Data, Root);
            if (tree == null) { Console.WriteLine("The element is absent"); return; }
            Node current;

            if (tree.LeftNode == null)
                Transplant(Root, tree, tree.RightNode);
            else if (tree.RightNode == null)
                Transplant(Root, tree, tree.LeftNode);
            else
            {
                current = TreeMin(tree.RightNode);
                if (current.ParentNode != tree)
                {
                    Transplant(Root, current, current.RightNode);
                    current.RightNode = tree.RightNode;
                    current.RightNode.ParentNode = current;
                }
                Transplant(Root, tree, current);
                current.LeftNode = tree.LeftNode;
                current.LeftNode.ParentNode = current;
            }
        }
        private Node TreeMin(Node tree)
        {
            while (tree.LeftNode != null) { tree = tree.LeftNode; }
            return tree;
        }
        private void Transplant(Node t, Node u, Node v)
        {
            if (u.ParentNode == null)
                t = v;
            else if (u == u.ParentNode.LeftNode)
                u.ParentNode.LeftNode = v;
            else u.ParentNode.RightNode = v;
            if (v != null)
                v.ParentNode = u.ParentNode;
        }

        Node Splay(Node tree, T Data)
        {
            //Data at Current or Current is null
            if (tree == null || Data.CompareTo(tree.Data) == 0)
                return tree;

            //Left subtree
            if (Data.CompareTo(tree.Data) < 0)
            {
                if (tree.LeftNode == null) return tree;

                //LeftLeft (ZigZig)
                if (Data.CompareTo(tree.LeftNode.Data) < 0)
                {
                    Splay(tree.LeftNode.LeftNode, Data);
                    RightRotate(tree);
                }
                //LeftRight (ZigZag)
                else if (Data.CompareTo(tree.LeftNode.Data) > 0)
                {
                    Splay(tree.LeftNode.RightNode, Data);
                    if (tree.LeftNode.RightNode != null)
                        LeftRotate(tree.LeftNode);
                }
                return (tree.LeftNode == null) ? tree : RightRotate(tree);
            }
            //Right subtree
            else
            {
                if (tree.RightNode == null) return tree;

                //RightLeft (ZagZig)
                if (Data.CompareTo(tree.RightNode.Data) < 0)
                {
                    Splay(tree.RightNode.LeftNode, Data);
                    if (tree.RightNode.LeftNode != null)
                        RightRotate(tree.RightNode);
                }
                //RightRight (ZagZag)
                else if (Data.CompareTo(tree.RightNode.Data) > 0)
                {
                    Splay(tree.RightNode.RightNode, Data);
                    LeftRotate(tree);
                }

                return (tree.RightNode == null) ? tree : LeftRotate(tree);
            }
        }
        Node LeftRotate(Node node)
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

            return child;
        }
        Node RightRotate(Node node)
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
            return child;
        }
        public void DisplayTree()
        {
            if (this == null)
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
        public static void Preorder(Node tree)
        {
            var current = tree;
            if (current != null)
            {
                Console.Write("{0}; ", current.Data);
                if (current.LeftNode != null)
                {
                    Preorder(current.LeftNode);
                }
                if (current.RightNode != null)
                {
                    Preorder(current.RightNode);
                }
            }
        }
        public static void Postorder(Node tree)
        {
            var current = tree;
            if (current != null)
            {

                if (current.LeftNode != null)
                {
                    Postorder(current.LeftNode);
                }
                if (current.RightNode != null)
                {
                    Postorder(current.RightNode);
                }
                Console.Write("{0}; ", current.Data);
            }
        }
        public static void Inorder(Node tree)
        {
            var current = tree;
            if (current != null)
            {

                if (current.LeftNode != null)
                {
                    Inorder(current.LeftNode);
                }
                Console.Write("{0}; ", current.Data);
                if (current.RightNode != null)
                {
                    Inorder(current.RightNode);
                }
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
