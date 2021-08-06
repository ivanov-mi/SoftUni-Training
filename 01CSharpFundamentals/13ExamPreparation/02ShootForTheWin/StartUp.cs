using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
       int[] targets = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int shotsOnTarget = 0;

        string inputLine = Console.ReadLine();

        while (inputLine?.ToLower() != "end")
        {
            int currentTargetIndex = int.Parse(inputLine);

            if (currentTargetIndex >= 0 && currentTargetIndex < targets.Length && targets[currentTargetIndex] != -1)
            {
                int currentTargetValue = targets[currentTargetIndex];
                targets[currentTargetIndex] = -1;
                shotsOnTarget++;

                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i] > currentTargetValue)
                    {
                        targets[i] -= currentTargetValue;
                    }
                    else if (targets[i] >= 0 && targets[i] <= currentTargetValue)
                    {
                        targets[i] += currentTargetValue;
                    }
                }                
            }

            inputLine = Console.ReadLine();
        }

        Console.WriteLine($"Shot targets: {shotsOnTarget} -> {string.Join(' ', targets)}");
    }
}