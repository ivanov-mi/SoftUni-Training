using System;
using System.Linq;

class MutantBunnies
{
    static void Main()
    {
        int[] sizeOfField = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        char[,] field = new char[sizeOfField[0], sizeOfField[1]];
        Position playerPosition = new Position(0, 0);

        InputField(field, playerPosition);

        string directionsInput = Console.ReadLine();

        bool isWon = false;
        bool isDead = false;

        foreach (var direction in directionsInput)
        {
            //Move player
            field[playerPosition.Row, playerPosition.Col] = '.';
            Position playerNewPosition = MoveSingleDirection(field, playerPosition, direction);

            //Win conditions
            if (playerNewPosition == playerPosition)
            {
                isWon = true;
            }
            else
            {
                playerPosition = playerNewPosition;
            }

            //Game over conditions
            if (field[playerPosition.Row, playerPosition.Col] == 'B')
            {
                isDead = true;
            }
            else
            {
                isDead = CheckForAdjecentBunnie(field, playerPosition);
            }

            //Draw player new position
            if (isWon == false && isDead == false)
            {
                field[playerPosition.Row, playerPosition.Col] = 'P';
            }

            //Spread Bunnies
            BunniesSpread(field);

            //Result output
            if (isWon || isDead)
            {
                PrintField(field);

                if (isWon)
                {
                    Console.WriteLine($"won: {playerPosition.Row} {playerPosition.Col}");
                }
                else
                {
                    Console.WriteLine($"dead: {playerPosition.Row} {playerPosition.Col}");
                }
                break;
            }
        }
    }

    private static void InputField(char[,] field, Position playerPosition)
    {
        for (int i = 0; i < field.GetLength(0); i++)
        {
            string lineOfLair = Console.ReadLine();

            for (int j = 0; j < field.GetLength(1); j++)
            {
                field[i, j] = lineOfLair[j];
                if (field[i, j] == 'P')
                {
                    playerPosition.Row = i;
                    playerPosition.Col = j;
                }
            }
        }
    }

    private static Position MoveSingleDirection(char[,] field, Position playerCurrentPosition, char direction)
    {
        Position playerNewPosition = new Position(playerCurrentPosition.Row, playerCurrentPosition.Col);

        switch (direction)
        {
            case 'U':
                playerNewPosition.Row--;
                break;
            case 'D':
                playerNewPosition.Row++;
                break;
            case 'L':
                playerNewPosition.Col--;
                break;
            case 'R':
                playerNewPosition.Col++;
                break;
        }

        if (playerNewPosition.Row >= 0 && playerNewPosition.Row < field.GetLength(0) && 
            playerNewPosition.Col >= 0 && playerNewPosition.Col < field.GetLength(1))
        {
            return playerNewPosition;
        }

        return playerCurrentPosition;
    }
    private static bool CheckForAdjecentBunnie(char[,] field, Position playerCurrentPosition)
    {
        string directionsToSpread = "RLUD";

        foreach (var direction in directionsToSpread)
        {
            Position adjecentBunnie = MoveSingleDirection(field, playerCurrentPosition, direction);

            if (field[adjecentBunnie.Row, adjecentBunnie.Col] == 'B')
            {
                return true;
            }
        }

        return false;
    }

    private static void BunniesSpread(char[,] field)
    {
        string directionsToSpread = "RLUD";

        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (field[i, j] == 'B')
                {
                    Position currentBunnie = new Position(i, j);

                    foreach (var direction in directionsToSpread)
                    {
                        Position spreadingBunnie = MoveSingleDirection(field, currentBunnie, direction);

                        if (field[spreadingBunnie.Row, spreadingBunnie.Col] != 'B')
                        {
                            field[spreadingBunnie.Row, spreadingBunnie.Col] = 'b';
                        }
                    }                  
                }
            }
        }

        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (field[i, j] == 'b')
                {
                    field[i, j] = 'B';
                }
            }
        }
    }
    private static void PrintField(char[,] field)
    {
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                Console.Write($"{field[i, j]}");
            }
            Console.WriteLine();
        }
    }
}