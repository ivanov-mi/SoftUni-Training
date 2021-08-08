using System;
using System.Collections.Generic;
using System.Linq;

class CupsAndBottles
{
    static void Main()
    {
        var inputCups = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);
        Queue<int> cups = new Queue<int>(inputCups);
        var inputBottles = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);
        Stack<int> bottles = new Stack<int>(inputBottles);

        int waterWasted = 0;
        int cupRemainingCapacity = cups.Peek();

        while (bottles.Count > 0 && cups.Count > 0)
        {
            int currentBottle = bottles.Pop();

            if (currentBottle >= cupRemainingCapacity)
            {
                waterWasted += (currentBottle - cupRemainingCapacity);
                cups.Dequeue();

                if (cups.Count > 0)
                {
                    cupRemainingCapacity = cups.Peek();
                }
            }
            else
            {
                cupRemainingCapacity -= currentBottle;
            }
        }

        if (cups.Count > 0)
        {
            Console.WriteLine($"Cups: {string.Join(" ", cups)}");
        }
        else
        {
            Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
        }

        Console.WriteLine($"Wasted litters of water: {waterWasted}");
    }
}

