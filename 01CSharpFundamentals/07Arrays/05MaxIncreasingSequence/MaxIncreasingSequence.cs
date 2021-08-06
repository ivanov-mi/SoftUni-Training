using System;
using System.Linq;

class MaxIncreasingSequence
{
    static void Main()
    {
        //05. Write a program that finds the maximal increasing sequence in an array.
        //    Example:  {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.

        int[] arr = Console.ReadLine()
                    .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
        int currentLength = 1;
        int maxLength = 1;
        int maxStartIndex = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i-1] < arr[i])
            {
                currentLength++;
            }
            else
            {
                currentLength = 1;
            }

            if (currentLength > maxLength)
            {
                maxLength = currentLength;
                maxStartIndex = i - maxLength + 1;
            }
        }

        for (int i = maxStartIndex; i < maxStartIndex + maxLength; i++)
        {
            Console.Write("{0} ", arr[i]);
        }
    }
}