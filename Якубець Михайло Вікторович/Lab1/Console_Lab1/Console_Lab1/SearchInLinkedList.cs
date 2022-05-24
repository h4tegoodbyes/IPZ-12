using System;

namespace Console_Lab1
{
    public partial class LinkedList<T>
    {
        private const double F = 1.6180339887498948482;
        
        public int LinearSearch(T elementToSearch)
        {
            int i = 0, resultIndex = 0;
            bool found = false;

            foreach (var el in this)
            {
                if (!found)
                {
                    if (el.Equals(elementToSearch))
                    {
                        resultIndex = i;
                        found = true;
                    }

                    i++;
                }
                else
                    break;
            }

            if (!found)
                return -1;

            return resultIndex;
        }

        public int BarrierSearch(T elementToSearch)
        {
            AddLast(elementToSearch);

            int i = 0;

            foreach (var el in this)
            {
                if (!el.Equals(elementToSearch))
                    i++;
                else
                    break;
            }

            if (i == Count-1)
                return -1;

            return i;
        }

        public int BinarySearch(T elementToSearch, out int operationsAmount)
        {
            int left = 0;
            int right = Count - 1;
            bool found = false;

            int m = Convert.ToInt32(right / 2);
            Item<T> current = Get(m);
            int currentM = m;

            operationsAmount = m + 1;

            while (left <= right && !found)
            {
                int element = (int) (object) current.Data;

                if (element.Equals((int)(object)elementToSearch))
                    found = true;
                else if (element < (int) (object) elementToSearch)
                {
                    left = m + 1;
                    m = Convert.ToInt32((left + right) / 2);

                    for (int i = 0; i < m - currentM; i++)
                    {
                        current = current.Next;
                        operationsAmount++;
                    }
                }
                else
                {
                    right = m - 1;
                    m = Convert.ToInt32((left + right) / 2);

                    current = Get(m);
                    operationsAmount += m + 1;
                }

                currentM = m;
                operationsAmount++;
            }

            if (!found)
                return -1;

            return m;
        }

        public int BinarySearchWithGoldenRatio(T elementToSearch, out int operationsAmount)
        {
            int left = 0;
            int right = Count - 1;
            bool found = false;

            int m = Convert.ToInt32(left * F);
            Item<T> current = Get(m);
            int currentM = m;

            operationsAmount = m + 1;

            while (left <= right && !found)
            {
                int element = (int) (object) current.Data;

                if (element.Equals((int)(object)elementToSearch))
                    found = true;
                else if (element < (int) (object) elementToSearch)
                {
                    left = m + 1;
                    m = Convert.ToInt32((left + right) / 2);

                    for (int i = 0; i < m - currentM; i++)
                    {
                        current = current.Next;
                        operationsAmount++;
                    }
                }
                else
                {
                    right = m - 1;
                    m = Convert.ToInt32((left + right) / 2);

                    current = Get(m);
                    operationsAmount += m + 1;
                }

                currentM = m;
                operationsAmount++;
            }

            if (!found)
                return -1;

            return m;
        }
    }
}