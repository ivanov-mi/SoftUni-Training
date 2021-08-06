using System;

    class MostFrequentNumber
    {
        static void Main()
        {
        //09. Write a program that finds the most frequent number in an array. Example:
        //    { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4(5 times)

        int[] arr = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
        int mostFrequent = int.MaxValue;
        int countMostFrequent = 0;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            int j = i + 1;
            int insertValue = arr[j];

            while (j > 0 && insertValue < arr[j - 1])
            {
                arr[j] = arr[j - 1];
                j--;
            }

            arr[j] = insertValue;
        }

        for (int i = 0; i < arr.Length-1; i++)
        {
            int currentNumber = arr[i];
            int counter = 1;

            while (currentNumber == arr[i + 1])
            {
                counter++;
                i++;
            }

            if (counter > countMostFrequent)
            {
                countMostFrequent = counter;
                mostFrequent = currentNumber;
            }
        }

        Console.WriteLine("{0}({1} times)", mostFrequent, countMostFrequent);
        }
}