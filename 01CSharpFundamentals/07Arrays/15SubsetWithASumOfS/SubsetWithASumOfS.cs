using System;

class SubsetWithASumOfS
{
    static void Main()
    {
        //15. * We are given an array of integers and a number S. Write a program to find
        //    if there exists a subset of the elements of the array that has a sum S. 
        //    Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)

        int[] arr = new int[] { 1, 3, 3, 3, 15, 7, 65, 6, 9 };
        int sumS = 14;
        bool[] boolArray = new bool[arr.Length];

        for (int i = 0; i < boolArray.Length; i++)
        {
            boolArray[i] = false;
        }

        Array.Sort(arr);

        int currentSum = 0;
        bool isSum = false;

        for (int i = 0; i < boolArray.Length; i++)
        {
            if (boolArray[i] == true)
            {
                Console.Write("{0} ",  arr[i]);
            }
        }

        Console.WriteLine("\nisSum = {0}", isSum);
        Console.WriteLine();
        Console.Write(string.Join(" ", arr));
        Console.WriteLine();
        Console.Write(string.Join(" ", boolArray));
    }
}