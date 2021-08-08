using System;
using System.Linq;

class MatrixShuffling
{
    static void Main()
    {
        int[] matrixSize = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        string[,] matrix = new string[matrixSize[0], matrixSize[1]];

        InputMatrix(matrix);

        string input = string.Empty;

        while ((input = Console.ReadLine())?.ToLower() != "end")
        {
            string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string keyword = command[0];

            if (command.Length == 5 && keyword == "swap")
            {
                int row1 = int.Parse(command[1]);
                int col1 = int.Parse(command[2]);
                bool firstElementCoordinates = CheckCoordinates(matrix, row1, col1);

                int row2 = int.Parse(command[3]);
                int col2 = int.Parse(command[4]);
                bool secondElementCoordinates = CheckCoordinates(matrix, row2, col2);

                if (firstElementCoordinates && secondElementCoordinates)
                {
                    string tmp = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = tmp;
                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }

    private static void InputMatrix(string[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            string[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = arr[j];
            }
        }
    }

    private static bool CheckCoordinates(string[,] matrix, int row1, int col1)
    {
        return (row1 >= 0 && row1 < matrix.GetLength(0) && col1 >= 0 && col1 < matrix.GetLength(1));
    }

    private static void PrintMatrix(string[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}

