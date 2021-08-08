using System;
using System.Linq;

class DiagonalDifference
{
    static void Main()
    {
        int sizeOfMatrix = int.Parse(Console.ReadLine());
        int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];

        for (int i = 0; i < sizeOfMatrix; i++)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int j = 0; j < sizeOfMatrix; j++)
            {
                matrix[i,j] = arr[j];
            }
        }

        int mainDiagonalSum = 0;
        int secondaryDiagonalSum = 0;

        for (int i = 0; i < sizeOfMatrix; i++)
        {
            mainDiagonalSum += matrix[i, i];
            secondaryDiagonalSum += matrix[i, sizeOfMatrix - 1 - i];
        }

        Console.WriteLine(Math.Abs(mainDiagonalSum - secondaryDiagonalSum));
    }
}

