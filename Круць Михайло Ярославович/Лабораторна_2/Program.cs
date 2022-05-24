using System;
using System.Diagnostics;

namespace Binary_tree
{


    class Program
    {

        static int Menu()
        {
            Console.WriteLine("Choose what to do");
            Console.WriteLine("1. AddNode");
            Console.WriteLine("2. Search Node");
            Console.WriteLine("3. Delete Node");
            Console.WriteLine("4. Print ");

            Console.Write("Input ");
            int ans = Convert.ToInt32(Console.ReadLine());
            return ans;
        }
        static void Task1() 
        {
            Tree tree = new Tree();
            int ch = 1;
            while (true)
            {
                ch = Menu();
                switch (ch)
                {
                    case 1:
                        
                        Console.WriteLine("Random(1) or by one(else)");
                        int type = Convert.ToInt32(Console.ReadLine());
                        if (type == 1)
                        {
                            Random random = new Random();
                            Console.WriteLine("input amount");
                            int size = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < size; i++)
                            {
                                tree.Add(random.Next(1, 50));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Input how many nodes you want to add: ");
                            int size = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < size; i++)
                            {
                                int num = Convert.ToInt32(Console.ReadLine());
                                tree.Add(num);
                            }
                               

                        }
                        break;
                    case 2:
                        Console.WriteLine("Input Num");
                        int number = Convert.ToInt32(Console.ReadLine());
                        tree.InTree(number);
                        break;
                    case 3:
                        Console.WriteLine("Input Num");
                        int temp = Convert.ToInt32(Console.ReadLine());
                        tree.Delete(temp);
                        break;
                    case 4:
                        Console.WriteLine("BST tree in PostOrder");
                        tree.PostOrder();
                        break;
                    case 0:
                        return;
                }
            }
            
        }
        static void Task2()
        {
            RedBlack redBlack = new RedBlack();
            int ch = 1;
            while (true)
            {
                ch = Menu();
                switch (ch)
                {
                    case 1:

                        Console.WriteLine("Random(1) or by one(else)");
                        int type = Convert.ToInt32(Console.ReadLine());
                        if (type == 1)
                        {
                            Random random = new Random();
                            Console.WriteLine("input amount");
                            int size = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < size; i++)
                            {
                                redBlack.Add(random.Next(1, 100));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Input how many nodes you want to add: ");
                            int size = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < size; i++)
                            {
                                int num = Convert.ToInt32(Console.ReadLine());
                                redBlack.Add(num);                           
                            }
                            
                        }
                        break;
                    case 2:
                        Console.WriteLine("Input Num");
                        int number = Convert.ToInt32(Console.ReadLine());
                        redBlack.InTree(number);
                        break;
                    case 3:
                        Console.WriteLine("Input Num");
                        int temp = Convert.ToInt32(Console.ReadLine());
                        redBlack.Delete(temp);
                        break;
                    case 4:
                        Console.WriteLine("Red and Black tree in PreOrder");
                        redBlack.PreOrder();
                        break;
                    case 0:
                        return;
                }
            }
        }
        static void Task3()
        {
            AVL avl = new AVL();
            int ch = 1;
            while (true)
            {
                ch = Menu();
                switch (ch)
                {
                    case 1:

                        Console.WriteLine("Random(1) or by one(else)");
                        int type = Convert.ToInt32(Console.ReadLine());
                        if (type == 1)
                        {
                            Random random = new Random();
                            Console.WriteLine("input amount");
                            int size = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < size; i++)
                            {
                                avl.Add(random.Next(1, 100));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Input how many nodes you want to add: ");
                            int size = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < size; i++)
                            {
                                int num = Convert.ToInt32(Console.ReadLine());
                                avl.Add(num);
                            }
                                

                        }
                        break;
                    case 2:
                        Console.WriteLine("Input Num");
                        int number = Convert.ToInt32(Console.ReadLine());
                        avl.InTree(number);
                        break;
                    case 3:
                        Console.WriteLine("Input Num");
                        int temp = Convert.ToInt32(Console.ReadLine());
                        avl.Delete(temp);
                        break;
                    case 4:
                        Console.WriteLine("AVL tree in PreOrder");
                        avl.PreOrder();
                        break;
                    case 0:
                        return;

                }
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("ASD Lab-2 Mykhailo Kruts");
            int ch = 1;
            while (true)
            {   
                Console.WriteLine("Choose data structure");
                Console.WriteLine("1. BST (binary search tree)");
                Console.WriteLine("2. Red and Black tree");
                Console.WriteLine("3. AVL tree");
               
                Console.Write("Input ");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 0:
                        return;
                }
            }

        }
    }
}