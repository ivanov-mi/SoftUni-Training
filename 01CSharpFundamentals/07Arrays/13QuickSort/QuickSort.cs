using System;

class QuickSort
{
    static void Main()
    {
        //13. Write a program that sorts an array of strings using the quick sort algorithm. Search on Google.

        int[] arr = { 51, 95, 66, 72, 42, 38, 39, 41, 15};

        Console.WriteLine("Unsorted array:");
        Console.WriteLine(string.Join(" ", arr));

        Sort(arr, 0, arr.Length - 1);

        Console.WriteLine("Sorted array:");
        Console.WriteLine(string.Join(" ", arr));
    }

    public static void Sort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int j = Partition(arr, low, high);
            Sort(arr, low, j - 1);
            Sort(arr, j + 1, high);
        }
    }

    public static int Partition(int[] arr, int low, int high)
    {
        int i = low - 1;
        int pivot = arr[high];

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, high, i + 1);
        return i + 1;
    }

    public static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp; 
    }
}