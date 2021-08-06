using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        int[] neighborhood = Console.ReadLine()
            .Split(new string[] {"@", " "} , StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int lastPosition = 0;

        string inputLine = string.Empty;

        while ((inputLine = Console.ReadLine()?.ToLower()) != "love!")
        {
            string[] tokens = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int jumpLength = int.Parse(tokens[1]);

            lastPosition += jumpLength;

            if (lastPosition >= neighborhood.Length)
            {
                lastPosition = 0;
                neighborhood[lastPosition] -= 2;
            }
            else
            {
                neighborhood[lastPosition] -= 2;
            }

            if (neighborhood[lastPosition] == 0)
            {
                Console.WriteLine($"Place {lastPosition} has Valentine's day.");
            }
            else if (neighborhood[lastPosition] < 0)
            {
                Console.WriteLine($"Place {lastPosition} already had Valentine's day.");
            }
        }

        Console.WriteLine($"Cupid's last position was {lastPosition}.");
        
        int houseFailed = neighborhood.Where(x => x > 0).Count();

        if (houseFailed == 0)
        {
            Console.WriteLine("Mission was successful.");
        }
        else
        {
            Console.WriteLine($"Cupid has failed {houseFailed} places.");
        }
    }
}