using System;
using System.Linq;

class CompareTwoArrays
{
    static void Main()
    {
        //02. Write a program that reads two arrays from the console and compares them element by element.

        int[] firstArray = Console.ReadLine()
                         .Split()
                         .Select(int.Parse)
                         .ToArray();
        int[] secondArray = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToArray();
        bool isEqual = true;

        if (firstArray.Length == secondArray.Length)
        {
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i]!=secondArray[i])
                {
                    Console.WriteLine("The arrays are not equal! Difference in the {0} element.", i);
                    isEqual = false;
                    break;
                }
            }
            if (isEqual)
            {
                Console.WriteLine("The arrays are qual!");
            }
        }
        else
        {
            Console.WriteLine("The arrays are not equal! The have different number of elements.");
           
        }
    }
}