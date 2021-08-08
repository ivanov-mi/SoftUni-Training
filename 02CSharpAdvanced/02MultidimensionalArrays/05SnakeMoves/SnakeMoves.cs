using System;
using System.Linq;

class SnakeMoves
{
    static void Main()
    {
        int[] sizeOfMatrix = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int rows = sizeOfMatrix[0];
        int cols = sizeOfMatrix[1];
        char[,] matrix = new char[rows, cols];
        string snake = Console.ReadLine();

        int counter = 0;

        for (int i = 0; i < rows; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = snake[counter % snake.Length];
                    counter++;
                }
            }
            else
            {
                for (int j = cols - 1; j >= 0; j--)
                {
                    matrix[i, j] = snake[counter % snake.Length];
                    counter++;
                }
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i,j]);
            }
            Console.WriteLine();
        }
    }
}

