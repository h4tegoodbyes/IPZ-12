using System;
using System.Diagnostics;

namespace Lab_1_ASD
{
     

    class Program
    {
        static void PrintArr(int[] arr) { Console.WriteLine("[ " + string.Join(" ", arr) + " ]"); }
        static int[] ChooseSort(int[] arr)
        {
            int temp = 0;

            for (int j = 0; j < arr.Length; j++)
            {
                int low = arr[j];
                for (int i = j; i < arr.Length; i++)
                    if (arr[i] < low)
                    {
                        low = arr[i];
                        temp = i;
                    }

                if (low != arr[j])
                {
                    arr[temp] = arr[j];
                    arr[j] = low;
                }
            }
            return arr;
        }
        static void LinearSearch(int[] arr, int num)
        {
            var time = new Stopwatch();
            time.Start();
            int j = 0;
            bool found = false;

            while (j < arr.Length)
            {
                if (arr[j] == num)
                {
                    found = true;
                    Console.WriteLine("Found num index: " + j);
                    time.Stop();
                    Console.WriteLine("Time spent: " + time.Elapsed);
                    break;
                }
                j++;
            }
            if (found == false)
            {
                Console.WriteLine("Element not found");
                time.Stop();
                Console.WriteLine("Time spent: " + time.Elapsed);
            }
        }
        static void BarrSearch(int[] arr, int num)
        {           
            int[] new_arr = new int[arr.Length + 1];
            Array.Copy(arr, new_arr, arr.Length);
            new_arr[arr.Length] = num;
            int i = 0;
            var time = new Stopwatch();
            time.Start();   
            while (new_arr[i] != num) { i++; }
            time.Stop();
            Console.WriteLine("Found num index: " + i);                
            Console.WriteLine("Time spent: " + time.Elapsed);      
        }
        static void BinarySearch(int[] arr, int num)
        {
            ChooseSort(arr);
            int[] temp = new int[arr.Length];
            Array.Copy(arr, temp, arr.Length);
            var time = new Stopwatch();
            time.Start();
            int start = 0;
            int end = temp.Length - 1;
            bool found = false;
            while (start <= end && found == false)
            {
                int mid = (start + end) / 2;
                if (temp[mid] == num)
                {
                    found = true;
                    Console.WriteLine("Found num " + num);
                    time.Stop();
                    Console.WriteLine("Time spent: " + time.Elapsed);
                    break;
                }
                else if (temp[mid] < num) { start = mid + 1; }
                else { end = mid - 1; }
            }
            if (found == false)
            {
                Console.WriteLine("Number not found");
                time.Stop();
                Console.WriteLine("Time spent: " + time.Elapsed);
            }
           
        }
        static void BinaryGolden(int[] arr, int num) 
        {
            ChooseSort(arr);
            int[] temp = new int[arr.Length];
            Array.Copy(arr, temp, arr.Length);
            
            var time = new Stopwatch();
            time.Start();
            int start = 0;
            int end = temp.Length - 1;
            bool found = false;
            while (start <= end && found == false)
            {
                int mid = (int)(start + (end - start) / 1.6);
                if (temp[mid] == num)
                {
                    found = true;
                    Console.WriteLine("Found num " + num);
                    time.Stop();
                    Console.WriteLine("Time spent: " + time.Elapsed);
                    break;
                }
                else if (temp[mid] < num) { start = mid + 1; }
                else { end = mid - 1; }
            }
            if (found == false)
            {
                Console.WriteLine("Number not found");
                time.Stop();
                Console.WriteLine("Time spent: " + time.Elapsed);
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Start\n");
                Console.WriteLine("Enter size:");
                int size = Convert.ToInt32(Console.ReadLine());
                Node linkedlist = new Node();
                Node templist = new Node();
                int[] arr = new int[size];
                int a;
                Random numRand = new Random();

                Console.WriteLine("Input borders");
                int bord1 = Convert.ToInt32(Console.ReadLine());
                int bord2 = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < size; i++)
                {
                    a = numRand.Next(bord1, bord2);
                    linkedlist.AddLast(a);
                    templist.AddLast(a);
                    arr[i] = a;
                }               

                PrintArr(arr);
                Console.WriteLine("\n1.Linear search\n2.Search with a barrier\n3.Binary search\n4.Binary search with golden rule");
                int ch = 1;
                while (ch != 0)
                {
                    Console.WriteLine("Choose search algorythm:\n");                    
                    ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 0:
                            Console.WriteLine("End");
                            return;
                        case 1:
                            Console.WriteLine("Input num :");
                            int num = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Array:");
                            LinearSearch(arr, num);
                            Console.WriteLine("Linked list:");
                            linkedlist.Linear(num);
                            break;
                        case 2:
                            Console.WriteLine("Input num :");
                            num = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Array:");
                            BarrSearch(arr, num);
                            Console.WriteLine("Linked list:");
                            linkedlist.AddLast(num);
                            linkedlist.Barrier(num);
                            break;
                        case 3:
                            Console.WriteLine("Input num :");
                            num = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Array:");
                            BinarySearch(arr, num);
                            Console.WriteLine("Linked list:");
                            templist.LinkSortChoose();
                            templist.Binary(num);
                            break;
                        case 4:
                            Console.WriteLine("Input num :");
                            num = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Array:");
                            BinaryGolden(arr, num);
                            Console.WriteLine("Linked list:");
                            templist.LinkSortChoose();
                            templist.BinaryGolden(num, linkedlist.Size());

                            break;
                        case 5:
                            PrintArr(arr);
                            break;
                    }
                }
            }              
        }
    }
}