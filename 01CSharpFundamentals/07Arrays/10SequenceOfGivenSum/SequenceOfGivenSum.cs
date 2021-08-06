using System;

class SequenceOfGivenSum
{
    static void Main()
    {
        //10. Write a program that finds in given array of integers a sequence of given sum S (if present).
        //    Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}

        int[] arr = { 4, 3, 1, 4, 2, 5, 8 };
        int givenSumS = 11;
        int startIndexS = 0;
        int sequenceLength = 0;
        bool isSequence = false;

        for (int i = 0; i < arr.Length-1; i++)
        {
            int currentSum = arr[i];

            for (int j = i + 1; j < arr.Length; j++)
            {
                currentSum += arr[j];
                if (currentSum == givenSumS)
                {
                    startIndexS = i;
                    sequenceLength = j - i + 1;
                    break;
                }
            }

            if (isSequence)
            {
                break;
            }
        }

        Console.WriteLine("S={0} ", givenSumS);

        for (int i = startIndexS; i < startIndexS + sequenceLength ; i++)
        {
            Console.Write("{0} ", arr[i]);
        }
    }
}

