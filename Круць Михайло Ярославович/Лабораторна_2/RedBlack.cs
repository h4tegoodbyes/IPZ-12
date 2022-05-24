using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_tree
{
    internal class RedBlack
    {
        private Node top;

        public RedBlack()
        {
            top = null;
        }

        public void Add(int data)
        {
            if (top == null)
            {
                Node node = new Node(data);
                top = node;
                top.color = "black";
                return;
            }

            Node current = top;


            bool added = false;
            while (!added)
            {
                if (data < current.num)
                {
                    if (current.left == null)
                    {
                        Node newNode = new Node(data);
                        current.left = newNode;
                        current.left.parentNode = current;
                        current.left.color = "red";
                        
                        added = true;
                        CheckViolation(current.left);
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
                        current.right.color = "red";
                        
                        added = true;
                        CheckViolation(current.right);
                    }
                    else
                    {
                        current.right.parentNode = current;
                        current = current.right;
                    }
                }
            }
        }
        private void CheckViolation(Node node)
        {
            //Перевірка чи є дана нода коренем

            if (node.parentNode != null) // Ні
            {
                
                if (node.parentNode.color == "red")
                {
                    Restore(node);
                
                }
            }      
            else if(node.parentNode == null && top.color == "red") // Так
            {
                top.color = "black";
            }           

        }
        private void Restore(Node node)
        {
            Node grand = node.parentNode.parentNode;
            Node parent = node.parentNode;
  

            if (grand.left == parent) // Дядько зправа
            {               

                if (node.parentNode.left == node) // Left Left Case // лівий нащадок
                {
                    
                    if (grand.right != null && grand.right.color == "red")  // Дядько червоний
                    {
                        node.parentNode.parentNode.left.color = "black";
                        node.parentNode.parentNode.right.color = "black";
                        node.parentNode.parentNode.color = "red";
                        CheckViolation(grand);
                    }
                    else // Дядько чорний
                    {
                        RightRotation(grand); // переміщуємо дідуся на місце дядька, нода стає на місце свого батька
                        node.parentNode.color = "black";
                        node.parentNode.right.color = "red";          
                        if (node.parentNode != null)
                            CheckViolation(node.parentNode);
                    }
                }
                else // Left Right Case  // правий нащадок
                {
                    
                    if (grand.right != null && grand.right.color == "red")  // Дядько червоний
                    {
                        node.parentNode.parentNode.left.color = "black";
                        node.parentNode.parentNode.right.color = "black";
                        node.parentNode.parentNode.color = "red";
                        CheckViolation(grand);
                    }
                    else // Дядько чорний
                    {
                        LeftRotation(node.parentNode); // переміщуємо ноду на місце батька
                        RightRotation(node.parentNode);  // переміщуємо ноду на місце нового батька(минулого дідуся)                 
                        node.right.color = "red";
                        node.color = "black";
                        if(node.parentNode != null)
                            CheckViolation(node.parentNode);
                    }
                } 
            }
           
            else // Дядько зліва
            {
                if (node.parentNode.right == node) // Right Right Case // правий нащадок
                {

                    if (grand.left != null && grand.left.color == "red") // дядько червоний
                    {
                        node.parentNode.parentNode.left.color = "black";
                        node.parentNode.parentNode.right.color = "black";
                        node.parentNode.parentNode.color = "red";
                        CheckViolation(grand);
                    }
                    else // Дядько чорний
                    {
                        LeftRotation(grand); // переміщуємо дідуся на місце дядька, нода стає на місце свого батька
                        node.parentNode.color = "black";
                        node.parentNode.left.color = "red";
                        if (node.parentNode != null)
                            CheckViolation(node.parentNode);
                    }
                }
                else // Right Left Case // лівий нащадок
                {

                    if (grand.left != null && grand.left.color == "red") // Дядько червоний
                    {
                        node.parentNode.parentNode.left.color = "black";
                        node.parentNode.parentNode.right.color = "black";
                        node.parentNode.parentNode.color = "red";
                        CheckViolation(grand);
                    }
                    else // Дядько чорний
                    {
                        RightRotation(node.parentNode); // переміщуємо ноду на місце батька
                        LeftRotation(node.parentNode); // переміщуємо ноду на місце нового батька(минулого дідуся)                       
                        node.left.color = "red";
                        node.color = "black";
                        if (node.parentNode != null)
                            CheckViolation(node.parentNode);
                    }
                }

            }            
            

        }
        private void LeftRotation(Node node)
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
        }
        private void RightRotation(Node node) 
        {
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
            Console.Write($"{node.num} col{node.color} => ");

            PreOrder(node.left);

            PreOrder(node.right);
        }

        public void Delete(int Data)
        {
            Node item = Search(Data);
            if (item == null) { Console.WriteLine("Nothing to delete!"); return; }
            Node X = null;
            Node Y = null;


            if (item.left == null || item.right == null)
            {
                Y = item;
            }
            else
            {
                Y = TreeSuccessor(item.right);
            }
            if (Y.left != null)
            {
                X = Y.left;
            }
            else
            {
                X = Y.right;
            }
            if (X != null)
            {
                X.parentNode = Y;
            }
            if (Y.parentNode == null)
            {
                top = X;
            }
            else if (Y == Y.parentNode.left)
            {
                Y.parentNode.left = X;
            }
            else
            {
                Y.parentNode.right = X;
            }
            if (Y != item)
            {
                item.num = Y.num;
            }
            if (Y.color == "black")
            {
                RBDelFix(X);
            }
        }
        

        private Node TreeSuccessor(Node X)
        {
            Node temp = X;

            while (temp.left != null)
                temp = temp.left;

            return temp;
        }
        private void RBDelFix(Node x)
        {
            while (x != null && x != top && x.color == "black")
            {

                if (x == x.parentNode.left)
                {
                    Node w = x.parentNode.right;
                    if (w.color == "red")
                    {
                        w.color = "black";
                        x.parentNode.color = "red";
                        LeftRotation(x.parentNode);
                        w = x.parentNode.right;
                    }
                    if ( w.left.color == "black" && w.right.color == "black")
                    {
                        w.color = "red";
                        x = x.parentNode;
                    }
                    else if (w.right.color == "black")
                    {
                        w.left.color = "black";
                        w.color = "red";
                        RightRotation(w);
                        w = x.parentNode.right;
                    }
                    w.color = x.parentNode.color;
                    x.parentNode.color = "black";
                    w.right.color = "black";
                    LeftRotation(x.parentNode);
                    x = top;
                }
                else
                {
                    Node w = x.parentNode.left;
                    if (w.color == "red")
                    {
                        w.color = "black";
                        x.parentNode.color = "red";
                        LeftRotation(x.parentNode);
                        w = x.parentNode.left;
                    }
                    if (w.left.color == "black" && w.right.color == "black")
                    {
                        w.color = "red";
                        x = x.parentNode;
                    }
                    else if (w.left.color == "black")
                    {
                        w.right.color = "black";
                        w.color = "red";
                        RightRotation(w);
                        w = x.parentNode.left;
                    }
                    w.color = x.parentNode.color;
                    x.parentNode.color = "black";
                    w.left.color = "black";
                    LeftRotation(x.parentNode);
                    x = top;
                }
            }
            if (x != null)
                x.color = "black";
        
        }

        public void InTree(int data)
        {
            Node node = this.Find(data, top);
            if (node.num == -1)
            {
                Console.WriteLine("there is no such node");
            }
            else { Console.WriteLine("Node found {0} height {1}", node.num, node.height); }

        }
        private Node Tree_Min(Node node) 
        {
    
            while(node.left != null)
                node = node.left;                       
            return node;
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

    }
}
