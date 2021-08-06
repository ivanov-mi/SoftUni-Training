using System;

public class StartUp
{
    static void Main()
    {
        int energy = int.Parse(Console.ReadLine());
        int totalWins = 0;
        bool isWinner = true;

        string inputLine = Console.ReadLine();

        while (inputLine.ToUpper() != "END OF BATTLE")
        {
            int distance = int.Parse(inputLine);

            if (energy >= distance)
            {
                energy -= distance;
                totalWins++;

                if (totalWins % 3 == 0)
                {
                    energy += totalWins;
                }
            }
            else
            {
                Console.WriteLine($"Not enough energy! Game " +
                    $"ends with {totalWins} won battles and {energy} energy");
                isWinner = false;
                break;
            }

            inputLine = Console.ReadLine();
        }

        if (isWinner)
        {
            Console.WriteLine($"Won battles: {totalWins}. Energy left: {energy}");
        }
    }
}