using System;
using System.Diagnostics;

namespace Console_Lab1
{
    internal class Program
    {
        private static LinkedList<int> CreateLinkedListByArray(int[] array)
        {
            var linkedList = new LinkedList<int>();

            foreach (var element in array)
                linkedList.AddLast(element);

            return linkedList;
        }

        private static int[] GenerateArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
                array[i] = random.Next(1, 1000000000);

            return array;
        }

        private static int[] GenerateSortedArray(int size)
        {
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
                array[i] = i + 1;

            return array;
        }

        public static void Main()
        {
            Show show = new Show();

            string userAnswer = "";

            while (userAnswer != "stop")
            {
                Console.Write("Task: ");
                userAnswer = Console.ReadLine();

                Console.Write("Enter size of the data structure: ");
                int size = Convert.ToInt32(Console.ReadLine());

                int[] array;
                if (userAnswer == "1" || userAnswer == "2")
                    array = GenerateArray(size);
                else
                    array = GenerateSortedArray(size);

                var linkedList = CreateLinkedListByArray(array);

                Console.Write("Index of element to search in the data structure: ");
                int indexOfElement = Convert.ToInt32(Console.ReadLine());
                SearchInArray searchInArray = new SearchInArray();

                int elementToFind = -1;
                if (indexOfElement < size)
                    elementToFind = array[indexOfElement];

                Console.WriteLine();

                switch (userAnswer)
                {
                    case "1":
                        Stopwatch stopwatchOfArray = Stopwatch.StartNew();
                        int resultIndexOfArray = searchInArray.LinearSearch(array, elementToFind);
                        stopwatchOfArray.Stop();
                        string executeTimeOfArray = Convert.ToString(stopwatchOfArray.Elapsed);

                        Stopwatch stopwatchOfLinkedList = Stopwatch.StartNew();
                        int resultIndexOfLinkedList = linkedList.LinearSearch(elementToFind);
                        stopwatchOfLinkedList.Stop();
                        string executeTimeOfLinkedList = Convert.ToString(stopwatchOfLinkedList.Elapsed);

                        Console.WriteLine("-------- Linear search --------");
                        show.ShowAllResults(
                            resultIndexOfArray, executeTimeOfArray, resultIndexOfArray+1,
                            resultIndexOfLinkedList, executeTimeOfLinkedList, resultIndexOfLinkedList+1
                        );
                        Console.WriteLine("------------------------------------");

                        break;
                    case "2":
                        stopwatchOfArray = Stopwatch.StartNew();
                        resultIndexOfArray = searchInArray.BarrierSearch(array, elementToFind);
                        stopwatchOfArray.Stop();
                        executeTimeOfArray = Convert.ToString(stopwatchOfArray.Elapsed);

                        stopwatchOfLinkedList = Stopwatch.StartNew();
                        resultIndexOfLinkedList = linkedList.BarrierSearch(elementToFind);
                        stopwatchOfLinkedList.Stop();
                        executeTimeOfLinkedList = Convert.ToString(stopwatchOfLinkedList.Elapsed);

                        Console.WriteLine("-------- Barrier search --------");
                        show.ShowAllResults(
                            resultIndexOfArray, executeTimeOfArray, resultIndexOfArray+1,
                            resultIndexOfLinkedList, executeTimeOfLinkedList, resultIndexOfLinkedList+1
                        );
                        Console.WriteLine("------------------------------------");

                        break;
                    case "3":
                        int operationsAmountOfArray;
                        stopwatchOfArray = Stopwatch.StartNew();
                        resultIndexOfArray = searchInArray.BinarySearch(array, elementToFind, out operationsAmountOfArray);
                        stopwatchOfArray.Stop();
                        executeTimeOfArray = Convert.ToString(stopwatchOfArray.Elapsed);

                        int operationsAmountOfLinkedList;
                        stopwatchOfLinkedList = Stopwatch.StartNew();
                        resultIndexOfLinkedList = linkedList.BinarySearch(elementToFind, out operationsAmountOfLinkedList);
                        stopwatchOfLinkedList.Stop();
                        executeTimeOfLinkedList = Convert.ToString(stopwatchOfLinkedList.Elapsed);

                        Console.WriteLine("-------- Binary search --------");
                        show.ShowAllResults(
                            resultIndexOfArray, executeTimeOfArray, operationsAmountOfArray,
                            resultIndexOfLinkedList, executeTimeOfLinkedList, operationsAmountOfLinkedList
                        );
                        Console.WriteLine("------------------------------------");

                        break;
                    case "4":
                        stopwatchOfArray = Stopwatch.StartNew();
                        resultIndexOfArray = searchInArray.BinarySearchWithGoldenRatio(array, elementToFind, out operationsAmountOfArray);
                        stopwatchOfArray.Stop();
                        executeTimeOfArray = Convert.ToString(stopwatchOfArray.Elapsed);

                        stopwatchOfLinkedList = Stopwatch.StartNew();
                        resultIndexOfLinkedList = linkedList.BinarySearchWithGoldenRatio(elementToFind, out operationsAmountOfLinkedList);
                        stopwatchOfLinkedList.Stop();
                        executeTimeOfLinkedList = Convert.ToString(stopwatchOfLinkedList.Elapsed);

                        Console.WriteLine("-------- Binary search with golden ratio --------");
                        show.ShowAllResults(
                            resultIndexOfArray, executeTimeOfArray, operationsAmountOfArray,
                            resultIndexOfLinkedList, executeTimeOfLinkedList, operationsAmountOfLinkedList
                        );
                        Console.WriteLine("------------------------------------");
                        
                        break;
                }
            }
        }
    }
}