using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_tree
{
    internal class AVL
    {
        private Node top;

        
        public AVL()
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
                if (data < current.num)
                {
                    if(current.left == null) 
                    { 
                        Node newNode = new Node(data);
                        current.left = newNode;
                        current.left.parentNode = current;
                        
                        Check(current);
                        added = true;
                    }  
                    else
                    {
                        current.left.parentNode = current;
                        current = current.left;
                        
                    }
                }
                else 
                {
                    if (current.right == null)
                    {
                        Node newNode = new Node(data);
                        current.right = newNode;
                        current.right.parentNode = current;
                       
                        Check(current);
                        added = true;
                    }
                    else
                    {
                        current.right.parentNode = current;
                        current = current.right;
                    }
                }
            }   
        }

        
        private void Check(Node node) 
        {
            if (node != null)
            {
                node.height = 1 + max(getHeight(node.left), getHeight(node.right));
                int factor = balance(node);

                if (factor > 1) // Unbalanced nodes are on the left
                {
                    if (balance(node.left) >= 0)
                        RightROt(node);
                    else 
                    {
                        LeftROt(node.left);
                        RightROt(node.left);                    
                    }                      

                }
                else if(factor < -1)  // Unbalanced nodes are on the right
                {
                    if (balance(node.right) <= 0)
                        LeftROt(node);
                    else
                    {
                        RightROt(node.right);
                        LeftROt(node.right);
                    }
                }
             Check(node.parentNode);
            }        
        }  
        /*
                 * increase height by assigning sum of 1 and biggest height among children
                 * check for balance of children
                 * if no balance perform four cases:
                    1. Left Left case
                    2. Left Right case
                    3. Right Right case
                    4. Right Left case
                then continue increasing height and checking balance;
                until we got to the top node;                
                 
                 */
        int max(int a, int b)
        {
            return (a > b) ? a : b;
        }
        int getHeight(Node node)
        {
            if (node == null)
                return 0;

            return node.height;
        }
        int balance(Node node)
        {
            return getHeight(node.left) - getHeight(node.right);
        }
        private void LeftROt(Node node)
        {
            Node child = node.right;
            node.right = child.left;

            if (child.left != null)
                child.left.parentNode = node;

            child.parentNode = node.parentNode;

            if (node.parentNode == null)
                top = child;

            else if (node == node.parentNode.left)
                node.parentNode.left = child;

            else node.parentNode.right = child;

            child.left = node;
            node.parentNode = child;

            node.height = 1 + max(getHeight(node.left), getHeight(node.right));
            child.height = 1 + max(getHeight(child.left), getHeight(child.right));
        }
        private void RightROt(Node node) {
            Node child = node.left;
            node.left = child.right;

            if (child.right != null)
                child.right.parentNode = node;

            child.parentNode = node.parentNode;

            if (node.parentNode == null)
                top = child;
            else if (node == node.parentNode.right)
                node.parentNode.right = child;

            else node.parentNode.left = child;

            child.right = node;
            node.parentNode = child;

            node.height = 1 + max(getHeight(node.left), getHeight(node.right));
            child.height = 1 + max(getHeight(child.left), getHeight(child.right));
        }


        public void Delete(int data)
        {
            Node found = Search(data);
            if (found.left == null && found.right == null)
            {
                if (found.parentNode.left == found) { found.parentNode.left = null; }
                else { found.parentNode.right = null; }
            }
            if ((found.left == null && found.right != null) || (found.right == null && found.left != null))
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
                Check(found);
            }
            else if(found.left != null && found.right != null)
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
                Check(temp.parentNode);
            }
            

        }
        public void InTree(int data)
        {
            Node node = this.Find(data, top);
            if (node.num == -1)
            {
                Console.WriteLine("there is no such node");
            }
            else { Console.WriteLine("Node found {0} color {1}", node.num, node.color); }

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
            if (data == current.num) { return current; }
            if (data < current.num) { return this.Find(data, current.left); }
            else { return this.Find(data, current.right); }

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
                return;
            }
            Console.Write($"{node.num} h( {node.height} ); => ");

            PreOrder(node.left);

            PreOrder(node.right);
        }
    }
}
