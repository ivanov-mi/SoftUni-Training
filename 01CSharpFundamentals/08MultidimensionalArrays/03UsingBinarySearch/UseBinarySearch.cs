using System;

class UseBinarySearch
{
    static void Main()
    {
        //03. Write a program, that reads from the console an array of N integers and an integer K, 
        //    sorts the array and using the method Array.BinSearch() finds the largest number in the array which is <= K.

        Console.Write("Input number of elements (N): ");
        int numberOfElements = int.Parse(Console.ReadLine());

        Console.Write("Input integer K: ");
        int searchedValue = int.Parse(Console.ReadLine());

        int[] array = new int[numberOfElements];

        for (int i = 0; i < numberOfElements; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(array);

        int indexOfK = Array.BinarySearch(array, searchedValue);

        if (indexOfK == -1)
        {
            Console.WriteLine("There are no less or equal values.");
        }
        else
        {
            Console.Write($"The nearest value less or equal to {searchedValue} is: ");

            if (indexOfK == -(array.Length + 1))
            {
                Console.WriteLine(array[array.Length - 1]);
            }
            else if (indexOfK > -(array.Length + 1) && indexOfK <= -2)
            {
                Console.WriteLine(array[ -indexOfK -2]);
            }
            else if (indexOfK == 0)
            {
                Console.WriteLine(array[indexOfK]);
            }
            else if (indexOfK > 0)
            {
                Console.WriteLine(array[indexOfK - 1]);
            }
        }
    }
}