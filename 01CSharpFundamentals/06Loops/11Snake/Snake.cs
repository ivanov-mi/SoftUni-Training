using System;

class Snake
{
    static void Main()
    {
        // 11. *Write a program that reads a positive integer number N (N<20) from console
        //     and outputs in the console numbers 1.....N numbers arranged as a spiral
        //      Example for N=4
        //          1  2  3  4 
        //          12 13 14 5
        //          11 16 15 6
        //          10 9  8  7

        Console.Write("Input size of the matrix (N<20): ");
        int sideOfMatrix = int.Parse(Console.ReadLine());

        int[,] spiral = new int[sideOfMatrix, sideOfMatrix];

        int arrayRows = spiral.GetLength(0);
        int arrayCols = spiral.GetLength(1);
        int maxLevel = (int)Math.Min(arrayCols, arrayRows);

        int printIndex = 1;
        int maxValue = arrayCols * arrayRows;

        for (int subMatrix = 0; subMatrix < maxLevel; subMatrix++)
        {
            for (int j = subMatrix; j <= (arrayCols - subMatrix - 1) && maxValue >= printIndex; j++)       // Filling top vector
            {
                spiral[subMatrix, j] = printIndex++;
            }

            for (int i = subMatrix + 1; i <= (arrayRows - subMatrix - 1) && maxValue >= printIndex; i++)   // Filling right vector 
            {
                spiral[i, arrayCols - subMatrix - 1] = printIndex++;
            }

            for (int i = (arrayCols - subMatrix - 2); i >= subMatrix && maxValue >= printIndex; i--)       // Filling bottom vector
            {
                spiral[arrayRows - subMatrix - 1, i] = printIndex++;
            }

            for (int i = arrayRows - subMatrix - 2; i >= subMatrix + 1 && maxValue >= printIndex; i--)      // Filling left vector
            {
                spiral[i, subMatrix] = printIndex++;
            }
        }

        for (int i = 0; i < spiral.GetLength(0); i++)
        {
            for (int j = 0; j < spiral.GetLength(1); j++)
            {
                Console.Write("{0,4}", spiral[i, j]);
            }

            Console.WriteLine();
        }
    }
}