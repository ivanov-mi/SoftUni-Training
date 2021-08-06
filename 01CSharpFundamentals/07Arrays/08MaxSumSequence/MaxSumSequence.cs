using System;

class MaxSumSequence
{
    static void Main()
    {
        //08. Write a program that finds the sequence of maximal sum in given array.
        //    Example:  {2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
        //    Can you do it with only one loop(with single scan through the elements of the array)?

        int[] arr = { -8, -2, 2, -1, 2, -2, -6, -4, -8, -8 };
        int maxLength = 0;
        int currentLength = 0;
        int currentSum = 0;
        int maxSum = Int32.MinValue;
        int endOfMaxSum = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            currentSum += arr[i];
            currentLength++;

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                endOfMaxSum = i;
                maxLength = currentLength;
            }

            if (currentSum < 0)
            {
                currentSum = 0;
                currentLength = 0;
            }
        }

        for (int i = endOfMaxSum - maxLength + 1; i <= endOfMaxSum; i++)
        {
            Console.Write("{0} ", arr[i]);
        }
    }
}