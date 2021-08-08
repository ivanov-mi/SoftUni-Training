using System;
using System.Linq;

class MaxSum
{
    static void Main()
    {
        int[] sizeOfMatrix = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int rows = sizeOfMatrix[0];
        int cols = sizeOfMatrix[1];
        int[,] matrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = arr[j];
            }
        }

        int maxSum = int.MinValue;
        int rowMaxSum = 0;
        int colMaxSum = 0;

        for (int i = 0; i < rows - 2; i++)
        {
            for (int j = 0; j < cols - 2; j++)
            {                
                int currentSum = matrix[i,j] + matrix[i, j+1] + matrix[i, j+2]
                    + matrix[i+1, j] + matrix[i+1, j+1] + matrix[i+1, j+2]
                    + matrix[i+2, j] + matrix[i+2, j+1] + matrix[i+2, j+2];

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    rowMaxSum = i;
                    colMaxSum = j;
                }
            }
        }

        Console.WriteLine($"Sum = {maxSum}");

        for (int i = rowMaxSum; i < rowMaxSum + 3; i++)
        {
            for (int j = colMaxSum; j < colMaxSum + 3; j++)
            {
                Console.Write($"{matrix[i,j]} ");
            }
            Console.WriteLine();
        }
    }
}

