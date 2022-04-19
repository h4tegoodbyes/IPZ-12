using System;
using static System.Console;
using System.Diagnostics;


namespace ASD_Lab1_MychkovskyiBogdan
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WriteLine("\nASD  Lab 1  Mychkovskyi Bogdan\n\nEnter size of arrays: ");
            int s = Convert.ToInt32(ReadLine());
            int[] arr = new int[s];
            int check;
            Generate(arr);
            foreach (var i in arr) 
                Write(i + ", ");
            WriteLine("\nInput number to search: ");
            int search = Convert.ToInt32(ReadLine());
            while (true)
            {
                WriteLine("Choose the task (1 - 4):");
                check = Convert.ToInt32(ReadLine());
                switch (check)
                {
                    case 1: Task1(arr, search);
                        break;
                    case 2: Task2(arr, search);
                        break;
                    case 3: Task3(arr, search);
                        break;
                    case 4: Task4(arr, search);
                        break;
                    case 0: return;
                    default: WriteLine("Input correct numbers");
                        break;
                }
            }
        }

        private static void Generate(int[] arr)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(0, 500);
            }
        }

        static void Task1(int[] arr, int x)
        {
            Node list = new Node();
            int i;
            for (i = 0; i < arr.Length; i++)
            {
                list.Add(arr[i]);
            }
            var time = new Stopwatch();
            
            WriteLine("\nTask 1. Linear search\nUsing array:");
            time.Start();
            i = 0;
            while (i < arr.Length)
            {
                if (arr[i] == x) 
                    break;
                i++;
            }
            time.Stop();

            if (i == arr.Length)
                WriteLine($"Element not found. Time spent: {time.Elapsed}");
            else 
                WriteLine($"Element to search: {arr[i]} Index: {i} Time: {time.Elapsed}");

            WriteLine("Using list:");
            
            time.Start();
            list = list.Head;
            int index = -1;
            while (list != null)
            {
                index++;
                if (list.Data == x)
                    break;
                list = list.NextInd;
            }
            time.Stop();
            if (list==null)
                WriteLine($"Element not found. Time spent: {time.Elapsed}");
            else 
                WriteLine($"Element to search: {list.Data} Index: {index} Time: {time.Elapsed}");
        }
        static void Task2(int[] arr, int x)
        {
            Node list = new Node();
            int i;
            for (i = 0; i < arr.Length; i++)
            {
                list.Add(arr[i]);
            }
            
            WriteLine("\nTask 2. Barrier search\nUsing array:");
            var t = new Stopwatch();
            int[] check1 = new int[arr.Length + 1];
            arr.CopyTo(check1, 0);
            t.Start();
            check1[check1.Length - 1] = x;
            i = 0;
            while (check1[i] != x)
            {
                i++;
            }

            t.Stop();
            if (i == arr.Length)
                WriteLine($"Element not found. Time spent: {t.Elapsed}");
            else 
                WriteLine($"Element to search: {arr[i]} Index: {i} Time: {t.Elapsed}");
            
            
            WriteLine("Using list:");
            list = list.Head;
            t.Start();
            list.Add(x);
            int index = 0;
            while (list.Data != x)
            {
                index++;
                list = list.NextInd;
            }
            t.Stop();
            if (list.Count == index)
                WriteLine($"Element not found. Time spent: {t.Elapsed}");
            else 
                WriteLine($"Element to search: {list.Data} Index: {index} Time: {t.Elapsed}");
            
        }

        static int Element(Node list, int index)
        {
            int count = -1;
            Node newEl = list.Head;
            while (newEl != null)
            {
                count++;
                if (count == index)
                    return newEl.Data;
                newEl = newEl.NextInd;
            }

            return -1;
        }
        static void Task3(int[] arr, int x)
        { 
            Node list = new Node();
            var t = new Stopwatch();
            
            int[] sorted = new int[arr.Length];
            arr.CopyTo(sorted,0);
            Array.Sort(sorted);
            
            for (int i = 0; i < sorted.Length; i++)
            {
                list.Add(sorted[i]);
            }
            
            
            WriteLine("\nTask 3. Binary search\nUsing array:");
            int begin = 0, end = arr.Length, c=0;
            bool bb = false;
            t.Start();
            while (begin < end)
            {
                c = begin + (end - begin) / 2;
                if (x < sorted[c]) end = c;
                else if (x > sorted[c]) begin = c + 1;
                else
                {
                    bb = true;
                    break;
                }
            }
            t.Stop();
            if (!bb)
                WriteLine($"Element not found. Time spent: {t.Elapsed}");
            else 
                WriteLine($"Element to search: {sorted[c]} Index: {c} Time: {t.Elapsed}");
            
            
            WriteLine("Using list:");
            begin = 0;
            end = sorted.Length-1;
            c = 0;
            bb = false;
            t.Start();
            while (begin < end)
            {
                c = (int) (begin + (end - begin) / 2);
                if (x < Element(list, c)) end = c;
                else if (x > Element(list, c)) begin = c + 1;
                else
                {
                    bb = true;
                    break;
                }
            }
            t.Stop();
            if (!bb)
                WriteLine($"Element not found. Time spent: {t.Elapsed}");
            else 
                WriteLine($"Element to search: {x} Index: {c} Time: {t.Elapsed}");
        }
        static void Task4(int[] arr, int x)
        {
            Node list = new Node();
            var t = new Stopwatch();
            
            int[] sorted = new int[arr.Length];
            arr.CopyTo(sorted,0);
            Array.Sort(sorted);
            
            for (int i = 0; i < sorted.Length; i++)
            {
                list.Add(sorted[i]);
            }

            WriteLine("\nTask 4. Binary search with gold cut\nUsing array:");
            int begin = 0, end = arr.Length, c = 0;
            bool bb = false;
            t.Start();
            while (begin < end)
            {
                c = (int) (begin + (end - begin) / 1.61803398);
                if (x < sorted[c]) end = c;
                else if (x > sorted[c]) begin = c + 1;
                else
                {
                    bb = true;
                    break;
                }
            }
            t.Stop();
            if (!bb)
                WriteLine($"Element not found. Time spent: {t.Elapsed}");
            else 
                WriteLine($"Element to search: {sorted[c]} Index: {c} Time: {t.Elapsed}");
            
            
            WriteLine("Using list:");
            begin = 0;
            end = sorted.Length;
            c = 0;
            bb = false;
            t.Start();
            while (begin < end)
            {
                c = (int) (begin + (end - begin) / 1.61803398);
                if (x < Element(list, c)) end = c;
                else if (x > Element(list, c)) begin = c + 1;
                else
                {
                    bb = true;
                    break;
                }
            }
            t.Stop();
            if (!bb)
                WriteLine($"Element not found. Time spent: {t.Elapsed}");
            else 
                WriteLine($"Element to search: {x} Index: {c} Time: {t.Elapsed}");
        }
    }
}