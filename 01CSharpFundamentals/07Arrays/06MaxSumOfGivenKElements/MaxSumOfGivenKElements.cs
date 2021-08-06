using System;

class MaxSumOfGivenKElements
{
    static void Main()
    {
        //06. Write a program that reads two integer numbers N and K and an array of N elements
        //    from the console. Find in the array those K elements that have maximal sum.

        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int[] nArray = new int[n];

        for (int i = 0; i < n; i++)
        {
            nArray[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < k; i++)
        {
            int maxIndex = i;

            for (int j = i+1; j < n; j++)
            {
                if (nArray[maxIndex] < nArray[j])
                {
                    maxIndex = j;
                }
            }

            int temp = nArray[i];
            nArray[i] = nArray[maxIndex];
            nArray[maxIndex] = temp;
        }

        for (int i = 0; i < k; i++)
        {
            Console.Write("{0} ", nArray[i]);
        }
    }
}