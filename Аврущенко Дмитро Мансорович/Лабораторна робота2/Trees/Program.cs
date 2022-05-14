using System;


namespace BinaryTrees
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("IPZ 12/1 Avruschenko Dmytro");
            string a;
            while (true)
            {
                Console.WriteLine("\nChoose the structure:\n1 - BST;\n2 - RBT\n3 - AVL\n4 - SplayTree");
                a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        BST();
                        break;
                    case "2":
                        RBT();
                        break;
                    case "3":
                        AVL();
                        break;
                    case "4":
                        SPL();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Wrong input DATA");
                        break;
                }

            }



        }

        static void BST()
        {
            Console.WriteLine("\nBS Tree");
            BinaryTree<int> treeBST = new BinaryTree<int>(8);
            treeBST.AddNode(3);
            treeBST.AddNode(10);
            treeBST.AddNode(1);
            treeBST.AddNode(6);
            treeBST.AddNode(4);
            treeBST.AddNode(7);
            treeBST.AddNode(14);
            treeBST.AddNode(13);
            

            //Random r = new Random();
            //for (int i = 0; i < 15; i++)
            //    treeRB.AddNode(r.Next(0, 1000));
            //treeRB.DisplayTree();

            treeBST.DisplayTree();
            Console.WriteLine(treeBST.Max());
            Console.WriteLine(treeBST.Min());

            Console.WriteLine("After deleting 6");
            treeBST.RemoveNode(6);
            treeBST.DisplayTree();
            Console.ReadLine();
        }

        static void RBT()
        {
            Console.WriteLine("\nRB Tree");
            Console.WriteLine("Red-Black Trees: ");
            RBTree<int> treeRBT = new RBTree<int>();
            treeRBT.AddNode(8);
            treeRBT.AddNode(3);
            treeRBT.AddNode(10);
            treeRBT.AddNode(1);
            treeRBT.AddNode(6);
            treeRBT.AddNode(4);
            treeRBT.AddNode(7);
            treeRBT.AddNode(14);
            treeRBT.AddNode(13);

            //Random r = new Random();
            //for (int i = 0; i < 10; i++)
            //    treeRB.AddNode(r.Next(0, 1000));
            //Console.WriteLine();

            treeRBT.DisplayTree();

            Console.WriteLine(treeRBT.Max());
            Console.WriteLine(treeRBT.Min());

            Console.WriteLine("After deleting 6");
            treeRBT.RemoveNode(6);
            treeRBT.DisplayTree();
            Console.ReadLine();
        }

        static void AVL()
        {
            Console.WriteLine("\nAVL Tree");
            AVLTree<int> treeAVL = new AVLTree<int>();
            treeAVL.AddNode(8);
            treeAVL.AddNode(3);
            treeAVL.AddNode(10);
            treeAVL.AddNode(1);
            treeAVL.AddNode(6);
            treeAVL.AddNode(4);
            treeAVL.AddNode(7);
            treeAVL.AddNode(14);
            treeAVL.AddNode(13);
            //Random r = new Random();
            //for (int i = 0; i < 15; i++)
            //    treeAVL.AddNode(r.Next(0, 1000));
            //Console.WriteLine();
            treeAVL.DisplayTree();
            Console.WriteLine(treeAVL.Max());
            Console.WriteLine(treeAVL.Min());

            Console.WriteLine("After deleting 6");
            treeAVL.RemoveNode(6);
            treeAVL.DisplayTree();
            Console.ReadLine();
        }

        static void SPL()
        {
            Console.WriteLine("\nSplayTree");
            SplayTree<int> treeSPL = new SplayTree<int>();
            treeSPL.AddNode(8);
            treeSPL.AddNode(3);
            treeSPL.AddNode(10);
            treeSPL.AddNode(1);
            treeSPL.AddNode(6);
            treeSPL.AddNode(4);
            treeSPL.AddNode(7);
            treeSPL.AddNode(14);
            treeSPL.AddNode(13);

            treeSPL.DisplayTree();
            Console.WriteLine(treeSPL.Max());
            Console.WriteLine(treeSPL.Min());

            Console.WriteLine("After deleting 6");
            treeSPL.RemoveNode(6);
            treeSPL.DisplayTree();
            treeSPL.Search(7);
            Console.ReadLine();
        }
    }
}
/*
-----------------------------------------------------------
            BST:
                        8
                    3       10
                   1  6       14
                     4 7    13

Preorder:  8 3 1 6 4 7  10 14 13
Postorder: 1 4 7 6 3 13 14 10 8
Inorder:   1 3 4 6 7 8  10 13 14

After deleting 6: 
                        8
                    3       10
                   1  7       14
                     4      13

-----------------------------------------------------------

            RBT:
                          8B
                     3R        13B
                   1B  6B    10R  14R
                      4R 7R    

Preorder:  8 3 1 6 4 7  13 10 14
Postorder: 1 4 7 6 3 10 14 13 8
Inorder:   1 3 4 6 7 8  10 13 14

After deleting 6:

                          8B
                     3R        13B
                   1B  4B    10R  14R
                         7R    

-----------------------------------------------------------

            AVL:
                          6
                     3        8
                   1   4    7   13
                               10 14 

Preorder:  6 3 1 4 8  7  13 10 14
Postorder: 1 4 3 7 10 14 13 8  6
Inorder:   1 3 4 6 7  8  10 13 14

After deleting 6:
                          7
                     3        13
                   1   4    8    14
                             10 

-----------------------------------------------------------

            Splay:
                          13
                       8     14
                     7   10    
                   6
                 4
               1
                 3

Preorder:  13 8 7 4 1 3 10 14
Postorder: 3 1 4 7 10 8 14 13
Inorder:   1 3 4 7 8 10 13 14

After deleting 6:
                          13
                       8     14
                     7   10    
                   4
                 1
                   3

After Searching(7):                                        
                                                           
                          7                                
                       6     8                             
                     4         10                          
                   1              13                       
                     3               14                    
                                                           
                                                           
-----------------------------------------------------------
*/