using System;

class MaxSquare3x3
{
    static void Main()
    {
        //02. Write a program that reads a rectangular matrix of size N x M and finds in it the square
        //    3 x 3 that has maximal sum of its elements.

        bool correctInput = false;
        int rows = 0;
        int cols = 0;

        while (!correctInput)
        {
            Console.Write("Input number of rows (N>2): ");
            rows = int.Parse(Console.ReadLine());

            Console.Write("Input number of columns(M>2): ");
            cols = int.Parse(Console.ReadLine());

            if (rows > 2 && cols > 2)
            {
                correctInput = true;
            }
            else
            {
                Console.WriteLine("\nWrong input! Try again.\n");
            }
        }

        int[,] inputArray = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            string currentRow = Console.ReadLine();
            string[] stringArrayElements = currentRow.Split(' ');
            for (int j = 0; j < cols; j++)
            {
                inputArray[i, j] = int.Parse(stringArrayElements[j]);
            }
        }

        long maxSum = Int64.MinValue;

        for (int i = 0; i < rows - 2; i++)
        {
            for (int j = 0; j < cols - 2; j++)
            { int currentSum = inputArray[i,j] + inputArray[i, j+1] + inputArray[i,j+2] 
                    + inputArray[i+1, j] + inputArray[i+1, j+1] + inputArray[i+1, j+2]
                    + inputArray[i+2, j] + inputArray[i+2, j+1] + inputArray[i+2,j+2];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }
        }

        Console.WriteLine($"The maximum sum of square 3x3 of the inputed array is: {maxSum}");
    }
}