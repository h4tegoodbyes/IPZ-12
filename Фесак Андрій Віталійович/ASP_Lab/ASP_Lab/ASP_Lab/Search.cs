using System.Diagnostics;
using Lab_2;

namespace ASP_Lab;

public static class Search
{
    private static double F = 1.6180339887498948482;
       public static int Linear_Search(int[] arr, int search)
    {
        
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i]==search)
                return i;
        }
        return -1;
    }

    public static int Linear_Search(LinkedList<int> list, int search)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list.ElementAt(i)==search)
                return i;
        }
        return -1;
    }

    public static int Barrier_Search(int[] arr, int search)
    {
        int i = 0;
        while (arr[i] != search)
            i++;
        return i;
    }
    public static int Barrier_Search(LinkedList<int> list, int search)
    {
        int i = 0;
        while (list.ElementAt(i) != search)
            i++;
        return i;
    }

    public static int Binary_Search(int[] arr, int l, int r, int search)
    {

        if (r >= l) {
            int mid = l + (r - l) / 2;
            
            if (arr[mid] == search)
                return mid;

            if (arr[mid] > search)
                return Binary_Search(arr, l, mid - 1, search);

            return Binary_Search(arr, mid + 1, r, search);
        }

        return -1;
    }
    public static int Binary_Search(LinkedList<int> arr, int l, int r, int search)
    {

        if (r >= l) {
            int mid = l + (r - l) / 2;
            
            if (arr.ElementAt(mid) == search)
                return mid;

            if (arr.ElementAt(mid) > search)
                return Binary_Search(arr, l, mid - 1, search);

            return Binary_Search(arr, mid + 1, r, search);
        }

        return -1;
    }
    public static int Binary_Search_Modify(int[] arr, int l, int r, int search)
    {

        if (r >= l) {
            int mid = Convert.ToInt32(l* F) ;
            
            if (arr[mid] == search)
                return mid;

            if (arr[mid] > search)
                return Binary_Search(arr, l, mid - 1, search);

            return Binary_Search(arr, mid + 1, r, search);
        }

        return -1;
    }
    public static int Binary_Search_Modify(LinkedList<int> arr, int l, int r, int search)
    {

        if (r >= l)
        {
            int mid = Convert.ToInt32(l* F) ;
            
            if (arr.ElementAt(mid) == search)
                return mid;

            if (arr.ElementAt(mid) > search)
                return Binary_Search(arr, l, mid - 1, search);

            return Binary_Search(arr, mid + 1, r, search);
        }

        return -1;
    }
}