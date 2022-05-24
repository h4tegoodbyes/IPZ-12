using System;

namespace Console_Lab1
{
    public class Show
    {
        private static void ShowResults(int resultIndex, string executeTime, int operationsAmount)
        {
            Console.WriteLine($"    Result index: {resultIndex}");
            Console.WriteLine($"    Execute time: {executeTime}");
            Console.WriteLine($"    Operations amount: {operationsAmount}");
        }

        public void ShowAllResults(
            int resultIndexOfArray, string executeTimeOfArray, int operationsAmountOfArray,
            int resultIndexOfLinkedList, string executeTimeOfLinkedList, int operationsAmountOfLinkedList
            )
        {
            Console.WriteLine("Array:");
            ShowResults(resultIndexOfArray, executeTimeOfArray, operationsAmountOfArray);

            Console.WriteLine();

            Console.WriteLine("Linked list:");
            ShowResults(resultIndexOfLinkedList, executeTimeOfLinkedList, operationsAmountOfLinkedList);
        }
    }
}