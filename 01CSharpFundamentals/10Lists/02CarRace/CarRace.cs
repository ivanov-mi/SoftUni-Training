using System;
using System.Collections.Generic;
using System.Linq;

class CarRace
{
    static void Main()
    {
        List<int> timesToPass = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        double timeOfLeft = 0;
        double timeOfRight = 0;

        for (int i = 0; i < timesToPass.Count / 2; i++)
        {
            if (timesToPass[i] == 0)
            {
                timeOfLeft *= 0.8;
            }
            else
            {
                timeOfLeft += timesToPass[i];
            }

            if (timesToPass[timesToPass.Count - i - 1] == 0)
            {
                timeOfRight *= 0.8;
            }
            else
            {
                timeOfRight += timesToPass[timesToPass.Count - i - 1];
            }
        }

        if (timeOfLeft < timeOfRight)
        {
            Console.WriteLine($"The winner is left with total time: {timeOfLeft}");
        }
        else if (timeOfLeft > timeOfRight)
        {
            Console.WriteLine($"The winner is right with total time: {timeOfRight}");
        }
        else
        {
            Console.WriteLine($"The two cars finish equal!");
        }
    }
}