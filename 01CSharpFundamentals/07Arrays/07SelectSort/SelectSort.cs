using System;
using System.Linq;

class SelectSort
{
    static void Main()
    {
        //07. Sorting an array means to arrange its elements in increasing order. Write a program to
        //    sort an array. Use the "selection sort" algorithm. Hint: Search on Google.

        int[] arr = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

        for (int i = 0; i < arr.Length-1; i++)
        {
            int indexMin = i;

            for (int j = i; j < arr.Length; j++)
            {
                if (arr[indexMin] < arr[j])
                {
                    indexMin = j;
                }
            }

            int temp = arr[i];
            arr[i] = arr[indexMin];
            arr[indexMin] = temp;
        }

        Console.WriteLine(string.Join(" ", arr));
    }
}