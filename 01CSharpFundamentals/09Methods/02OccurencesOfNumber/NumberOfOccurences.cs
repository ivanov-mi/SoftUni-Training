using System;

class NumberOfOccurences
{
    static void Main()
    {
        // 02. Write a method that counts how many times given number appears in given array.
        //     Write a test probram to check if the method is working correctly.

        int givenNumber = 1;
        int[] array = { 3, -7, 0, 10, 5, 6, 3, 2, 1, 10, 0, 4, 3, 1, 2, 2, 5, 9, 1 };

        int numberOfOccurences = CountOccurences(array, givenNumber);

        Console.WriteLine($"The number {givenNumber} occurs {numberOfOccurences} times in the array.");
    }

    private static int CountOccurences(int[] array, int givenNumber)
    {
        int counter = 0;

        foreach (var number in array)
        { 
            if (number == givenNumber)
            {
                counter++;
            }
        }

        return counter;
    }
}