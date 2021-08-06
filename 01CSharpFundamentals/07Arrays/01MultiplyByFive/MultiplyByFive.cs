using System;

class MultiplyByFive
{
    static void Main()
    {
        //01. Write a program that allocates array of 20 integers and initializes each element
        //    by its index multiplied by 5.Print the obtained array on the console.

        int[] indexesArray = new int[20];

        for (int i = 0; i < indexesArray.Length; i++)
        {
            indexesArray[i] = i * 5;
        }

        Console.WriteLine(string.Join(", ", indexesArray));
    }
}