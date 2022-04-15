using System;
using System.Diagnostics;

namespace ASD1_AvruschenkoTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Avruschenko Dmytro\nIPZ-12.1");
            int[] arr100el = new int[1000];
            Rand(arr100el, arr100el.Length, -500, 500);
            Node list100 = new Node();
            for (int i = 0; i < arr100el.Length; i++) { list100.AddLast(arr100el[i]); }
            Console.WriteLine("Input element for array and list ");
            int element100 = Convert.ToInt32(Console.ReadLine());
            string choose;
            Console.WriteLine("Choose the algorithm\n1-linear search\n2-barrier search\n3-binary search\n4-binary search by golden ratio\n5-if you want to change searching elements\n6-if you want to look on sorted arrays\n0-to exit");
            while (true)
            {
                Console.WriteLine();
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        Task1Linear( arr100el, list100, element100);
                        break;
                    case "2":
                        Task2Barrier( arr100el, element100);
                        break;
                    case "3":
                        Task3Binary( arr100el, element100);
                        break;
                    case "4":
                        Task4BinaryGolden( arr100el, element100);
                        break;
                    case "5":
                        Console.WriteLine("Input element for array and list ");
                        element100 = Convert.ToInt32(Console.ReadLine());
                        break;
                    case "6":
                        SortArray( arr100el);
                        break;
                    case "0":
                        Console.WriteLine("Goodbye");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Wrong input data");
                        break;
                }
            }
        }
        static void SortArray( int[] arr100el)
        {
            int[] arr100 = new int[arr100el.Length]; arr100el.CopyTo(arr100, 0); Array.Sort(arr100);
            Output(arr100);
        }
        static void Linear(int[] arr, int element)
        {
            var timer = Stopwatch.StartNew();

            int i = 0;
            while ((i < arr.Length))
            {
                if (arr[i] == element) { break; }
                i++;
            }
            timer.Stop();
            if (i == arr.Length) { Console.WriteLine("The element is not found"); }
            else { Console.WriteLine("The element has index: " + i); }
            Console.WriteLine($"You used for array with {arr.Length - 1  } elements {timer.Elapsed}");           
        }
        static void Linear(Node list, int element)
        {
            var sw = Stopwatch.StartNew();

            int i = 0;
            while ((i < list.Count))
            {
                if (list[i] == element) { break; }
                i++;
            }
            sw.Stop();
            if (i == list.Count) { Console.WriteLine("The element is not found"); }
            else { Console.WriteLine("The element has index: " + i); }
            Console.WriteLine($"You used for list with {list.Count - 1} elements {sw.Elapsed}");
        }
        static void Task1Linear(int[] arr100el, Node list100, int element100)
        {
            Console.WriteLine("Lets use linear search for arrays and list on 1000 el");
            Linear(arr100el, element100);
            Linear(list100, element100);
        }
        static void Barrier(int[] arr, int element)
        {
            var timer = Stopwatch.StartNew();

            int[] arrch = new int[arr.Length + 1]; arr.CopyTo(arrch, 0);
            arrch[arrch.Length - 1] = element;
            int i = 0;
            while (arrch[i] != element)
            {
                i++;
            }
            timer.Stop();
            if (i == arrch.Length - 1) { Console.WriteLine("The element is not found"); }
            else { Console.WriteLine("The element has index: " + i); }
            Console.WriteLine($"You used for array with {arrch.Length - 1} elements {timer.Elapsed}");
        }
        static void BarrierList(int[] arr, int element)
        {
            var listch = new Node();
            for (int j = 0; j < arr.Length; j++) { listch.AddLast(arr[j]); }
            var sw = Stopwatch.StartNew();

            listch.AddLast(element);
            int i = 0;
            while (listch[i] != element)
            {
                i++;
            }
            sw.Stop();
            if (i == listch.Count - 1) { Console.WriteLine("The element is not found"); }
            else { Console.WriteLine("The element has index: " + i); }
            Console.WriteLine($"You used for list with {listch.Count - 1} elements {sw.Elapsed}");
        }
        static void Task2Barrier( int[] arr100el, int element100)
        {
            Console.WriteLine("Lets use barrier search for arrays and list on 1000 el");
            Barrier(arr100el, element100);
            BarrierList(arr100el, element100);
        }
        static void Binary(int[] arr, int element, double f = 2)
        {
            int[] arrch = new int[arr.Length]; arr.CopyTo(arrch, 0); Array.Sort(arrch);
            var timer = Stopwatch.StartNew();

            bool find = false;
            int mid = 0;
            int begin = 0; int end = arrch.Length - 1;
            //if(element<arrch[0]) { goto label; }
            while (begin < end)
            {
                mid = (int)(begin + (end - begin) / f);
               
                if (element < arrch[mid]) { end = mid; }
                else if (element > arrch[mid]) { begin = mid + 1; }
                else { find = true; break; }
            }
            //label:
            timer.Stop();
            if (find == true) { Console.WriteLine("The element has index: " + mid); }
            else { Console.WriteLine("The element doesn`t found"); }
            Console.WriteLine($"You used for array with {arrch.Length - 1} elements {timer.Elapsed}");
        }
        static void BinaryList(int[] arr, int element, double f = 2)
        {
            var listch = new Node();
            int[] arrsort = new int[arr.Length]; Array.Copy(arr, arrsort, arr.Length); Array.Sort(arrsort);
            for (int j = 0; j < arr.Length; j++) { listch.AddLast(arrsort[j]); }
            var sw = Stopwatch.StartNew();

            bool find = false;
            int mid = 0;
            int begin = 0; int end = listch.Count - 1;
            //if (element < listch[0]) { goto stop; }
            while (begin < end)
            {
                mid = (int)(begin + (end - begin) / f);
                
                if (element < listch[mid]) { end = mid; }
                else if (element > listch[mid]) { begin = mid + 1; }
                else { find = true; break; }
            }
            //stop:
            sw.Stop();
            if (find == true) { Console.WriteLine("The element has index: " + mid); }
            else { Console.WriteLine("The element doesn`t found"); }
            Console.WriteLine($"You used for list with {listch.Count - 1} elements {sw.Elapsed}");
        }
        static void Task3Binary( int[] arr100el, int element100)
        {
            Console.WriteLine("Lets use binary search for arrays and list on 1000 el");
            Binary(arr100el, element100);
            BinaryList(arr100el, element100);
        }
        static void Task4BinaryGolden( int[] arr100el, int element100)
        {
            Console.WriteLine("Lets use binarygolden search for arrays and list on 1000 el");
            Binary(arr100el, element100, 1.61803398);
            BinaryList(arr100el, element100, 1.61803398);
        }
        static void Rand(int[] sort, int amount, int first, int last)
        {
            Random random = new Random();
            for (int i = 0; i < amount; i++)
            {
                sort[i] = random.Next(first, last);
            }
            Output(sort);
        }
        static void Output(int[] sort)
        {
            for (int i = 0; i < sort.Length; i++)
            {
                Console.Write(sort[i] + ";  ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}