using System;
using System.Linq;

class Bombs
{
    static void Main()
    {
        int sizeOfMatrix = int.Parse(Console.ReadLine());
        int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];

        InputMatrix(sizeOfMatrix, matrix);

        string[] bombs = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < bombs.Length; i++)
        {
            int[] bombsCoordinates = bombs[i].Split(',')
                .Select(int.Parse)
                .ToArray();

            BombExplode(matrix, bombsCoordinates);
        }

        int aliceCells = matrix.Cast<int>().Count(x => x > 0);
        Console.WriteLine($"Alive cells: {aliceCells}");

        int sumOfAliveCells = matrix.Cast<int>().Where(x => x > 0).Sum();
        Console.WriteLine($"Sum: {sumOfAliveCells}");

        PrintMatrix(sizeOfMatrix, matrix);
    }

    private static void InputMatrix(int sizeOfMatrix, int[,] matrix)
    {
        for (int i = 0; i < sizeOfMatrix; i++)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int j = 0; j < sizeOfMatrix; j++)
            {
                matrix[i, j] = arr[j];
            }
        }
    }

    private static void PrintMatrix(int sizeOfMatrix, int[,] matrix)
    {
        for (int i = 0; i < sizeOfMatrix; i++)
        {
            for (int j = 0; j < sizeOfMatrix; j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    private static void BombExplode(int[,] matrix, int[] bombsCoordinates)
    {
        int bombRow = bombsCoordinates[0];
        int bombCol = bombsCoordinates[1];
        int bombPower = matrix[bombRow, bombCol];

        if (bombPower <= 0)
        {
            return;
        }

        int explodeUp = 1;
        int explodeDown = 1;
        int explodeLeft = 1;
        int explodeRight = 1;

        if (bombRow == 0)
        {
            explodeUp = 0;
        }
        else if (bombRow == matrix.GetLength(0) - 1)
        {
            explodeDown = 0;
        }

        if (bombCol == 0)
        {
            explodeLeft = 0;
        }
        else if (bombCol == matrix.GetLength(1) - 1)
        {

            explodeRight = 0;
        }

        for (int row = bombRow - explodeUp; row <= bombRow + explodeDown; row++)
        {
            for (int col = bombCol - explodeLeft; col <= bombCol + explodeRight; col++)
            {
                if (matrix[row, col] > 0)
                {
                    matrix[row, col] -= bombPower;
                }
            }
        }
    }
}

