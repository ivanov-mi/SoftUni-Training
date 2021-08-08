using System;

class Miner
{
    static void Main()
    {
        int sizeOfField = int.Parse(Console.ReadLine());
        char[,] field = new char[sizeOfField, sizeOfField];

        string[] commands = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int minerPositionRow = 0;
        int minerPositionCol = 0;
        int totalCoals = 0;

        for (int i = 0; i < sizeOfField; i++)
        {
            string[] lineOfField = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < sizeOfField; j++)
            {
                field[i, j] = lineOfField[j][0];

                if (field[i, j] == 's')
                {
                    minerPositionRow = i;
                    minerPositionCol = j;
                }
                else if (field[i, j] == 'c')
                {
                    totalCoals++;
                }
            }
        }

        int coalsCollected = 0;

        for (int i = 0; i < commands.Length; i++)
        {
            field[minerPositionRow, minerPositionCol] = '*';

            switch (commands[i]?.ToLower())
            {
                case "up":
                    if (minerPositionRow - 1 >= 0)
                    {
                        minerPositionRow--;
                    }
                    break;
                case "down":
                    if (minerPositionRow + 1 < sizeOfField)
                    {
                        minerPositionRow++;
                    }
                    break;
                case "left":
                    if (minerPositionCol - 1 >= 0)
                    {
                        minerPositionCol--;
                    }
                    break;
                case "right":
                    if (minerPositionCol + 1 < sizeOfField)
                    {
                        minerPositionCol++;
                    }
                    break;
            }

            if (field[minerPositionRow, minerPositionCol] == 'c')
            {
                coalsCollected++;
                if (coalsCollected == totalCoals)
                {
                    Console.WriteLine($"You collected all coals! ({minerPositionRow}, {minerPositionCol})");
                    return;
                }
            }
            else if (field[minerPositionRow, minerPositionCol] == 'e')
            {
                Console.WriteLine($"Game over! ({minerPositionRow}, {minerPositionCol})");
                return;
            }

            field[minerPositionRow, minerPositionCol] = 's';
        }

        Console.WriteLine($"{totalCoals - coalsCollected} coals left. ({minerPositionRow}, {minerPositionCol})");
    }
}
