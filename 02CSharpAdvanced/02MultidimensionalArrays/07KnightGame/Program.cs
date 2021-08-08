using System;

class Program
{
    static void Main()
    {
        int sizeOfBoard = int.Parse(Console.ReadLine());
        char[,] board = new char[sizeOfBoard, sizeOfBoard];

        for (int i = 0; i < sizeOfBoard; i++)
        {
            string bordArr = Console.ReadLine();

            for (int j = 0; j < sizeOfBoard; j++)
            {
                board[i, j] = bordArr[j];
            }
        }

        int minKnightToRemove = 0;

        while (true)
        {
            int maxCanAttack = 0;
            int rowMaxCanAttack = 0;
            int colMaxCanAttack = 0;

            for (int i = 0; i < sizeOfBoard; i++)
            {
                for (int j = 0; j < sizeOfBoard; j++)
                {
                    int currentCanAttack = 0;

                    if (board[i,j] == 'K')
                    {
                        if (IsInTheBoard(sizeOfBoard, i + 2, j - 1) && board[i + 2, j - 1] == 'K')
                        {
                            currentCanAttack++;
                        }
                        if (IsInTheBoard(sizeOfBoard, i + 2, j + 1) && board[i + 2, j + 1] == 'K')
                        {
                            currentCanAttack++;
                        }
                        if (IsInTheBoard(sizeOfBoard, i + 1, j - 2) && board[i + 1, j - 2] == 'K')
                        {
                            currentCanAttack++;
                        }
                        if (IsInTheBoard(sizeOfBoard, i + 1, j + 2) && board[i + 1, j + 2] == 'K')
                        {
                            currentCanAttack++;
                        }
                        if (IsInTheBoard(sizeOfBoard, i - 1, j - 2) && board[i - 1, j - 2] == 'K')
                        {
                            currentCanAttack++;
                        }
                        if (IsInTheBoard(sizeOfBoard, i - 1, j + 2) && board[i - 1, j + 2] == 'K')
                        {
                            currentCanAttack++;
                        }
                        if (IsInTheBoard(sizeOfBoard, i - 2, j - 1) && board[i - 2, j - 1] == 'K')
                        {
                            currentCanAttack++;
                        }
                        if (IsInTheBoard(sizeOfBoard, i - 2, j + 1) && board[i - 2, j + 1] == 'K')
                        {
                            currentCanAttack++;
                        }

                        if (currentCanAttack > maxCanAttack)
                        {
                            maxCanAttack = currentCanAttack;
                            rowMaxCanAttack = i;
                            colMaxCanAttack = j;
                        }
                    }
                }
            }

            if (maxCanAttack > 0)
            {
                board[rowMaxCanAttack, colMaxCanAttack] = '0';
                minKnightToRemove++;
            }
            else
            {
                break;
            }
        }

        Console.WriteLine(minKnightToRemove); 
    }

    private static bool IsInTheBoard(int sizeOfBoard, int i, int j)
    {
        return i < sizeOfBoard  && i >= 0 && j < sizeOfBoard && j >= 0;
    }
}

