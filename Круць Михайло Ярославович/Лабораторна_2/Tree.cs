using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_tree
{
    internal class Tree
    {

       private Node top;

        public Tree()
        {
            top = null;
        }
        public void Add(int data) 
        {
            if (top == null)
            {
                Node node = new Node(data);
                top = node;
                return;
            }

            Node current = top;
            

            bool added = false;
            while (!added)
            {
                if (data < current.num) // ноду необхідно додати до лівого піддерева
                {
                    if(current.left == null) 
                    { 
                        Node newNode = new Node(data);
                        current.left = newNode;
                        current.left.parentNode = current;
                        
                        added = true;
                    }  
                    else
                    {
                        
                        current = current.left;
                        
                    }
                }
                else // ноду необхідно додати до правого піддерева
                {
                    if (current.right == null)
                    {
                        Node newNode = new Node(data);
                        current.right = newNode;
                        current.right.parentNode = current;
                        
                        added = true;
                    }
                    else
                    {
                        
                        current = current.right;
                    }
                }
            }   
        }

        public void Delete(int data)
        {
            Node found = Search(data);
            if (found.num == -1)
            {
                Console.WriteLine("No such Node found");
                return;
            }
            if (found.left == null && found.right == null)   // якщо в ноди немає нащадків
            {
                if (found.parentNode.left == found) { found.parentNode.left = null; }
                else { found.parentNode.right = null; }
            }
            if ((found.left == null && found.right != null) || (found.right == null && found.left != null)) // якщо є хоча б один нащадок
            {
                if (found.left == null)
                {
                    if (found.parentNode.left == found)
                    {
                        found.left.parentNode = found.parentNode;
                        found.parentNode.left = found.right;
                    }
                    else
                    {
                        found.right.parentNode = found.parentNode;
                        found.parentNode.right = found.right;
                    }
                }
                else
                {
                    if (found.parentNode.left == found)
                    {
                        found.left.parentNode = found.parentNode;
                        found.parentNode.left = found.left;

                    }
                    else
                    {
                        found.right.parentNode = found.parentNode;
                        found.parentNode.right = found.left;
                    }

                }
            }
            else // якщо нода має 2 нащадки
            {
                Node temp = found.right;
                if (temp.left == null && temp.right == null)
                {
                    found.num = temp.num;
                    found.right = null;
                }
                else
                {
                    if (temp.left != null)
                    {
                        temp = Tree_Min(temp);

                        if (temp.right == null)
                        {
                            found.num = temp.num;
                            temp.parentNode.left = null;
                        }
                        else
                        {
                            found.num = temp.num;
                            temp.right.parentNode = temp.parentNode;
                            temp.parentNode.left = temp.right;
                        }

                    }
                    else
                    {
                        found.num = temp.num;
                        temp.right.parentNode = found;
                        found.right = temp.right;
                    }

                }


            }
        }
        public void InTree(int data) 
        {
            Node node = this.Find(data, top);
            if (node.num == -1)
            {
                Console.WriteLine("there is no such node");
            }
            else { Console.WriteLine("Node found"); }
        
        }
        public Node Search(int data) 
        {
            return this.Find(data, top);
        
        }
        private Node Find(int data, Node current) 
        {
            
            if (current == null)
            {
                Node node = new Node(-1);
                return node;
            }
            if (data == current.num){ return current; }
            if (data < current.num) { return this.Find(data, current.left); }
            else { return this.Find(data, current.right); }

        }

        public void GetMax() 
        {
            if(top == null)
            {
                return;
            }
            Node current = top;
            while (current.right != null)
            {
                current = current.right;
            }
            Console.WriteLine($"Max node {current.num}");

        }
        public void GetMin()
        {
            if (top == null)
            {
                return;
            }
            Node current = top;
            while (current.left != null)
            {
                current = current.left;
            }
            Console.WriteLine($"Min node {current.num}");
        }
        private Node Tree_Min(Node node)
        {
            while (node.left != null)
                node = node.left;
            return node;
        }
        public void PreOrder() 
        {
            Console.WriteLine();
            PreOrder(top);        
        }

        private void PreOrder(Node node) 
        {
            if (node == null) 
            {
                return ;
            }
            Console.Write(node.num + " => ");

            PreOrder(node.left);

            PreOrder(node.right);
        }

        public void PostOrder() 
        {
            Console.WriteLine();
            PostOrder(top);
        }

        private void PostOrder(Node node) 
        {
            if (node == null)
            {
                return;
            }
            PostOrder(node.left);

            PostOrder(node.right);

            Console.Write(node.num + " => ");

        }

        public void InOrder()
        {
            Console.WriteLine();
            InOrder(top);
        }

        private void InOrder(Node node) 
        {
            if (node == null)
            {
                return;
            }
            InOrder(node.left);

            Console.Write(node.num + " => ");

            InOrder(node.right);

        }

        
    }
}
