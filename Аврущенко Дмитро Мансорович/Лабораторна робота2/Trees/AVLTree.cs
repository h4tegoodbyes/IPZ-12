using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    internal class AVLTree<T>
        where T : IComparable<T>
    {
        public class Node
        {
            public int Height { get; set; }
            public Node LeftNode;
            public Node RightNode;
            public Node ParentNode;
            public T Data;

            public Node(T Data, Node ParentNode = null)
            {
                this.Data = Data;
                this.ParentNode = ParentNode;
                this.Height = 1;
            }
        }

        private Node Root;
        public AVLTree()
        {

        }
        public void AddNode(T Data)
        {
            AddNode(Data, Root);
            AddFix(Root, Data);
        }
        private void AddNode(T Data, Node tree)
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
                }
                else if (tree.LeftNode != null)
                    AddNode(Data, tree.LeftNode);
            }
            else if (Data.CompareTo(tree.Data) > 0)
            {
                if (tree.RightNode == null)
                {
                    tree.RightNode = new Node(Data, tree);
                }
                else if (tree.RightNode != null)
                    AddNode(Data, tree.RightNode);
            }
            else return;
            tree.Height = 1 + Math.Max(Height(tree.LeftNode), Height(tree.RightNode));

            tree = AddFix(tree, Data);
            
        }
        Node AddFix(Node tree, T Data)
        {
            int balance = HeightDifference(tree);
            // Left Left Case
            if (balance > 1 && Data.CompareTo(tree.LeftNode.Data) < 0)
                tree = RightRotate(tree);

            // Right Right Case
            if (balance < -1 && Data.CompareTo(tree.RightNode.Data) > 0)
                tree = LeftRotate(tree);

            // Left Right Case
            if (balance > 1 && Data.CompareTo(tree.LeftNode.Data) > 0)
            {
                tree.LeftNode = LeftRotate(tree.LeftNode);
                tree = RightRotate(tree);
            }

            // Right Left Case
            if (balance < -1 && Data.CompareTo(tree.RightNode.Data) < 0)
            {
                tree.RightNode = RightRotate(tree.RightNode);
                tree = LeftRotate(tree);
            }

            return tree;
            /* return the (unchanged) node pointer */
        }
        public void RemoveNode(T Data)
        {
            RemoveNode(Root, Data);
            AddFix(Root, Data);
        }
        Node RemoveNode(Node tree, T Data)
        {
            if (tree == null)
            {
                return tree;
            }

            if (Data.CompareTo(tree.Data) < 0)
            {
                tree.LeftNode = RemoveNode(tree.LeftNode, Data);
            }
            else if (Data.CompareTo(tree.Data) > 0)
            {
                tree.RightNode = RemoveNode(tree.RightNode, Data);
            }
            else
            {
                if (tree.LeftNode == null || tree.RightNode == null)
                {
                    Node temp = null;
                    if (tree.LeftNode == temp)
                        temp = tree.RightNode;
                    else temp = tree.LeftNode;

                    if (temp == null)
                    {
                        temp = tree;
                        tree = null;
                    }
                    else tree = temp;
                }
                else
                {
                    Node temp = TreeMin(tree.RightNode);
                    tree.Data = temp.Data;
                    tree.RightNode = RemoveNode(tree.RightNode, temp.Data);
                }
            }

            if (tree == null)
                return tree;

            tree.Height = Math.Max(Height(tree.LeftNode), Height(tree.RightNode)) + 1;
            //RemoveFix(tree, Data);
            return RemoveFix(tree, Data);

        }
        Node RemoveFix(Node tree, T Data)
        {
            int balance = HeightDifference(tree);
            //Left Left
            if (balance > 1 && HeightDifference(tree.LeftNode) >= 0)
                return RightRotate(tree);

            //Left Right
            if (balance > 1 && HeightDifference(tree.LeftNode) < 0)
            {
                tree.LeftNode = LeftRotate(tree.LeftNode);
                return RightRotate(tree);
            }

            //Right Left
            if (balance < -1 && HeightDifference(tree.LeftNode) > 0)
            {
                tree.RightNode = RightRotate(tree.RightNode);
                return LeftRotate(tree);
            }

            //Right Right
            if (balance < -1 && HeightDifference(tree.LeftNode) <= 0)
                return LeftRotate(tree);

            return tree;
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

            // Update heights
            node.Height = Math.Max(Height(node.LeftNode), Height(node.RightNode)) + 1;
            child.Height = Math.Max(Height(child.LeftNode), Height(child.RightNode)) + 1;

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

            //Update heights
            node.Height = Math.Max(Height(node.LeftNode), Height(node.RightNode)) + 1;
            child.Height = Math.Max(Height(child.LeftNode), Height(child.RightNode)) + 1;

            return child;
        }
        int HeightDifference(Node node)
        {
            if (node == null)
                return 0;

            return Height(node.LeftNode) - Height(node.RightNode);
        }
       
        int Height(Node node)
        {
            if (node == null)
                return 0;

            return node.Height;
        }
        
        private Node TreeMin(Node tree)
        {
            while (tree.LeftNode != null) { tree = tree.LeftNode; }
            return tree;
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
            else { Console.WriteLine($"{Data} is here"); return true; }
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
                Console.Write("{0}, {1}h; ", current.Data, current.Height);
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
                Console.Write("{0}, {1}h; ", current.Data, current.Height);
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
                Console.Write("{0}, {1}h; ", current.Data, current.Height);
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
