using System;
using System.Linq;

class SquaresInMatrix
{
    static void Main()
    {
        int[] sizeOfMatrix = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int rows = sizeOfMatrix[0];
        int cols = sizeOfMatrix[1];
        char[,] matrixOfChars = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            var arrayOfChars = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < cols; j++)
            {
                matrixOfChars[i, j] = arrayOfChars[j][0];
            }
        }

        int counter = 0;

        for (int i = 0; i < rows - 1; i++)
        {
            for (int j = 0; j < cols - 1; j++)
            {
                if (matrixOfChars[i, j] == matrixOfChars[i+1, j] 
                    && matrixOfChars[i, j] == matrixOfChars[i, j+1] 
                    && matrixOfChars[i, j] == matrixOfChars[i+1, j+1])
                {
                    counter++;
                }
            }
        }

        Console.WriteLine(counter);
    }
}

