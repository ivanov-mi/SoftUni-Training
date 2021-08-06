using System;

class PrintMatrices
{
    static void Main()
    {
        //01. Write a program that prints the following matrices with n rows and n columns for a given number n: 
        //    All examples are for n = 4.
        //          a)               b)              c)
        //    1  5  9  13      1  8  9  16      7  11 14 16
        //    2  6  10 14      2  7  10 15      4  8  12 15
        //    3  7  11 15      3  6  11 14      2  5  9  13
        //    4  8  12 16      4  5  12 13      1  3  6  10

        Console.Write("Input size of the matrix: ");

        int sizeOfMAtrix = int.Parse(Console.ReadLine());
        int[,] matrix = new int[sizeOfMAtrix, sizeOfMAtrix];

        int indexer = 0;

        for (int i = 0; i < sizeOfMAtrix; i++)
        {
            for (int j = 0; j < sizeOfMAtrix; j++)
            {
                indexer++;
                matrix[j, i] = indexer;
            }
        }

        PrintMatrix(matrix);

        indexer = 0;

        for (int i = 0; i < matrix.GetLength(1); i++)
        {        
            int currentColumn = indexer / sizeOfMAtrix;

            if (currentColumn % 2 == 0)
            {
                for (int j = 0; j < sizeOfMAtrix; j++)
                {
                    indexer++;
                    matrix[j, currentColumn] = indexer;
                }               
            }
            else if (currentColumn % 2 == 1)
            {
                for (int j = sizeOfMAtrix - 1; j >= 0 ; j--)
                {
                    indexer++;
                    matrix[j, currentColumn] = indexer;
                }
            }
        }

        PrintMatrix(matrix);

        indexer = 0;

        for (int i = sizeOfMAtrix -1; i >= 0; i--)
        {
            for (int j = 0; j < sizeOfMAtrix - i; j++)
            {
                indexer++;
                matrix[i + j, j] = indexer;
            }        
        }

        for (int i = 1 ; i < sizeOfMAtrix; i++)
        {
            for (int j = 0; j < sizeOfMAtrix - i; j++)
            {
                indexer++;
                matrix[j, j + i] = indexer;
            }
        }

        PrintMatrix(matrix);
    }

    private static void PrintMatrix(int[,] matrix)
    {
        Console.WriteLine(new string('-', 50));

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i,j], 4}");
            }

            Console.WriteLine();
        }
    }
}