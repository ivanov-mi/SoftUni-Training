using System;
using System.Text;

namespace Re_Volt
{
    class Program
    {
        static void Main()
        {
            var sizeOfField = int.Parse(Console.ReadLine());
            var commandsCount = int.Parse(Console.ReadLine());
            var field = new char[sizeOfField, sizeOfField];
            var player = new PlayerPosition();

            DrawField(player, field);

            var isGameOver = false;
            var gameWin = false;

            while (isGameOver == false)
            {
                var currentMove = Console.ReadLine().ToLower();
                var playerOldPosition = new PlayerPosition(player.Row, player.Col);
                field[playerOldPosition.Row, playerOldPosition.Col] = '-';

                do
                {
                    PlayerMove(player, sizeOfField, currentMove);
                }while (field[player.Row, player.Col] == 'B');

                if (field[player.Row, player.Col] == 'T')
                {
                    player = playerOldPosition;
                }
                else if (field[player.Row, player.Col] == 'F')
                {
                    gameWin = true;
                }

                commandsCount--;
                isGameOver = commandsCount == 0 || gameWin == true;
            }

            GameOverOutput(player, gameWin, field);
        }

        private static void DrawField(PlayerPosition player, char[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                var fieldRow = Console.ReadLine().ToCharArray();

                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = fieldRow[j];
                    if (fieldRow[j] == 'f')
                    {
                        player.Row = i;
                        player.Col = j;
                    }
                }
            }
        }

        private static void PlayerMove(PlayerPosition player, int sizeOfField, string command)
        {
            switch (command)
            {
                case "up":
                    if (player.Row == 0)
                    {
                        player.Row = sizeOfField - 1;
                    }
                    else
                    {
                        player.Row--;
                    }
                    break;
                case "down":
                    if (player.Row == sizeOfField - 1)
                    {
                        player.Row = 0;
                    }
                    else
                    {
                        player.Row++;
                    }
                    break;
                case "left":
                    if (player.Col == 0)
                    {
                        player.Col = sizeOfField - 1;
                    }
                    else
                    {
                        player.Col--;
                    }
                    break;
                case "right":
                    if (player.Col == sizeOfField - 1)
                    {
                        player.Col = 0;
                    }
                    else
                    {
                        player.Col++;
                    }
                    break;
            }
        }

        private static void GameOverOutput(PlayerPosition playerLastPosition, bool gameWin, char[,] field)
        {
            field[playerLastPosition.Row, playerLastPosition.Col] = 'f';

            var sb = new StringBuilder();

            if (gameWin)
            {
                sb.AppendLine("Player won!");
            }
            else
            {
                sb.AppendLine("Player lost!");
            }

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    sb.Append(field[i, j]);
                }
                sb.AppendLine();
            }

            var endField = sb.ToString().TrimEnd();
            Console.WriteLine(endField);
        }
    }
}