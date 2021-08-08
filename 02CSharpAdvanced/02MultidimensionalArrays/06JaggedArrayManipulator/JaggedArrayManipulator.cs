using System;
using System.Linq;

class JaggedArrayManipulator
{
    static void Main()
    {
        int numberOfRows = int.Parse(Console.ReadLine());
        double[][] jaggedArray = new double[numberOfRows][];

        for (int i = 0; i < numberOfRows; i++)
        {
            jaggedArray[i] = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
        }

        for (int i = 1; i < numberOfRows; i++)
        {
            if (jaggedArray[i - 1].Length == jaggedArray[i].Length)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    jaggedArray[i][j] *= 2;
                    jaggedArray[i - 1][j] *= 2;
                }
            }
            else
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    jaggedArray[i][j] /= 2;
                }

                for (int j = 0; j < jaggedArray[i - 1].Length; j++)
                {
                    jaggedArray[i - 1][j] /= 2;
                }
            }
        }

        while (true)
        {
            string[] inputLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = inputLine[0];

            if (command.ToLower() == "end")
            {
                break;
            }

            int row = int.Parse(inputLine[1]);
            int col = int.Parse(inputLine[2]);

            if (row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length)
            {
                int value = int.Parse(inputLine[3]);

                if (command.ToLower() == "add")
                {
                    jaggedArray[row][col] += value;
                }
                else if (command.ToLower() == "subtract")
                {
                    jaggedArray[row][col] -= value;
                }
            }
        }

        foreach (var arr in jaggedArray)
        {
            Console.WriteLine(string.Join(' ', arr));
        }
    }
}

