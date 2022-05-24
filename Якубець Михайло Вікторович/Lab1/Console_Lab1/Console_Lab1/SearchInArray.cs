using System;

namespace Console_Lab1
{
    public class SearchInArray
    {
        private const double F = 1.6180339887498948482;

        public int LinearSearch(int[] array, int elementToSearch)
        {
            int i = 0, resultIndex = 0;
            bool found = false;

            while (i < array.Length && !found)
            {
                if (array[i] == elementToSearch)
                {
                    resultIndex = i;
                    found = true;
                }

                i++;
            }

            if (!found)
                return -1;

            return resultIndex;
        }

        public int BarrierSearch(int[] array, int elementToSearch)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length-1] = elementToSearch;

            int i = 0;

            while (array[i] != elementToSearch)
                i++;

            if (i == array.Length-1)
                return -1;

            return i;
        }

        public int BinarySearch(int[] array, int elementToSearch, out int operationsAmount)
        {
            int left = 0, m = -1;
            int right = array.Length - 1;
            bool found = false;

            operationsAmount = 0;

            while (left <= right && !found)
            {
                m = Convert.ToInt32((left + right) / 2);
                operationsAmount++;
                
                if (array[m] == elementToSearch)
                    found = true;
                else if (array[m] < elementToSearch)
                    left = m + 1;
                else
                    right = m - 1;
            }

            if (!found)
                return -1;

            return m;
        }

        public int BinarySearchWithGoldenRatio(int[] array, int elementToSearch, out int operationsAmount)
        {
            int left = 0, m = -1;
            int right = array.Length - 1;
            bool found = false;

            operationsAmount = 0;

            while (left <= right && !found)
            {
                m = operationsAmount == 0 ? Convert.ToInt32(left * F) : Convert.ToInt32((left + right) / 2);

                operationsAmount++;

                if (array[m] == elementToSearch)
                    found = true;
                else if (array[m] < elementToSearch)
                    left = m + 1;
                else
                    right = m - 1;
            }

            if (!found)
                return -1;

            return m;
        }
    }
}