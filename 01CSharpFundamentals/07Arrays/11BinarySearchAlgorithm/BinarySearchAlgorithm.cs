using System;

class BinarySearchAlgorithm
{
    static void Main()
    {
        //11. Write a program that finds the index of given element in a sorted array
        //    of integers by using the binary search algorithm (find it in Wikipedia).

        int[] arr = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91};
        int searchValue = 23;
        int rigthBound = arr.Length - 1;
        int leftBound = 0;
        int mid = 0;
        bool isFound = false;

        while (leftBound <= rigthBound)
        {    
            mid = (leftBound + rigthBound) / 2;

            if (searchValue == arr[mid])
            {
                isFound = true;
                break;
            }
            else if (searchValue > arr[mid])
            {
                leftBound = mid + 1;
            }
            else
            {
                rigthBound = mid - 1 ;
            }
        }

        if (isFound)
        {
            Console.WriteLine("The index of the seached value is: {0}", mid);
        }
        else
        {
            Console.WriteLine("The array does not include the searched value!");
        }
    }
}