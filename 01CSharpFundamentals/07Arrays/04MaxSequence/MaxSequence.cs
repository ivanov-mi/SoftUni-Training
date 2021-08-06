using System;
using System.Linq;

class MaxSequence
{
    static void Main()
    {
        //04. Write a program that finds the maximal sequence of equal elements in an array.
        //    Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.

        int[] arr = Console.ReadLine()
                        .Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
        int length = 1;
        int maxStartIndex = 0;
        int maxLength = 1;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i-1]==arr[i])
            {
                length++;
            }
            else
            {
                length = 1;
            }

            if (maxLength < length)
            {
                maxLength = length;
                maxStartIndex = i - length + 1;
            }
        }

        for (int i = maxStartIndex; i < maxStartIndex + maxLength; i++)
        {
            Console.Write("{0} ", arr[i]);
        }
    }
}