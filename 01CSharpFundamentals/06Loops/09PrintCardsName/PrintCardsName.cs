using System;

class PrintCardsName
{
    static void Main()
    {
        // 9. Write a program that prints all possible card from a standart deck of 52 cards (withoout jokers).
        //    The cards should be printed with their English names. Use nested for loops and switch-case.  

        string rank = "";

        for (int i = 0; i < 13; i++)
        {
            switch (i)
            {
                case 0: rank = "Two"; break;
                case 1: rank = "Three"; break;
                case 2: rank = "Four"; break;
                case 3: rank = "Five"; break;
                case 4: rank = "Six"; break;
                case 5: rank = "Seven"; break;
                case 6: rank = "Eight"; break;
                case 7: rank = "Nine"; break;
                case 8: rank = "Ten"; break;
                case 9: rank = "Jack"; break;
                case 10: rank = "Queen"; break;
                case 11: rank = "King"; break;
                case 12: rank = "Ace"; break;
                default:
                    Console.WriteLine("Wrong rank of card!");
                    break;
            }

            for (int j = 0; j < 4; j++)
            {
                switch (j)
                {
                    case 0: Console.WriteLine(rank + " of Clubs"); break;
                    case 1: Console.WriteLine(rank + " of Diamonds"); break;
                    case 2: Console.WriteLine(rank + " of Hearts"); break;
                    case 3: Console.WriteLine(rank + " of Spades"); break;
                    default:
                        Console.WriteLine("Wrong  suit of card!");
                        break;
                }

            }
        }
    }
}