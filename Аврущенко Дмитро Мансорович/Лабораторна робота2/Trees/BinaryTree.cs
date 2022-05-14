using System;

namespace BinaryTrees
{
    class BinaryTree<T> 
        where T : IComparable<T>
    {
        private BinaryTree<T> LeftNode { get; set; }
        private BinaryTree<T> RightNode { get; set; }
        private BinaryTree<T> ParentNode { get; set; }  
        private T Data { get; set; }
        public BinaryTree(T Data, BinaryTree<T> ParentNode = null)
        {
            this.ParentNode = ParentNode;
            this.Data = Data;
        }

        public void AddNode(T Data, BinaryTree<T> tree = null)
        {
            if (Data.CompareTo(this.Data) < 0)
            {
                if (LeftNode == null)
                {
                    LeftNode = new BinaryTree<T>(Data, this);                   
                }
                else if (LeftNode != null)
                    LeftNode.AddNode(Data);
            }
            else
            {
                if (RightNode == null)
                {
                    RightNode = new BinaryTree<T>(Data, this);
                }
                else if (RightNode != null)
                    RightNode.AddNode(Data);
            }
        }

        public bool SearchNode(T Data)
        {
            if (SearchNode(Data, this) == null) { Console.WriteLine($"{Data} is absent"); return false; }
            else { Console.WriteLine($"{Data} is here"); return true; }
        }
        private BinaryTree<T> SearchNode(T Data, BinaryTree<T> tree)
        {
            if(tree == null) { return null; }
            if (Data.CompareTo(tree.Data) == 0) { return tree; }
            else if (Data.CompareTo(tree.Data) > 0) { return SearchNode(Data, tree.RightNode); }
            else if (Data.CompareTo(tree.Data) < 0) { return SearchNode(Data, tree.LeftNode); }
            return null;
        }

        public void RemoveNode(T Data)
        {
            BinaryTree<T> tree = SearchNode(Data, this);
            if (tree == null) { Console.WriteLine("The element is absent"); return; }
            BinaryTree<T> current;

            if (tree.LeftNode == null)
                Transplant(this, tree, tree.RightNode);
            else if (tree.RightNode == null)
                Transplant(this, tree, tree.LeftNode);
            else
            {
                current = TreeMin(tree.RightNode);
                if(current.ParentNode != tree)
                {
                    Transplant(this, current, current.RightNode);
                    current.RightNode = tree.RightNode;
                    current.RightNode.ParentNode = current;
                }
                Transplant(this, tree, current);
                current.LeftNode = tree.LeftNode;
                current.LeftNode.ParentNode = current;
            }
        }
        private BinaryTree<T> TreeMin(BinaryTree<T> tree)
        {
            while (tree.LeftNode != null) { tree = tree.LeftNode; }
            return tree;
        }
        private void Transplant(BinaryTree<T> t, BinaryTree<T> u, BinaryTree<T> v)
        {
            if (u.ParentNode == null)
                t = v;
            else if(u == u.ParentNode.LeftNode)
                u.ParentNode.LeftNode = v;
            else u.ParentNode.RightNode = v;
            if(v != null)
                v.ParentNode = u.ParentNode;   
        }

        public T Min()
        {
            BinaryTree<T> current = this;
            while(current.LeftNode != null) { current = current.LeftNode; }
            return current.Data;
        }
        public T Max()
        {
            BinaryTree<T> current = this;
            while (current.RightNode != null) { current = current.RightNode; }
            return current.Data;
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
                Preorder(this);
                Console.WriteLine();

                Console.WriteLine("Postorder: ");
                Postorder(this);
                Console.WriteLine();

                Console.WriteLine("Inorder: ");
                Inorder(this);
                Console.WriteLine();
            }
        }

        public static void Preorder(BinaryTree<T> tree)
        {
            var current = tree;
            if(current != null)
            {
                Console.Write("{0}; ", current.Data);
                if (current.LeftNode != null)
                {
                    Preorder(current.LeftNode);
                }
                if(current.RightNode != null)
                {
                   Preorder(current.RightNode);
                }
            }
        }
        
        public static void Postorder(BinaryTree<T> tree)
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

        public static void Inorder(BinaryTree<T> tree)
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
    }
}
